﻿using System;
using System.Collections.Generic;

namespace PRJ4.Models;

public partial class Bruger
{
    public int BrugerId { get; set; }

    public string Navn { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Findtægt> Findtægts { get; set; } = new List<Findtægt>();

    public virtual ICollection<Fudgifter> Fudgifters { get; set; } = new List<Fudgifter>();

    public virtual ICollection<Vindtægter> Vindtægters { get; set; } = new List<Vindtægter>();

    public virtual ICollection<Vudgifter> Vudgifters { get; set; } = new List<Vudgifter>();
}
