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
            catch (Exception) { }
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

        #endregion

        #region Gestion des lieux

        #endregion

        #region Gestion du matériel

        #endregion

        #region Planification

        #endregion
    }
}
