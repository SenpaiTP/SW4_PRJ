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

    public class FIndtægtController:ControllerBase
    {
        private readonly IFIndtægtRepo _findtægtRepo;

        public FIndtægtController(IFIndtægtRepo findtægtRepo)
        {
            _findtægtRepo = findtægtRepo;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Findtægt>>> GetAll()
        {
            try {
                var findtægt = await _findtægtRepo.GetAllAsync();
                return Ok(findtægt);
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]

        public async Task<ActionResult<Findtægt>> Add(Findtægt findtægt)
        {
            if(findtægt==null)
            {
                return BadRequest("Findtægt cannot be null");
            }
            var newFindtægt = await _findtægtRepo.AddAsync(findtægt);
            await _findtægtRepo.SaveChangesAsync();
            return Ok(newFindtægt);
        }
    }
}