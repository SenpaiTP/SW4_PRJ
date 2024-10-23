using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PRJ4.DB;

public class Projekt4DbContext:DbContext
{
    private Projekt4DbContext(DbContextOptions<Projekt4DbContext> options) : base(options)
    {
    }
}