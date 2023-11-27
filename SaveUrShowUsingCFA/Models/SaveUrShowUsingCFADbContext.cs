using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaveUrShowUsingCFA.Models
{
    public class SaveUrShowUsingCFADbContext : DbContext
    {
        public SaveUrShowUsingCFADbContext(DbContextOptions<SaveUrShowUsingCFADbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<FindTicket> FindTicket { get; set; }
        public virtual DbSet<BookingTicket> BookingTicket { get; set; }
        public virtual DbSet<feedback> feedback { get; set; }
        public object Registrations { get; internal set; }
    }
}
