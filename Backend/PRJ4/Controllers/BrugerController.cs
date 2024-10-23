using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using PRJ4.Data;
using PRJ4.Models;  
using PRJ4.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PRJ4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BrugerController:ControllerBase
    {
        private readonly IBrugerRepo _brugerRepo;

        public BrugerController(IBrugerRepo brugerRepo)
        {
            _brugerRepo = brugerRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bruger>>> GetAll()
        {
            var bruger = await _brugerRepo.GetAllAsync();
            return Ok(bruger);
        }

        [HttpPost]
        public async Task<ActionResult<Bruger>> Add(Bruger bruger)
        {
            if(bruger==null)
            {
                return BadRequest("Bruger cannot be null");
            }
            var newBruger = await _brugerRepo.AddAsync(bruger);
            await _brugerRepo.SaveChangesAsync();
            return Ok(newBruger);
        }
    }
}