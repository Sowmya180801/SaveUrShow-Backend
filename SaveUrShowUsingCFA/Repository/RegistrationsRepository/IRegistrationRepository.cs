using Microsoft.AspNetCore.Mvc;
using SaveUrShowUsingCFA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaveUrShowUsingCFA.Repository.RegistrationsRepository
{
    public interface IRegistrationRepository
    {
        Task<ActionResult<IEnumerable<Registration>>> GetRegistration();
        Task<ActionResult<Registration>> GetRegistration(int id);
        Task<ActionResult<Registration>> GetRegistration(string email, string password);
        Task<ActionResult<Registration>> PostRegistration(Registration registration);
        Task<ActionResult<Registration>> PutRegistration(int id,Registration registration);
        Task<ActionResult<Registration>> DeleteRegistration(int id);
    }
}
