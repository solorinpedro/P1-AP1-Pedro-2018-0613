using Microsoft.EntityFrameworkCore;
using P1_AP1_Pedro_2018_0613.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_AP1_Pedro_2018_0613.DAL
{
    public class Contexto : DbContext 
    {
        public DbSet<Aportes> Aportes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\registroAportes.db");
        }
    }
}
