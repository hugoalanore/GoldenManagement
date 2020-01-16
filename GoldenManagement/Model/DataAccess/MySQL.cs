using GoldenManagement.Model.BusinessObjects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
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

            string connString = string.Format("Server={0};Database={1};port={2};User Id={3};password={4}", host, database, port, username, password);
            MyConn = new MySqlConnection(connString);
        }

        public Utilisateur GetUtilisateurByNomUtilisateur(string nomUtilisateur)
        {
            // On teste les valeurs passé en paramètre
            if (nomUtilisateur == String.Empty) { throw new ArgumentException(); }

            // REQUETE
            Utilisateur utilisateur = new Utilisateur();
            MyConn.Open();
            try
            {
                string requete = "SELECT ID, NOM_UTILISATEUR, MOT_DE_PASSE, PRENOM, NOM FROM UTILISATEURS WHERE NOM_UTILISATEUR = @nomUtilisateur";
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

        public bool IsCorrectConnectionInformation(string nomUtilisateur, string motDePasse)
        {
            // On teste les valeurs passé en paramètre
            if (nomUtilisateur == String.Empty || motDePasse == String.Empty) { throw new ArgumentException(); }

            // REQUETE
            bool IsCorrect = false;

            MyConn.Open();
            try
            {
                string requete = "SELECT ID FROM T_UTILISATEURS WHERE NOM_UTILISATEUR = @nomUtilisateur AND MOT_DE_PASSE = @motDePasse";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                cmd.Parameters.Add("@nomUtilisateur", MySqlDbType.VarChar).Value = nomUtilisateur;
                cmd.Parameters.Add("@motDePasse", MySqlDbType.VarChar).Value = motDePasse;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        // Ok
                        IsCorrect = true;
                    }
                    else
                    {
                        // Pas Ok
                        IsCorrect = false;
                    }
                }
            }
            catch (Exception) { }
            finally
            {
                MyConn.Close();
            }

            return IsCorrect;
        }

        public string GetPassWordByNomUtilisateur(string nomUtilisateur)
        {
            throw new NotImplementedException();
        }
    }
}
