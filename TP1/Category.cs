using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    internal class Category
    {
        public Category()
        {
        }

        public Category(int id, string nomCat)
        {
            Id = id;
            NomCat = nomCat;
        }

        public static int? Décoratif { get; internal set; }
        public static int? Alimentaire { get; internal set; }
        public int Id { get; set; }
        public string NomCat { get; set; }
    }
}
