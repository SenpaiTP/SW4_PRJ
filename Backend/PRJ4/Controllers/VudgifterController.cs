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

            // Retrieve the user's vudgifter records using the BrugerId
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
            // Extract BrugerId from the JWT token (the "sub" claim or NameIdentifier)
            var brugerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("sub")?.Value;
            if (string.IsNullOrEmpty(brugerIdClaim) || !int.TryParse(brugerIdClaim, out int authenticatedBrugerId))
            {
                return Unauthorized("Invalid token or missing BrugerId.");
            }
            // Validate that the input data is not null
            if (vudgifter == null)
            {
                return BadRequest("Vudgift cannot be null.");
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

            Kategori kategori;

            // If KategoriId is zero, create a new category
            if (vudgifter.KategoriId == 0)
            {
                kategori = await _kategoriRepo.NewKategori(vudgifter.KategoriName);
            }
            else
            {
                // Retrieve existing category
                kategori = await _kategoriRepo.GetByIdAsync(vudgifter.KategoriId);
                if (kategori == null)
                {
                    return NotFound($"Kategori with ID {vudgifter.KategoriId} not found.");
                }
            }

            // Create a new Vudgifter object and set properties
            var newVudgifter = new Vudgifter
            {
                Pris = vudgifter.Pris,
                Tekst = vudgifter.Tekst,
                Dato = DateTime.Now,
                BrugerId = bruger.BrugerId,
                KategoriId = kategori.KategoriId,
                Bruger = bruger,
                Kategori = kategori
            };

            // Save the new Vudgifter to the database
            await _vudgifterRepo.AddAsync(newVudgifter);
            await _vudgifterRepo.SaveChangesAsync();

            // Return the newly created Vudgifter object
            return Ok(newVudgifter);
        }
        [HttpPut("update/{id}")]
        public async Task<ActionResult<Vudgifter>> Updatevudgifter(int id, [FromBody] VudgifterUpdateDTO updateDTO)
        {
            // Step 1: Get the vudgifter entity from the database
            var vudgifter = await _vudgifterRepo.GetByIdAsync(id);
            if (vudgifter == null)
            {
                return NotFound("vudgifter not found.");
            }

            // Step 2: Handle dynamic updates for each property
            if (updateDTO.Pris.HasValue)
                vudgifter.Pris = updateDTO.Pris.Value;

            if (updateDTO.Tekst != null)
                vudgifter.Tekst = updateDTO.Tekst;

            if (updateDTO.Dato.HasValue)
                vudgifter.Dato = updateDTO.Dato.Value;

            // Step 3: Handle the Kategori update
            if (updateDTO.KategoriId.HasValue)
            {
                var kategori = await _kategoriRepo.GetByIdAsync(updateDTO.KategoriId.Value);
                if (kategori == null)
                {
                    // If the Kategori doesn't exist, create a new one
                    if(updateDTO.KategoriName == null)
                    {
                        return BadRequest("Failed no new kategori name");
                    }
                    kategori = await _kategoriRepo.NewKategori(updateDTO.KategoriName); 
                    if (kategori == null)
                    {
                        return BadRequest("Failed to create a new Kategori.");
                    }
                }

                vudgifter.KategoriId = kategori.KategoriId;
                vudgifter.Kategori = kategori;  // Update the related Kategori entity
            }

            // Step 4: Save the updated entity
            _vudgifterRepo.Update(vudgifter);
            await _vudgifterRepo.SaveChangesAsync();

            // Step 5: Return the updated entity
            return Ok(vudgifter);
        }
        [HttpDelete("{ID}/delete")]
        public async Task<ActionResult<Vudgifter>> DeleteVudgiftById(int id)
        {
            if (id <= 0)
            {
                return NotFound("Fudigft id cannot be less or equal to 0.");
            }
            Vudgifter vudgifter = await _vudgifterRepo.GetByIdAsync(id);
            if(vudgifter == null)
            {
                return BadRequest($"No Variable udgift with id {id}");
            }
            _vudgifterRepo.Delete(id);
            return NoContent();
        }

        

    }
}
