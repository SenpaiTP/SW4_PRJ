using System;
using System.Collections.Generic;

namespace PRJ4.Models;

public partial class Vudgifter
{
    public int VudgiftId { get; set; }

    public int BrugerId { get; set; }

    public string? KategoriId { get; set; }

    public decimal Pris { get; set; }

    public string? Tekst { get; set; }

    public DateTime? Dato { get; set; }

    public virtual Bruger Bruger { get; set; } = null!;
}
