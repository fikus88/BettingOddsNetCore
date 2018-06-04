using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BettingOddsTestASPNETCORE.Interfaces;
using BettingOddsTestASPNETCORE.Models;

namespace BettingOddsTestASPNETCORE.Controllers
{
    public class BettingMachineController : Controller
    {
        public IActionResult Machine(int ID)
        {
            IMachine selectedMachine = BettingOddsTestASPNETCORE.Startup.BettingMachines.Where(x => x.ID == ID).First();
            selectedMachine.ClearTestResults();
            return View(selectedMachine);
        }

        [HttpPost]
        public IActionResult Machine(int machineID, int numOfTests)
        {
            IMachine machine = BettingOddsTestASPNETCORE.Startup.BettingMachines.Where(x => x.ID == Convert.ToInt32(machineID)).First();
            machine.ClearTestResults();

            for (int i = 1; i <= Convert.ToInt32(numOfTests); i++)
            {
                machine.RunSingleTest();
            }
            return View(machine);
        }
    }
}