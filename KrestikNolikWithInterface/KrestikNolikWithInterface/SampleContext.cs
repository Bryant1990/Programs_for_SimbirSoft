using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace KrestikNolikWithInterface
{
    class SampleContext : DbContext 
    {
        public SampleContext() : base("Winners")
        {
            // Указывает EF, что если модель изменилась,
            // нужно воссоздать базу данных с новой структурой
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<SampleContext>());
        }

        public DbSet<Winners> Winner { get; set; }        
    }
}
