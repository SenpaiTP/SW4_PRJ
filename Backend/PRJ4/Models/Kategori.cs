using System;
using System.Collections.Generic;

namespace PRJ4.Models;

public partial class Kategori
{
    public int KategoriId { get; set; }

    public float Mad {get; set;}

    public float Leje {get; set;}

    public float Fornoejlser {get; set;}
    public virtual Bruger Bruger { get; set; } = null!;
}
