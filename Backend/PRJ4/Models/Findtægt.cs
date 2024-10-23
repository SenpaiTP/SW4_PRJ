using System;
using System.Collections.Generic;

namespace PRJ4.Models;

public partial class Findtægt
{
    public int Findtægt1 { get; set; }

    public int BrugerId { get; set; }

    public string Tekst { get; set; } = null!;

    public decimal Indtægt { get; set; }

    public DateTime? Dato { get; set; }

    public virtual Bruger Bruger { get; set; } = null!;
}
