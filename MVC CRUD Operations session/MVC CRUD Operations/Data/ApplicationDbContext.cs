using MVC_CRUD_Operations.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CRUD_Operations.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        //Here Category in Dbset is the model name and another Category is the name
        //that you want to give the table in Database which we could have given any name. 
        public DbSet<Category> Category { get; set; }
    }
}
