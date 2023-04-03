using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;



namespace projetCS20192020
{
    class Article
    {
        public int Num_Reférence { get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }
        public double Quantité_Stock { get; set; }

        public Article(string nom, double prix, double quantité)
        {
            Nom = nom;
            Prix = prix;
            Quantité_Stock = quantité;
        }

        public Article(int id,string nom, double prix, double quantité)
        {
            Num_Reférence = id;
            Nom = nom;
            Prix = prix;
            Quantité_Stock = quantité;
        }
        /*
         * 
         * Afficher les informations d'un article
         * 
         */

        public static void ToString(Article a)
        {
            if (a.Num_Reférence == null && (a.Nom != null || a.Prix != null || a.Quantité_Stock != null))
            {
                Console.WriteLine("Nom Article: " + a.Nom + " Prix Article: " + a.Prix + " Quantité Article en Stock: " + a.Quantité_Stock);
                Console.ReadLine();
            }
            else 
            {
                Console.WriteLine("Num Reférence: " + a.Num_Reférence + " Nom Article: " + a.Nom + " Prix Article: " + a.Prix + " Quantité Article en Stock: " + a.Quantité_Stock);
                Console.ReadLine();
            }   
        }

        /*
         * 
         * Rechercher un article à partir de sa reférence
         * 
         */

        public static void RechercherArticle(int reference)
        {
            Article a = null;
            try
            {

                OdbcCommand cmd= new OdbcCommand("select nom, prix, quantite_stock from article where num_ref=?", AccessBD.getConnexion());
                cmd.Parameters.AddWithValue("reference", reference);
                OdbcDataReader dr =cmd.ExecuteReader();

                if(dr.Read())
                {
                    a = new Article( dr.GetString(0), dr.GetDouble(1), dr.GetDouble(2));
                    ToString(a);
                }
        
                    cmd.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }

        /*
         * 
         * Rechercher un article à partir de son nom
         * 
         */

        public static void RechercherArticle(string nom)
        {
            Article a= null;
            try
            {
                OdbcCommand cmd = new OdbcCommand("select nom, prix, quantite_stock from article where nom=?", AccessBD.getConnexion());
                cmd.Parameters.AddWithValue("nom", nom);
                OdbcDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    a = new Article(dr.GetString(0), dr.GetDouble(1), dr.GetDouble(2));
                }
                ToString(a);
                cmd.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            
        }

        /*
         * 
         * Rechercher un article à partir d'un intervalle de prix
         * 
         */

        public static void RechercherArticle(double prix1, double prix2)
        {
            Article a = null;
            try
            {

                OdbcCommand cmd = new OdbcCommand("select nom, prix, quantite_stock from article where prix between ? and ?", AccessBD.getConnexion());
                cmd.Parameters.AddWithValue("prix1", prix1);
                cmd.Parameters.AddWithValue("prix2", prix2);
                OdbcDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    a = new Article(dr.GetString(0), dr.GetDouble(1), dr.GetDouble(2));
                    ToString(a);
                }
                cmd.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }

        /*
        * 
        * Ajouter un article 
        * 
        */

        public static string AjouterArticle(string nom, double prix, double quantite)
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("insert into article(nom, prix, quantite_stock) values(?,?,?)", AccessBD.getConnexion());
                cmd.Parameters.AddWithValue("a", nom);
                cmd.Parameters.AddWithValue("b", prix);
                cmd.Parameters.AddWithValue("c", quantite);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return "Article inséré avec succès";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /*
        * 
        * Modifier un article à partir de sa reférence
        * 
        */
        public static string ModifierArticle(int num_ref, string nom, double prix, double quantite)
        {

         try
         {
            OdbcCommand cmd = new OdbcCommand("update article set nom=?, prix=?, quantite_stock=? where num_ref=?", AccessBD.getConnexion());
            
            cmd.Parameters.AddWithValue("nom", nom);
            cmd.Parameters.AddWithValue("prix", prix);
            cmd.Parameters.AddWithValue("quantite", quantite);
            cmd.Parameters.AddWithValue("num_ref", num_ref);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            return "Article modifié avec succès";
        }
         catch (Exception e)
            {
                return e.Message;
            }
        }

        /*
        * 
        * Afficher tous les articles 
        * 
        */

        public static void AfficherArticle()
        {
            Article a = null;
            try
            {
                OdbcCommand cmd = new OdbcCommand("select* from article", AccessBD.getConnexion());
                OdbcDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    a = new Article( dr.GetInt32(0), dr.GetString(1), dr.GetDouble(2), dr.GetDouble(3));
                    ToString(a);
                }
                cmd.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }

        /*
        * 
        * Supprimer un article à partir de sa reférence
        * 
        */

        public static string SupprimerArticle(int reference)
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("delete from article where num_ref=?", AccessBD.getConnexion());
                cmd.Parameters.AddWithValue("num_ref", reference);
                cmd.ExecuteNonQuery();
                return "Article supprimé avec succès";
            }
            catch (Exception e)
            {
                return e.Message;
                
            }
        }

        /*
        * 
        * Quitter la console
        * 
        */

        public static void Quitter()
        {
            Console.WriteLine( "Voulez vous Quitter? Tapez 'O' ou 'N' ");
           string reponse=Console.ReadLine();
           if (reponse.Equals("O"))
           {
               Environment.Exit(0);
           }
        }















    }
}
