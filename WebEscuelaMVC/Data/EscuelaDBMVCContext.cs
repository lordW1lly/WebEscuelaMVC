using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Data
{
    public class EscuelaDBMVCContext : DbContext
    {
        public EscuelaDBMVCContext(): base("keyEscuelaDBMVC") { }
        
        public DbSet <Aula> aulas { get; set; }
    }
}