using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BettingOddsTestASPNETCORE.Models;
using BettingOddsTestASPNETCORE.Interfaces;

namespace BettingOddsTestASPNETCORE.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(BettingOddsTestASPNETCORE.Startup.BettingMachines);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}