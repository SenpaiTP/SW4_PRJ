using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PRJ4.Data;
using PRJ4.Models;
using PRJ4.Repositories;
using PRJ4.DTOs;

namespace PRJ4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Ensure the user is authenticated for all endpoints
    public class VudgifterController : ControllerBase
    {
        private readonly IVudgifter _vudgifterRepo;
        private readonly IBrugerRepo _brugerRepo;
        private readonly IKategori _kategoriRepo;

        public VudgifterController(IVudgifter vudgifterRepo, IBrugerRepo brugerRepo, IKategori kategoriRepo)
        {
            _vudgifterRepo = vudgifterRepo;
            _brugerRepo = brugerRepo;
            _kategoriRepo = kategoriRepo;
        }

        // GET: api/vudgifter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VudgifterResponseDTO>>> GetAllByUser()
        {
            // Get the BrugerId (User ID) from the JWT token's "sub" claim
            var brugerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("sub")?.Value;

            if (string.IsNullOrEmpty(brugerIdClaim) || !int.TryParse(brugerIdClaim, out int brugerId))
            {
                return Unauthorized("User ID claim missing or invalid.");
            }

            // Retrieve the user's Fudgifter records using the BrugerId
            var vudgifter = await _vudgifterRepo.GetAllByUserId(brugerId);

            // Map to response DTO
            var responseDTOs = vudgifter.Select(v => new VudgifterResponseDTO
            {
                VudgiftId = v.VudgiftId,
                Pris = v.Pris,
                Tekst = v.Tekst,
                KategoriName = v.Kategori?.Name,
                Dato = v.Dato
            });

            return Ok(responseDTOs);
        }

        // POST: api/vudgifter
        [HttpPost]
        public async Task<ActionResult<Vudgifter>> Add(newVudgifterDTO vudgifter)
        {
            if (vudgifter == null)
            {
                return BadRequest("Vudgift cannot be null");
            }

            // Extract BrugerId from the JWT token (the "sub" claim or NameIdentifier)
            var brugerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("sub")?.Value;
            if (string.IsNullOrEmpty(brugerIdClaim) || !int.TryParse(brugerIdClaim, out int authenticatedBrugerId))
            {
                return Unauthorized("Invalid token or missing BrugerId.");
            }

            // Ensure that the BrugerId from the token matches the BrugerId in the request body
            if (vudgifter.BrugerId != authenticatedBrugerId)
            {
                return Unauthorized("BrugerId from token doesn't match the provided BrugerId.");
            }

            // Check if the user (Bruger) exists
            Bruger bruger = await _brugerRepo.GetByIdAsync(vudgifter.BrugerId);
            if (bruger == null)
            {
                return NotFound($"Bruger with ID {vudgifter.BrugerId} not found.");
            }

            // Create a new Vudgifter object and set properties
            var newVudgifter = new Vudgifter
            {
                Pris = vudgifter.Pris,
                Tekst = vudgifter.Tekst,
                Bruger = bruger,
                Dato = DateTime.Now
            };

            // Validate the KategoriId
            if (vudgifter.KategoriId <= 0)
            {
                return BadRequest("KategoriId cannot be less than or equal to zero.");
            }

            // Get the Kategori by Id
            Kategori kategori = await _kategoriRepo.GetByIdAsync(vudgifter.KategoriId);
            if (kategori == null)
            {
                return NotFound($"Kategori with ID {vudgifter.KategoriId} not found.");
            }

            // Assign the Kategori to the new Vudgifter object
            newVudgifter.Kategori = kategori;

            // Save the new Vudgifter to the database
            await _vudgifterRepo.AddAsync(newVudgifter);
            await _vudgifterRepo.SaveChangesAsync();

            // Return the newly created Vudgifter object
            return Ok(newVudgifter);
        }
    }
}
