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

    public class FudgifterController:ControllerBase
    {
        private readonly IFudgifter _fudgifterRepo;
        private readonly IBrugerRepo _brugerRepo;
        private readonly IKategori _kategoriRepo;

        public FudgifterController(IFudgifter fudgifterRepo, IBrugerRepo brugerRepo, IKategori kategoriRepo)
        {
           _fudgifterRepo = fudgifterRepo;
           _brugerRepo = brugerRepo;
           _kategoriRepo = kategoriRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FudgifterResponseDTO>>> GetAll()
        {
            var fudgifter = await _fudgifterRepo.GetAllAsync();

            // Map to response DTO
            var responseDTOs = fudgifter.Select(f => new FudgifterResponseDTO
            {
                FudgiftId = f.FudgiftId,
                Pris = f.Pris,
                Tekst = f.Tekst,
                KategoriName = f._Kategori?.Name, // Include the category name
                Dato = f.Dato
            });

            return Ok(responseDTOs);
        }

        [HttpPost]
        public async Task<ActionResult<Fudgifter>> Add(newFudgifterDTO fudgifter)
        {
            if(fudgifter==null)
            {
                return BadRequest("Fast Udgift cannot be null");
            }
            else if(fudgifter.BrugerId <= 0)
            {
                return BadRequest("Bruger id findes ikke");
            }
            Bruger bruger = await _brugerRepo.GetByIdAsync(fudgifter.BrugerId);
            if (bruger == null)
            {
                return NotFound($"Bruger with ID {bruger.BrugerId} not found.");
            }
            var newfudgifter = new Fudgifter
            {
                Pris = fudgifter.Pris,
                Tekst = fudgifter.Tekst,
                Bruger = bruger,
                Dato = DateTime.Now

            };
            if(fudgifter.KategoriId <= 0){
                Kategori kategori = await _kategoriRepo.GetByIdAsync(fudgifter.KategoriId);
                if (bruger == null)
                {
                    return NotFound($"Kategori with ID {fudgifter.KategoriId} not found.");
                }
                newfudgifter._Kategori = kategori;
            }
            await _fudgifterRepo.AddAsync(newfudgifter);
            await _fudgifterRepo.SaveChangesAsync();
            return Ok(newfudgifter);
        }
    }
}