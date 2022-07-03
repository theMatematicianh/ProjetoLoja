using Projeto.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Models;

namespace Projeto.Services
{
    public class ClientService
    {
        private readonly ProjetoContext _context;

        public ClientService(ProjetoContext context)
        {
            _context = context;
        }
        public List<Client> FindAll()
        {
            return _context.Client.ToList();
        }
        public void Insert(Client obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
       
    }
}
