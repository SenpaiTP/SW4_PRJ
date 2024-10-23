using System;
using System.Collections.Generic;

namespace PRJ4.Models;

public partial class Fudgifter
{
    public int FudgiftId { get; set; }

    public int BrugerId { get; set; }

    public decimal Pris { get; set; }

    public string? Tekst { get; set; }

    public DateTime? Dato { get; set; }

    public virtual Bruger Bruger { get; set; } = null!;
}
