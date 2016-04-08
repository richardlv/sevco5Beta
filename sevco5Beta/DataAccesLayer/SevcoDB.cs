using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using sevco5Beta.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace sevco5Beta.DataAccesLayer
{
    public class SevcoDB:DbContext
    {
        public DbSet<dominios> dominios { get; set; }
        public DbSet<procesos> procesos { get; set; }
        public DbSet<preguntas> preguntas { get; set; }
        public DbSet<metas> metas { get; set; }
        public DbSet<lnk_Proceso_metas> lnk_proceso_metas { get; set; }
        public DbSet<proceso_respuestas> proceso_respuestas { get; set; }
        public DbSet<Evaluaciones> Evaluaciones { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<grupos> grupos { get; set; }
        public DbSet<proceso_resultados> proceso_resultados { get; set; }
        public DbSet<lnk_grupo_usrs> lnk_grupo_usrs { get; set; }

       /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            
        }*/

        
    }
}