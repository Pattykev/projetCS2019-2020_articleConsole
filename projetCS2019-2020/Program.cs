using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projetCS20192020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("******************MENU******************");
            Console.WriteLine("****************************************");
            Console.WriteLine("1- Rechercher un article par reférence");
            Console.WriteLine("2- Ajouter un article dans la base de données");
            Console.WriteLine("3- Supprimer un article de la base de données");
            Console.WriteLine("4- Modifier un article par reférence de la base de données");
            Console.WriteLine("5- Rechercher un article par nom de la base de données");
            Console.WriteLine("6- Rechercher un article par intervalle de prix de vente de la base de données");
            Console.WriteLine("7- Afficher tous les articles de la base de données");
            Console.WriteLine("8- Quitter");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1": Console.WriteLine("Entrer la reférence:");
                    string rep = Console.ReadLine();
                    Article.RechercherArticle(Int32.Parse(rep));
                    Console.ReadLine();
                    break;
                case "2": Console.WriteLine("Entrer les informations sur l'article:");
                    string nom = Convert.ToString(Console.ReadLine());
                    double prix = Double.Parse(Console.ReadLine());
                    double quantite = Double.Parse(Console.ReadLine());

                    string message = Article.AjouterArticle(nom, prix, quantite);
                    Console.ReadLine();
                    break;

                case "3": Console.WriteLine("Entrer la reférence sur l'article:");
                    int reference =Int32.Parse( Console.ReadLine());
                    message = Article.SupprimerArticle(reference);
                    Console.WriteLine(message);
                    Console.ReadLine();
                    break;

                case "4": Console.WriteLine("Entrer les informations sur l'article:");
                    string referenc = Console.ReadLine();
                    string name = Console.ReadLine();
                    string prixx = Console.ReadLine();
                    string quant = Console.ReadLine();
                    message=Article.ModifierArticle(Int32.Parse(referenc), name, Double.Parse(prixx), Double.Parse(quant));
                    Console.WriteLine(message);
                    Console.ReadLine();
                    break;
                case "5": Console.WriteLine("Entrer le nom:");
                    string nome = Console.ReadLine();
                    Article.RechercherArticle(nome);
                    Console.ReadLine();
                    break;
                case "6": Console.WriteLine("Entrer les bornes de l'intervalle:");
                    string i1 = Console.ReadLine();
                    string i2 = Console.ReadLine();
                    Article.RechercherArticle(Double.Parse(i1), Double.Parse(i2));
                    Console.ReadLine();
                    break;
                case "7": Console.WriteLine("Afficher tous les articles:");
                    Article.AfficherArticle();
                    Console.ReadLine();
                    break;
                case "8":
                    Article.Quitter();
                    break;
                default: Console.WriteLine("Faites un choix valide!");
                    break;
                    


            }
        }
    }
}
