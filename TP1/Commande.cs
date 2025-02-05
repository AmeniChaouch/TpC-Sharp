using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    internal class Commande
    {

        public int Id { get; set; }

       

        public DateTime dateC { get; set; }
        public Double montant { get; set; }
        // Navigation property : liste des produits dans cette catégorie
        public List<Commande_ligne> commandes { get; set; }

        public Commande(int id, DateTime dateC, List<Commande_ligne> commandes, double montant)
        {
            Id = id;
            this.dateC = dateC;
            this.commandes = commandes;
            this.montant = montant;
        }

        public Commande()
        {
            commandes=new List<Commande_ligne>();
        }

        public float CalculerMontantTotal()
        {
            float montantTotal = 0;
           
            foreach (var ligne in commandes)
            {
                montantTotal += ligne.CalculerMontantLigne();
            }
            return montantTotal;
        }

       
    }

}
