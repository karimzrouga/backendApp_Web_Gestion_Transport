

using Microsoft.AspNetCore.Mvc;
using Gestpsfe.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication2.Migrations;
using Microsoft.AspNetCore.Authorization;
using WebApplication2.Services.UserService;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly PfeContext _context;
        private static User myuser;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        public StatisticsController(IConfiguration configuration, IUserService userService, PfeContext context, IAuthenticationService authenticationService)
        {
            _configuration = configuration;
            _userService = userService;
            _context = context;
            _authenticationService = authenticationService;
        }

        [HttpGet("/statusers")]
        public async Task<ActionResult<IEnumerable<UserStatistics>>> GetStatistics()
        {
            var totalu = await _context.Users.ToListAsync();
            DateTime lastMonth = DateTime.Now.AddMonths(-1);
            int lastMonthUsers = await _context.Users
          .Where(u => u.CreatedAt >= lastMonth)
          .CountAsync();
            var statistics = _context.Users
         .Join(
             _context.ListePlanifications,
             u => u.ListePlanificationId,
             p => p.Id,
             (u, p) => new { u.RoleId, u.ShiftId, u.ListePlanificationId, PlanificationName = p.PlanificationName }
         )
         .GroupBy(u => new { u.RoleId, u.ShiftId, u.ListePlanificationId, u.PlanificationName })
         .Select(g => new
         {
             RoleId = g.Key.RoleId,
             ShiftId = g.Key.ShiftId,
             PlanificationId = g.Key.ListePlanificationId,
             PlanificationName = g.Key.PlanificationName,
             UserCount = g.Count(),
             total= totalu.Count(),
             totallastMonth = lastMonthUsers
         })
         .OrderBy(s => s.PlanificationId)
         .ToList();

            return Ok(statistics);
        }



        [HttpGet("/statvegicules")]
        public IActionResult GetVehicleStatistics()
        {
            var currentDate = DateTime.Now;
            var lastMonthDate = currentDate.AddMonths(-1);
            var vehicleCountByAgency = _context.Vehicules
                .Include(v => v.Agence) // Include the Agence navigation property
                .GroupBy(v => new { v.AgenceId, v.Agence.Name }) // Group by AgenceId and Agence.Name
                .Select(g => new { g.Key.AgenceId, g.Key.Name, VehicleCount = g.Count() })
                .ToList();
            var totalAgencies = vehicleCountByAgency.Count;

            var AgenciesFromLastMonth = _context.Vehicules.Where(v => v.CreatedAt >= lastMonthDate && v.CreatedAt <= currentDate)
        .Count();
            var totalVehicles = vehicleCountByAgency.Sum(v => v.VehicleCount);

            var statistics = new
            {
                TotalAgencies = totalAgencies,
                TotalVehicules = totalVehicles,
                AgenciesFromLastMonth = AgenciesFromLastMonth,
                VehicleCountByAgency = vehicleCountByAgency
            };

            return Ok(statistics);
        }


        [HttpGet("/statplanification")]
        public IActionResult GetStatisticsByAgencyAndCapacity()
        {
            var statistics = _context.PlanificationParAgences
          .GroupBy(p => new { p.AgenceId, p.Capacite })
          .Select(g => new
          {
              AgencyId = g.Key.AgenceId,
              Capacity = g.Key.Capacite,
              Count = g.Sum(p => p.Nbbus)
          })
          .ToList();

            var result = statistics.Select(s => new
            {
                AgencyName = _context.Agences.FirstOrDefault(a => a.Id == s.AgencyId)?.Name,
                Capacity = s.Capacity,
                Count = s.Count
            })
            .ToList();

            return Ok(result);
        }

        [HttpGet("/statfacturation")]
        public IActionResult GetStatisticsByAgencyAndBillingAmountByDate()
        {
            var statistics = _context.Facturations
                .GroupBy(f => new { f.AgenceId, f.DateFacturation.Date })
                .Select(g => new
                {
                    AgencyId = g.Key.AgenceId,
                    Date = g.Key.Date,
                    TotalBillingAmount = g.Sum(f => f.Montant)
                })
                .ToList();

            var result = statistics.Select(s => new
            {
                AgencyName = _context.Agences.FirstOrDefault(a => a.Id == s.AgencyId)?.Name,
                Date = s.Date,
                TotalBillingAmount = s.TotalBillingAmount
            })
            .ToList();

            return Ok(result);
        }

    }


}