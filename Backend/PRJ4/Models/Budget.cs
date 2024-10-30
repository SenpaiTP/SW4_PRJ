using System.ComponentModel.DataAnnotations;

namespace PRJ4.Models;

public partial class Budget
{
    [Key]
    public int BudgetId { get; set; }

    public int Test { get; set; }

    //public Kategori kategori { get; set; }

}