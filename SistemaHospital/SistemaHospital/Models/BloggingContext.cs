using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SistemaHospital.Modelo
{
    public class BloggingContext: DbContext
    {

        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        {
        }

    }
}
