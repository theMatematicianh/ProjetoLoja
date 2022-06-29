using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Data;

namespace Projeto.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public Order order { get; set; }
        public int Lvl { get; set; }

       
        public Client()
        {

        }

        
        public Client(int id, string name, string email, DateTime birthDate, string password,int lvl)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Password = password;
            Lvl = lvl;
        }
       
    }
}
