using Microsoft.AspNetCore.Mvc;
using SaveUrShowUsingCFA.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using SaveUrShowUsingCFA.Controllers;
using Microsoft.EntityFrameworkCore;

namespace SaveUrShowUsingCFA.Repository.RegistrationsRepository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly SaveUrShowUsingCFADbContext _context;
        private readonly ILogger<RegistrationsController> _logger;
        public RegistrationRepository(SaveUrShowUsingCFADbContext context,ILogger<RegistrationsController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistration()
        {
            _logger.LogInformation("Getting all users");            
            return await _context.Registration.ToListAsync();
        }
        public async Task<ActionResult<Registration>> GetRegistration(int id)
        {
            var registration = await _context.Registration.FindAsync(id);

            return registration;
        }
        public async Task<ActionResult<Registration>> GetRegistration(string email, string password)
        {
            var registration = await _context.Registration.FirstOrDefaultAsync(record => record.email == email && record.password == password); //using lambda function we r checking the email and password of a register user

            return registration;
        }
        public async Task<ActionResult<Registration>> PostRegistration(Registration registration)
        {
            _context.Registration.Add(registration);
            await _context.SaveChangesAsync();
            return registration;
        }

        public async Task<ActionResult<Registration>> PutRegistration(int id, Registration registration)
        {
            _context.Entry(registration).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return registration;
        }

        public async Task<ActionResult<Registration>> DeleteRegistration(int id)
        {
            var registration = await _context.Registration.FindAsync(id);
            _context.Registration.Remove(registration);
            await _context.SaveChangesAsync();
            return registration;
        }
    }
}
