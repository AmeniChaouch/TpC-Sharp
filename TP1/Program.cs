
using TP1;

class Program
{
    public static void Main(string[] args)

    {
        List<Produit> produits = new List<Produit>();
        Client client = new Client(1, "oumaima", "nsir", "14");
        Produit P1 = new Produit(1, "Biscuit", Category.Alimentaire, 1.800f);
        Produit P2 = new Produit(2, "Jus", Category.Alimentaire, 3.500f);
        Produit P3 = new Produit(3, "Tapis", Category.Décoratif, 85.000f);
        Produit P4 = new Produit(4, "Montre", Category.Décoratif, 39.000f);

        Commande_ligne L1 = new Commande_ligne(1, P1, 15);
        Commande_ligne L2 = new Commande_ligne(2, P3, 10);
        Commande_ligne L3 = new Commande_ligne(3, P4, 5);
        Commande_ligne L4 = new Commande_ligne(4, P2, 18);
        List<Commande_ligne> lignesCommande = new List<Commande_ligne> { L1, L2, L3, L4 };

        float montantTotal = 0;
        foreach (var ligne in lignesCommande)
        {
            montantTotal += ligne.CalculerMontantLigne();
        }

        Commande commande = new Commande(1, DateTime.Now, lignesCommande, montantTotal);

        Console.Write("Veuillez entrer votre prénom : ");
        string prenom = Console.ReadLine();

        Console.Write("Veuillez entrer votre nom : ");
        string nom = Console.ReadLine();


        bool quitter = false;

        while (!quitter)
        {
            // Affichage du menu
           // Console.Clear(); // Efface l'écran à chaque boucle
            Console.WriteLine("Menu :");
            Console.WriteLine("1. Créer une commande");
            Console.WriteLine("2. Modifier une commande");
            Console.WriteLine("3. Quitter");
            Console.Write("\nVeuillez choisir une option : ");

            // Lecture de l'option choisie
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    // Appeler la méthode pour créer une commande
                    CreerCommande();
                    break;

                case "2":
                    // Appeler la méthode pour modifier une commande
                    //ModifierCommande();
                    break;

                case "3":
                    quitter = true;
                    Console.WriteLine("Au revoir !");
                    break;

                default:
                    Console.WriteLine("Option invalide. Veuillez essayer à nouveau.");
                    break;

            }

            // Attendre que l'utilisateur appuie sur une touche avant de continuer
            if (!quitter)
            {
                Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                Console.ReadKey();
            }
        }
    }

    

    // Méthode pour créer une commande
    static void CreerCommande()
    {
        Commande cmd = new Commande();
       
       
        float montantTotal = 0;
        int id = 1;  // L'ID commence à 1 et s'incrémente à chaque ligne de commande

        while (true)
        {
            // Demander le nom du produit ou terminer si '-1' est tapé
            Console.Write("\nVeuillez entrer le nom du produit (ou taper '-1' pour terminer) : ");
            string nomProduit = Console.ReadLine();

            if (nomProduit == "-1")
            {
                break;
            }

            // Création d'un objet Produit
            Produit produit = new Produit
            {
                NomP = nomProduit
            };

            int prixUnitaire = 0;

            // Demander le prix unitaire du produit
            Console.Write("Veuillez entrer le prix unitaire du produit : ");
            if (!int.TryParse(Console.ReadLine(), out prixUnitaire) || prixUnitaire <= 0)
            {
                Console.WriteLine("Prix invalide, veuillez réessayer.");
                continue;
            }

            produit.PrixU = prixUnitaire;

            // Demander la quantité commandée
            Console.Write("Veuillez entrer la quantité commandée : ");
            if (!int.TryParse(Console.ReadLine(), out int quantite) || quantite <= 0)
            {
                Console.WriteLine("Quantité invalide, veuillez réessayer.");
                continue;
            }

            // Créer une ligne de commande avec ID auto-incrémenté
            var ligneCommande = new Commande_ligne(id++, // Incrémentation automatique de l'ID
                produit,quantite);

           
            cmd.commandes.Add(ligneCommande);

           
         }

        // Afficher le montant total de la commande
        Console.WriteLine("\nLa commande a été créée avec succès !");
       
    }

   /* static void ModifierCommande()
    {
        Console.Clear();
        Console.WriteLine("Modification d'une commande");

        if (lignesCommande.Count == 0)
        {
            Console.WriteLine("Aucune commande à modifier.");
            return;
        }

        // Afficher les lignes de commande existantes
        Console.WriteLine("Voici les lignes de commande existantes :");
        for (int i = 0; i < lignesCommande.Count; i++)
        {
            var ligne = lignesCommande[i];
            Console.WriteLine($"{ligne.Id}. {ligne.Produit.NomP} - {ligne.Qte} x {ligne.Produit.PrixU}€ = {ligne.CalculerMontantLigne()}€");
        }

        // Demander à l'utilisateur de choisir une ligne à modifier
        Console.Write("\nEntrez l'ID de la ligne à modifier (ou 0 pour annuler) : ");
        if (!int.TryParse(Console.ReadLine(), out int idLigne) || idLigne == 0)
        {
            return; // Annuler la modification
        }

        // Trouver la ligne de commande par ID
        var ligneCommande = lignesCommande.Find(l => l.Id == idLigne);
        if (ligneCommande == null)
        {
            Console.WriteLine("Ligne de commande introuvable.");
            return;
        }

        // Modifier la quantité ou le produit
        Console.WriteLine($"Modification de la ligne : {ligneCommande.Produit.NomP} - {ligneCommande.Qte} x {ligneCommande.Produit.PrixU}€");

        Console.WriteLine("Que souhaitez-vous modifier ?");
        Console.WriteLine("1. Modifier la quantité");
        Console.WriteLine("2. Modifier le produit");
        Console.WriteLine("3. Annuler");
        Console.Write("\nVeuillez choisir une option : ");

        string choixModification = Console.ReadLine();

        switch (choixModification)
        {
            case "1":
                // Modifier la quantité
                Console.Write("Entrez la nouvelle quantité : ");
                if (int.TryParse(Console.ReadLine(), out int nouvelleQuantite) && nouvelleQuantite > 0)
                {
                    // Recalculer le montant total en fonction de la nouvelle quantité
                    montantTotal -= ligneCommande.CalculerMontantLigne();  // Retirer l'ancien montant
                    ligneCommande.Qte = nouvelleQuantite;  // Mettre à jour la quantité
                    montantTotal += ligneCommande.CalculerMontantLigne();  // Ajouter le nouveau montant
                    Console.WriteLine($"Nouvelle quantité de {ligneCommande.Produit.NomP} : {ligneCommande.Qte}");
                }
                else
                {
                    Console.WriteLine("Quantité invalide.");
                }
                break;

            case "2":
                // Modifier le produit
                Console.Write("Entrez le nouveau nom du produit : ");
                string nouveauNomProduit = Console.ReadLine();

                Console.Write("Entrez le nouveau prix unitaire : ");
                if (int.TryParse(Console.ReadLine(), out int nouveauPrix) && nouveauPrix > 0)
                {
                    ligneCommande.Produit.NomP = nouveauNomProduit;
                    ligneCommande.Produit.PrixU = nouveauPrix;

                    // Recalculer le montant total en fonction du nouveau produit
                    montantTotal -= ligneCommande.CalculerMontantLigne();  // Retirer l'ancien montant
                    montantTotal += ligneCommande.CalculerMontantLigne();  // Ajouter le nouveau montant
                    Console.WriteLine($"Produit modifié en : {ligneCommande.Produit.NomP} à {ligneCommande.Produit.PrixU}€");
                }
                else
                {
                    Console.WriteLine("Prix invalide.");
                }
                break;

            case "3":
                Console.WriteLine("Modification annulée.");
                break;

            default:
                Console.WriteLine("Option invalide.");
                break;
        }

        // Afficher le montant total mis à jour
        Console.WriteLine($"Montant total après modification : {montantTotal:F2} €");
    }*/


}