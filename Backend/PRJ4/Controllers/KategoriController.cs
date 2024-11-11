using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using PRJ4.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PRJ4.Data;
using PRJ4.Models;  
using PRJ4.Repositories;
using PRJ4.DTOs;
using PRJ4.Infrastructure;
using PRJ4.Services;


namespace PRJ4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class KategoriController:ControllerBase
    {
        private readonly IKategori _kategoriRepo;
        private readonly TokenProvider _tokenProvider;
        private readonly IBrugerService _brugerservice;

        public KategoriController(IKategori kategoriRepo, TokenProvider tokenProvider,IBrugerService brugerservice)
        {
            _kategoriRepo = kategoriRepo;
            _tokenProvider = tokenProvider;
            _brugerservice = brugerservice;
        }
    }
}