using Microsoft.EntityFrameworkCore;
using RazorPagesTool.Data;
using RazorPagesTool.Models;

namespace RazorPagesTool.SeedData
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesToolContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesToolContext>>()))
            {
                if (context == null || context.Tools == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                if (!context.Baskets.Any())
                {
                    context.Baskets.Add(new Basket());
                }

                // Look for any movies.
                if (context.Tools.Any())
                {
                    return;   // DB has been seeded
                }


                context.Tools.AddRange(
                    new Tool
                    {
                        Title = "Перфоратор",
                        Price = 22000M,
                        /* img = "../img/00027961.jpg"*/
                    },

                    new Tool
                    {
                        Title = "Фрезер",
                        Price = 12000M,
                        /* img = "../img/681624ede23a80c844f7a455fea071de.jpg"*/
                    },

                    new Tool
                    {
                        Title = "Дрель-шуруповерт",
                        Price = 4500M,
                        /*img = "../img/55.970.jpg"*/
                    },

                    new Tool
                    {
                        Title = "Электролобзик",
                        Price = 5700M,
                        /*img = "../img/244_main_.jpg"*/
                    },
                    new Tool
                    {
                        Title = "Электрорубанок",
                        Price = 5050M,
                        /*img = "../img/6f4byplpzngxtqcwvpj6uy40umfwizt4.jpeg"*/
                    },
                    new Tool
                    {
                        Title = "Реноватор",
                        Price = 3036M,
                        Count = 12,
                        /*img = "../img/94ad259b97e293e98ff02aadf36cb031.jpeg"*/
                    },
                    new Tool
                    {
                        Title = "Электропила",
                        Price = 5280M,
                        /*img = "../img/6571128502.jpg"*/
                    },
                    new Tool
                    {
                        Title = "Воздуходув",
                        Price = 1699M,
                        /*img = "../img/9cb8e02e710f47dbc74332782a6df5d0.jpg"*/
                    },
                    new Tool
                    {
                        Title = "Электрический распылитель",
                        Price = 3800M,
                        /*img = "../img/51718834.jpg"*/
                    },
                    new Tool
                    {
                        Title = "Машина заточная",
                        Price = 7490M,
                        /*img = "../img/758465855.jpg"*/
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
