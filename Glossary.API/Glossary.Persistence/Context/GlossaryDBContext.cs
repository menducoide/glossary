using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glossary.Persistence.Context
{
  public  class GlossaryDBContext : DbContext
    {
        public GlossaryDBContext(DbContextOptions<GlossaryDBContext> options)
            : base(options) { }
        public DbSet<Term> Term { get; set; }
    }
}
