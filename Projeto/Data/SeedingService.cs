using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Models;

namespace Projeto.Data
{
    public class SeedingService
    {
        private ProjetoContext _context;

        public SeedingService(ProjetoContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Client.Any())
            {
                return; // DB has been seeded
            }



            Client s1 = new Client(1, "Jessica Maria", "Jessica@gmail.com", new DateTime(1998, 4, 21), "3903Jessica", 1);
            Client s2 = new Client(2, "Mateus Rocha", "Mateclam@gmail.com", new DateTime(1979, 12, 31), "3903Mateus", 0);

            _context.Client.AddRange(s1, s2);

            _context.SaveChanges();
        }
    }
}
