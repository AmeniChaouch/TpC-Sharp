using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    internal class Commande_ligne
    {
        public Commande_ligne(int id, Produit produit, int qte)
        {
            Id = id;
            Produit = produit;
            Qte = qte;
        }
        public float CalculerMontantLigne()
        {
            return Qte * Produit.PrixU;
        }
        public int Id { get; set; }


        public Produit Produit { get; set; }
        public int Qte { get; set; }
       

    }
}
