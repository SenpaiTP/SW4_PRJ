using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using PRJ4.Data;
using PRJ4.Models;  
using PRJ4.Repositories;
using PRJ4.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace PRJ4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VudgifterController:ControllerBase
    {
        private readonly IVudgifter _vudgifterRepo;
        private readonly IBrugerRepo _brugerRepo;
        private readonly IKategori _kategoriRepo;

        public VudgifterController(IVudgifter VudgifterRepo, IBrugerRepo brugerRepo, IKategori kategoriRepo)
        {
           _vudgifterRepo = VudgifterRepo;
           _brugerRepo = brugerRepo;
           _kategoriRepo = kategoriRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VudgifterResponseDTO>>> GetAll()
        {
            var vudgifter = await _vudgifterRepo.GetAllAsync();

            // Map to response DTO
            var responseDTOs = vudgifter.Select(f => new VudgifterResponseDTO
            {
                VudgiftId = f.VudgiftId,
                Pris = f.Pris,
                Tekst = f.Tekst,
                KategoriName = f.Kategori?.Name, // Include the category name
                Dato = f.Dato
            });

            return Ok(responseDTOs);
        }

        [HttpPost]
        public async Task<ActionResult<Vudgifter>> Add(newVudgifterDTO vudgifter)
        {
            if(vudgifter==null)
            {
                return BadRequest("Fast Udgift cannot be null");
            }
            else if(vudgifter.BrugerId <= 0)
            {
                return BadRequest("Bruger id findes ikke");
            }
            Bruger bruger = await _brugerRepo.GetByIdAsync(vudgifter.BrugerId);
            if (bruger == null)
            {
                return NotFound($"Bruger with ID {vudgifter.BrugerId} not found.");
            }
            var newVudgifter = new Vudgifter
            {
                Pris = vudgifter.Pris,
                Tekst = vudgifter.Tekst,
                Bruger = bruger,
                Dato = DateTime.Now

            };
            if(vudgifter.KategoriId <= 0){
                Kategori kategori = await _kategoriRepo.GetByIdAsync(vudgifter.KategoriId);
                if (bruger == null)
                {
                    return NotFound($"Kategori with ID {vudgifter.KategoriId} not found.");
                }
                newVudgifter.Kategori = kategori;
            }
            await _vudgifterRepo.AddAsync(newVudgifter);
            await _vudgifterRepo.SaveChangesAsync();
            return Ok(newVudgifter);
        }
    }
}