using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRJ4.Models;

public partial class Fudgifter
{
    [Key]
    public int FudgiftId { get; set; }

    public decimal Pris { get; set; }

    public int BrugerId {get; set;}

    public string? Tekst { get; set; }

    public Kategori? _Kategori {get; set;}

    public DateTime? Dato { get; set; }

    [ForeignKey(nameof(BrugerId))]
    public virtual Bruger Bruger { get; set; } = null!;

}
