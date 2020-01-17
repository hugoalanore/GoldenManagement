using GoldenManagement.Model.BusinessObjects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Model.DataAccess
{
    class MySQL : IDataAccess
    {
        public MySqlConnection MyConn { get; set; }
        public MySQL()
        {
            string host = "remotemysql.com";
            int port = 3306;
            string database = "RHj5ce97rJ";
            string username = "RHj5ce97rJ";
            string password = "kHy5SBwVsh";

            string connString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password;
            MyConn = new MySqlConnection(connString);
        }

        #region Gestion des utilisateurs
        public Utilisateur GetUtilisateurByNomUtilisateur(string nomUtilisateur)
        {
            // On teste les valeurs passé en paramètre
            if (nomUtilisateur == String.Empty) { throw new ArgumentException(); }

            // REQUETE
            Utilisateur utilisateur = new Utilisateur();
            MyConn.Open();
            try
            {
                string requete = "SELECT ID, NOM_UTILISATEUR, MOT_DE_PASSE, PRENOM, NOM FROM T_UTILISATEURS WHERE NOM_UTILISATEUR = @nomUtilisateur";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                cmd.Parameters.Add("@nomUtilisateur", MySqlDbType.VarChar).Value = nomUtilisateur;

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        utilisateur.Id = reader.GetInt16(0);
                        utilisateur.NomUtilisateur = reader.GetString(1);
                        utilisateur.MotDePasse = reader.GetString(2);
                        utilisateur.Prenom = reader.GetString(3);
                        utilisateur.Nom = reader.GetString(4);
                    }
                }
            }
            catch (Exception) { }
            finally
            {
                MyConn.Close();
            }

            return utilisateur;
        }

        public String GetPassWordByNomUtilisateur(string nomUtilisateur)
        {
            // On teste les valeurs passé en paramètre
            if (nomUtilisateur == String.Empty) { throw new ArgumentException(); }

            // REQUETE
            String password = null;
            MyConn.Open();
            try
            {
                string requete = "SELECT MOT_DE_PASSE FROM T_UTILISATEURS WHERE NOM_UTILISATEUR = @nomUtilisateur";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                cmd.Parameters.Add("@nomUtilisateur", MySqlDbType.VarChar).Value = nomUtilisateur;

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        password = reader.GetString(0);
                    }
                }
            }
            catch (Exception e) {
                return e.Message;

            }
            finally
            {
                MyConn.Close();
            }

            return password;
        }

        #endregion

        #region Gestion des formations

        #endregion

        #region Gestion des personnes

        /**
         * 
         * Récuperer la list de tous les apprénants pour les afficher dans la view apprenant
         * 
         **/
        public List<Apprenant> GetApprenants()
        {
            // REQUETE
            List<Apprenant> ListApprenant = new List<Apprenant>();
            MyConn.Open();
            try
            {
                string requete = "SELECT ID, CIVILITE, PRENOM, NOM, DATE_NAISSANCE, LIEU_NAISSANCE, NATIONALITE, ADRESSE, VILLE, CODE_POSTAL, NUM_PORTABLE, NUM_DOMICILE, ADRESSE_MAIL, EST_ACTIVE FROM T_APPRENANTS";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Apprenant apprenant = new Apprenant();

                           
                            

                            apprenant.Id = reader.GetInt16(0);
                            apprenant.Civilite = reader.GetString(1);
                            apprenant.Prenom = reader.GetString(2);
                            apprenant.Nom = reader.GetString(3);

                            DateTime date = reader.GetDateTime(4);
                            string formatted = date.ToString("dd/M/yyyy");
                            apprenant.DateNaissance = formatted;

                            apprenant.LieuNaissance = reader.GetString(5);
                            apprenant.Nationnalite = reader.GetString(6);
                            apprenant.Adresse = reader.GetString(7);
                            apprenant.Ville = reader.GetString(8);
                            apprenant.CodePostal = reader.GetString(9);
                            apprenant.TelephonePortable = reader.GetString(10);
                            apprenant.TelephoneFixe = reader.GetString(11);
                            apprenant.Mail = reader.GetString(12);
                            apprenant.EstActif = reader.GetInt16(13);

                            ListApprenant.Add(apprenant);
                        }
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            finally
            {
                MyConn.Close();
            }

            return ListApprenant;
        }

        ///**
        //* 
        //* Récuperer le paramètre
        //* 
        //**/
        //public List<Apprenant> GetApprenant()
        //{
        //    // REQUETE
        //    List<Apprenant> ListApprenant = new List<Apprenant>();
        //    Apprenant apprenant = new Apprenant();
        //    MyConn.Open();
        //    try
        //    {
        //        string requete = "SELECT ID, CIVILITE, PRENOM, NOM, DATE_NAISSANCE, LIEU_NAISSANCE, NATIONALITE, ADRESSE, VILLE, CODE_POSTAL, NUM_PORTABLE, NUM_DOMICILE, ADRESSE_MAIL FROM T_APPRENANTS";
        //        MySqlCommand cmd = new MySqlCommand();
        //        cmd.Connection = MyConn;
        //        cmd.CommandText = requete;

        //        using (DbDataReader reader = cmd.ExecuteReader())
        //        {
        //            if (reader.HasRows)
        //            {
        //                reader.Read();
        //                apprenant.Id = reader.GetInt16(0);
        //                apprenant.Civilite = reader.GetString(1);
        //                apprenant.Prenom = reader.GetString(2);
        //                apprenant.Nom = reader.GetString(3);
        //                apprenant.DateNaissance = reader.GetDateTime(4);
        //                apprenant.LieuNaissance = reader.GetString(5);
        //                apprenant.Nationnalite = reader.GetString(6);
        //                apprenant.Adresse = reader.GetString(7);
        //                apprenant.Ville = reader.GetString(8);
        //                apprenant.CodePostal = reader.GetString(9);
        //                apprenant.TelephonePortable = reader.GetString(10);
        //                apprenant.TelephoneFixe = reader.GetString(11);
        //                apprenant.Mail = reader.GetString(12);
        //                ListApprenant.Add(apprenant);
        //            }
        //        }
        //    }
        //    catch (Exception) { }
        //    finally
        //    {
        //        MyConn.Close();
        //    }

        //    return ListApprenant;
        //}
        #endregion

        #region Gestion des lieux

        #endregion

        #region Gestion du matériel

        #endregion

        #region Planification

        #endregion
    }
}
