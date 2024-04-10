using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Presentation.Areas.Identity.Data;

public class MicroUser : IdentityUser
{
    public int Ide { get; set; }
    public string Nome { get; set; }
    public string Departamento { get; set; }
    public int Matricula { get; set; }
}

