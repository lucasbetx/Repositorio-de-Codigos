using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RepositoryCodes.Models
{
    public class Contexto: DbContext
    {
        public DbSet<NewCode> Codes { get; set; }
    }
}