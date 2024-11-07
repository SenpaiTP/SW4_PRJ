using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRJ4.Models;

public partial class Budget
{
    [Key]
    public int BudgetId { get; set; }
    public int? BrugerId { get; set; }
    public int Test { get; set; }

    [ForeignKey(nameof(BrugerId))]
    public Bruger? Bruger { get; set; }

    //public Kategori kategori { get; set; }

}