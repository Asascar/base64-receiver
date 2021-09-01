using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Netbanking.RemessaArquivo.API.Models
{
    public class RemessaContext : DbContext
    {
        public RemessaContext(DbContextOptions<RemessaContext> options)
            : base(options)
        {
        }

        public DbSet<RemessaItem> RemessaItems { get; set; }
    }
}
