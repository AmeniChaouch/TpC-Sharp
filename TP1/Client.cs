using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    internal class Client
    {
        public Client(int id, string nom, string prenom, string codeFid)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            this.codeFid = codeFid;
        }

        public int Id { get; set; }


        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string codeFid { get; set; }

    }
}
