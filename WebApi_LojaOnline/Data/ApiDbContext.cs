
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi_LojaOnline.Models;

namespace WebApi_LojaOnline.Data
{
    public class ApiDbContext : DbContext
    {       
        public DbSet<ProductClass> SetProdutos { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {

        }
    }
}
