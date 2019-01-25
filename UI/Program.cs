using Data;
using Microsoft.EntityFrameworkCore;
using Samuri.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    //Disconnected means using API or Web Services
    class Program
    {
       private static Context context = new Context();
        static void Main(string[] args)
        {
            /**Simple CURD**/
            // InsertSamuri();
            //InsertMultipleSamuri();
            //InsertMultipleDifferentObjects();
            // SimpleSamuriQuery();
            //MoreQueries();
            // UpdateSamuri();
            // MultipleOpertions();
            //UpdateDisconnected();
            //DeleteSamuri();
            //DeleteDisconnected();
            //DeleteRange();

            /**Related CRUD**/
            //InsertPKFKGraph();
            //InsertChildToExistingObject();
            //InsertChildToExistingObjectDisconnected(2);
            // EagerLoading();
            //ProjectLoading();
            // FilterWithRelatedData();
            //UpdateRelatedData();
            //UpdateRelatedDataDisconnected();
        }
        //Related CRUD
        private static void UpdateRelatedDataDisconnected()
        {
            var samuri = context.Samuris.Include(s=>s.Quotes).LastOrDefault();
            var quote = samuri.Quotes[0];
              quote.Text = " 456";
            using (var _context =new Context()) 
            {
                 _context.Quotes.Update(quote);
                //_context.Entry(quote).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
        private static void UpdateRelatedData()
        {
            /*var samuri = context.Samuris.Include(s=>s.Quotes).FirstOrDefault();
            samuri.Quotes[0].Text += " 123";*/
            var samuri = context.Samuris.Include(s => s.Quotes).LastOrDefault();
            samuri.Quotes.Remove(samuri.Quotes[0]);
            context.SaveChanges();
        }
        private static void FilterWithRelatedData()
        {
            var samuris = context.Samuris.Where(s => s.Quotes.Any(q => q.Text.Contains("H"))).ToList();
        }
        private static void ProjectLoading()
        {
            var samuris = context.Samuris.Select(s => new { s.Id, s.Name }).ToList();
        }
        private static void EagerLoading()
        {
            var samuris = context.Samuris.Include(s=>s.Quotes).ToList();
        }
        private static void InsertChildToExistingObjectDisconnected(int SamuriId)
        {
            Quote quote = new Quote { Text = "Hghghghghghg",SamuriId=SamuriId };
            using (var _context = new Context())
            {
                 _context.Quotes.Add(quote);
                 _context.SaveChanges();
            }
           
        }
        private static void InsertChildToExistingObject()
        {
            var samuri = context.Samuris.FirstOrDefault();
            samuri.Quotes.Add(new Quote { Text = "Hlhlhlhlhlhl" });
            context.SaveChanges();
        }
        private static void InsertPKFKGraph()
        {
            var samuri = new Samurai
            {
                Name = "AsD",
                Quotes = new List<Quote>
                {
                    new Quote{Text="Hahahahahhaha"},
                    new Quote{Text="Hihihihihihi"}
                }
            };
            context.Samuris.Add(samuri);
            context.SaveChanges();
        }
        //Simple CRUD
        private static void DeleteRange()
        {
            var samuris = context.Samuris.Where(s => s.Name.Contains("123"));
            context.RemoveRange(samuris);
            context.SaveChanges();
        }
        private static void DeleteDisconnected()
        {
            var samuri = context.Samuris.LastOrDefault();
            using (var _context =new Context())
            {
                _context.Samuris.Remove(samuri);
                _context.SaveChanges();
            }
            
        }
        private static void DeleteSamuri()
        {
            var samuri = context.Samuris.LastOrDefault();
            context.Samuris.Remove(samuri);
            context.SaveChanges();
        }
        private static void UpdateDisconnected()
        {
            var samuri = context.Samuris.Find(2);
            samuri.Name = "AhMeD";
            using(var _context=new Context())
            {
                _context.Update(samuri);
                _context.SaveChanges();
            }
        }
        private static void MultipleOpertions()
        {
            var addone = new Samurai { Name = "AAAAA" };
            var samuri = context.Samuris.FirstOrDefault(s=>s.Name=="Ahmed 123");
            samuri.Name = "Ahmed";
            context.Add(addone);
            context.SaveChanges();
        }
        private static void UpdateSamuri()
        {
            var samuri = context.Samuris.ToList();
            samuri.ForEach (s=>s.Name+= " 123");
            context.SaveChanges();
        }
        private static void MoreQueries()
        {
            var samruis = context.Samuris.Where(s => s.Name == "Asd").ToList();
        }
        private static void SimpleSamuriQuery()
        {
                var samuris = context.Samuris.ToList();   
        }
        private static void InsertSamuri()
        {
            var samuri = new Samurai { Name = "Ahmed" };
                context.Samuris.Add(samuri);
                context.SaveChanges();
        }
        private static void InsertMultipleSamuri()
        {
            var samuri = new Samurai { Name = "Ahmed" };
            var samuri1 = new Samurai { Name = "Asd" };
                context.Samuris.AddRange(samuri,samuri1);
                context.SaveChanges();
        }
        private static void InsertMultipleDifferentObjects()
        {
            var samuri = new Samurai { Name = "Asd" };
            var battle = new Battle
            {
                Name = "aaaa", StartDate = new DateTime(2000, 6, 16), EndDate = new DateTime(2000, 6, 18)
            };
                context.AddRange(samuri,battle);
                context.SaveChanges();
        }
    }
}
