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
using Microsoft.AspNetCore.Authorization;
using PRJ4.Services;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Security.Claims;
namespace PRJ4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FudgifterController:ControllerBase
    {
        private readonly IFudgifter _fudgifterRepo;
        private readonly IBrugerRepo _brugerRepo;
        private readonly IKategori _kategoriRepo;
        private readonly IBrugerService _brugerservice;

        public FudgifterController(IFudgifter fudgifterRepo, IBrugerService brugerservice, IKategori kategoriRepo, IBrugerRepo brugerRepo)
        {
           _fudgifterRepo = fudgifterRepo;
           _brugerservice = brugerservice;
           _kategoriRepo = kategoriRepo;
            _brugerRepo = brugerRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FudgifterResponseDTO>>> GetAllByUser()
        {
            // Get the BrugerId (User ID) from the JWT token's "sub" claim
            var brugerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("sub")?.Value;

            if (string.IsNullOrEmpty(brugerIdClaim) || !int.TryParse(brugerIdClaim, out int brugerId))
            {
                return Unauthorized("User ID claim missing or invalid.");
            }

            // Retrieve the user's Fudgifter records using the BrugerId
            var fudgifter = await _fudgifterRepo.GetAllByUserId(brugerId);

            // Map to response DTO
            var responseDTOs = fudgifter.Select(f => new FudgifterResponseDTO
            {
                FudgiftId = f.FudgiftId,
                Pris = f.Pris,
                Tekst = f.Tekst,
                KategoriName = f.Kategori?.Name,
                Dato = f.Dato
            });

            return Ok(responseDTOs);
        }

        [HttpPost]
        public async Task<ActionResult<Fudgifter>> Add(newFudgifterDTO fudgifter)
        {
            // Validate that the input data is not null
            if (fudgifter == null)
            {
                return BadRequest("Fast Udgift cannot be null");
            }

            // Extract BrugerId from the JWT token (the "sub" claim or NameIdentifier)
            var brugerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("sub")?.Value;
            if (string.IsNullOrEmpty(brugerIdClaim) || !int.TryParse(brugerIdClaim, out int authenticatedBrugerId))
            {
                return Unauthorized("Invalid token or missing BrugerId.");
            }

            // If the provided BrugerId in the DTO doesn't match the authenticated BrugerId, return Unauthorized
            if (fudgifter.BrugerId != authenticatedBrugerId)
            {
                return Unauthorized("BrugerId from token doesn't match the provided BrugerId.");
            }

            // Check if the user (Bruger) exists
            Bruger bruger = await _brugerRepo.GetByIdAsync(fudgifter.BrugerId);
            if (bruger == null)
            {
                return NotFound($"Bruger with ID {fudgifter.BrugerId} not found.");
            }

            // Create the new Fudgifter object and set properties
            var newFudgifter = new Fudgifter
            {
                Pris = fudgifter.Pris,
                Tekst = fudgifter.Tekst,
                Bruger = bruger,
                Dato = DateTime.Now
            };

            // Check if the KategoriId is valid
            if (fudgifter.KategoriId <= 0)
            {
                return BadRequest("KategoriId cannot be less than or equal to zero.");
            }

            // Get the Kategori by Id
            Kategori kategori = await _kategoriRepo.GetByIdAsync(fudgifter.KategoriId);
            if (kategori == null)
            {
                return NotFound($"Kategori with ID {fudgifter.KategoriId} not found.");
            }

            // Assign the Kategori to the new Fudgifter object
            newFudgifter.Kategori = kategori;

            // Save the new Fudgifter to the database
            await _fudgifterRepo.AddAsync(newFudgifter);
            await _fudgifterRepo.SaveChangesAsync();

            // Return the newly created Fudgifter object
            return Ok(newFudgifter);
        }

    }
}