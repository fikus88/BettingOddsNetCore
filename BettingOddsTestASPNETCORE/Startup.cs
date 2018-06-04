using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BettingOddsTestASPNETCORE.Interfaces;
using BettingOddsTestASPNETCORE.Models;

namespace BettingOddsTestASPNETCORE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static List<BettingOddsTestASPNETCORE.Interfaces.IMachine> BettingMachines = SeedBettingMachines();

        private static List<IMachine> SeedBettingMachines()
        {
            List<Interfaces.IMachine> BettingMachines = new List<Interfaces.IMachine>();

            BettingMachines.Add(new RouletteType("Black or Red Party", 1));
            BettingMachines.Add(new DiceType("Dice Roll 2000", 1));

            int ID = 1;

            foreach (IMachine machine in BettingMachines)
            {
                machine.ID = ID;
                ID++;
            }

            return BettingMachines;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}