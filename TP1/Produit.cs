using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    internal class Produit
    {
        public Produit()
        {
        }

        public Produit(int id, string nomP, int? categoryId, float prixU)
        {
            Id = id;
            NomP = nomP;
            CategoryId = categoryId;
            PrixU = prixU;
           
        }

        public int Id { get; set; }

       
        public string NomP { get; set; }

       
        public int? CategoryId { get; set; }

        
        public float PrixU { get; set; }

     
        public Category Category { get; set; }
    }
}
