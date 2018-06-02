using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }

        public int page_count { get; set; }

        public string title { get; set; }
    }

    /*class ResultContext : DbContext
    {
        public ResultContext()
             : base("DbConnection")
        { }

        public DbSet<GameResults> Results { get; set; }
    }*/

    



}