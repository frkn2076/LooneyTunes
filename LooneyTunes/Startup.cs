using System.Collections.Generic;
using GraphiQl;
using LooneyTunes.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LooneyTunes
{
    public class Startup
    {

        ////****I use my Azure DB for shared service endpoint.****////

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<AppDBContext>(options => options.UseInMemoryDatabase("LooneyTunes"));//MemoryDatabase
            //services.AddDbContext<AppDBContext>(options => options.UseSqlServer("Server=tcp:*********.database.windows.net,1433;Initial Catalog=****;Persist Security Info=False;User ID=********;Password=************;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<AppDBContext>();
                db.Cartoons.AddRange(
                    new List<Cartoon> {
                        new Cartoon
                        {
                            CartoonId = 1,
                            Name = "Bugs Bunny",
                            Image = "https://i.hizliresim.com/mMVZy2.png",
                            Description = "Happy Rabbit"
                        },
                        new Cartoon
                        {
                            CartoonId = 2,
                            Name = "Tweety",
                            Image = "https://i.hizliresim.com/r5qvkz.png",
                            Description = "Yellow Canary"
                        },
                        new Cartoon
                        {
                            CartoonId = 3,
                            Name = "Daffy Duck",
                            Image = "https://i.hizliresim.com/WqlR3q.png",
                            Description = "American Black Duck"
                        },
                        new Cartoon
                        {
                            CartoonId = 4,
                            Name = "Sylvester",
                            Image = "https://i.hizliresim.com/mMVZAy.png",
                            Description = "Tuxedo Cat"
                        },
                        new Cartoon
                        {
                            CartoonId = 5,
                            Name = "Tasmanian Devil",
                            Image = "https://i.hizliresim.com/OvWOp0.png",
                            Description = "Tasmanian Devil"
                        },
                        new Cartoon
                        {
                            CartoonId = 6,
                            Name = "Porky Pig",
                            Image = "https://i.hizliresim.com/7aOZGm.png",
                            Description = "Pig"
                        },
                        new Cartoon
                        {
                            CartoonId = 7,
                            Name = "Marvin the Martian",
                            Image = "https://i.hizliresim.com/0RPA5W.png",
                            Description = "Martian"
                        },
                        new Cartoon
                        {
                            CartoonId = 8,
                            Name = "Pepe Le Pew",
                            Image = "https://i.hizliresim.com/8aGoyV.png",
                            Description = "Striped Skunk"
                        },
                        new Cartoon
                        {
                            CartoonId = 9,
                            Name = "Elmer Fudd",
                            Image = "https://i.hizliresim.com/y6y9ka.gif",
                            Description = "Human"
                        },
                        new Cartoon
                        {
                            CartoonId = 10,
                            Name = "Speedy Gonzales",
                            Image = "https://i.hizliresim.com/nQvoBg.png",
                            Description = "Mouse"
                        },
                        new Cartoon
                        {
                            CartoonId = 11,
                            Name = "Yosemite Sam",
                            Image = "https://i.hizliresim.com/grNRB2.png",
                            Description = "Human"
                        },
                        new Cartoon
                        {
                            CartoonId = 12,
                            Name = "Foghorn Leghorn",
                            Image = "https://i.hizliresim.com/oXLlok.png",
                            Description = "Leghorn Rooster"
                        }

                    });
                db.SaveChanges();
            }

            app.UseMvc();

        }
    }
}
