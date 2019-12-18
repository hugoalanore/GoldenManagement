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

        public List<Formation> GetAllFormations()
        {
            List<Formation> allFormations = new List<Formation>();

            // REQUETE
            MyConn.Open();
            try
            {
                string requete = "SELECT T_FORMATIONS.ID, T_FORMATIONS.INTITULE, T_FORMATIONS.NB_JOUR, T_FORMATIONS.EST_ACTIVE, T_FORMATIONS_TYPES.LIBELLE FROM T_FORMATIONS INNER JOIN T_FORMATIONS_TYPES ON T_FORMATIONS.FORMATIONS_TYPE_ID=T_FORMATIONS_TYPES.ID";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                DbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Formation formation = new Formation();
                    formation.Id = reader.GetInt16(0);
                    formation.Intitule = reader.GetString(1);
                    formation.NbJour = reader.GetInt16(2);
                    formation.Libelle = reader.GetString(4);
                    allFormations.Add(formation);
                }

            }
            catch (Exception) { }
            finally
            {
                MyConn.Close();
            }

            return allFormations;
        }

        public List<TypeFormation> GetAllFormationsTypes()
        {
            List<TypeFormation> allFormationsTypes = new List<TypeFormation>();

            // REQUETE
            MyConn.Open();
            try
            {
                string requete = "SELECT ID, LIBELLE FROM T_FORMATIONS_TYPES";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                DbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TypeFormation typeFormation = new TypeFormation();
                    typeFormation.Id = reader.GetInt32(0);
                    typeFormation.Libelle = reader.GetString(1);
                    allFormationsTypes.Add(typeFormation);
                }
            }
            catch (Exception) { }
            finally
            {
                MyConn.Close();
            }

            return allFormationsTypes;
        }

        public Formation GetFormationById(int id)
        {
            // REQUETE
            Formation formation = new Formation();
            MyConn.Open();
            try
            {
                string requete = "SELECT T_FORMATIONS.ID, T_FORMATIONS.INTITULE, T_FORMATIONS.NB_JOUR, T_FORMATIONS.EST_ACTIVE, T_FORMATIONS_TYPES.LIBELLE FROM T_FORMATIONS INNER JOIN T_FORMATIONS_TYPES ON T_FORMATIONS.FORMATIONS_TYPE_ID=T_FORMATIONS_TYPES.ID WHERE T_FORMATIONS.ID = @id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                cmd.Parameters.Add("@id", MySqlDbType.Int64).Value = id;

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        formation.Id = reader.GetInt16(0);
                        formation.Intitule = reader.GetString(1);
                        formation.NbJour = reader.GetInt16(2);
                        formation.Libelle = reader.GetString(4);
                    }
                }

            }
            catch (Exception) { }
            finally
            {
                MyConn.Close();
            }

            return formation;
        }

        public List<Formation> GetAllFormationByFormationType(int id)
        {
            List<Formation> formationsSameType = new List<Formation>();
            MyConn.Open();
            try
            {
                string requete = "SELECT T_FORMATIONS.ID, T_FORMATIONS.INTITULE, T_FORMATIONS.NB_JOUR, T_FORMATIONS.EST_ACTIVE, T_FORMATIONS_TYPES.LIBELLE FROM T_FORMATIONS INNER JOIN T_FORMATIONS_TYPES ON T_FORMATIONS.FORMATIONS_TYPE_ID=T_FORMATIONS_TYPES.ID WHERE T_FORMATIONS_TYPES.ID = @id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                cmd.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
                DbDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Formation formation = new Formation();
                    formation.Id = reader.GetInt16(0);
                    formation.Intitule = reader.GetString(1);
                    formation.NbJour = reader.GetInt16(2);
                    formation.Libelle = reader.GetString(4);
                    formationsSameType.Add(formation);
                }
            }
            catch (Exception) { }
            finally
            {
                MyConn.Close();
            }

            return formationsSameType;
        }

        public bool UpdateFormations(String intitule, int nbJour, String types, int id)
        {
            // On teste les valeurs passé en paramètre
            if (intitule == String.Empty || types == String.Empty) { throw new ArgumentException(); }

            // REQUETE
            bool IsDo = false;

            // REQUETE
            MyConn.Open();
            try
            {
                string requete = "UPDATE `T_FORMATIONS` SET `INTITULE`=@intitule, `NB_JOUR`=@nbJour, `FORMATIONS_TYPE_ID`=(SELECT ID FROM T_FORMATIONS_TYPES WHERE LIBELLE=@types) WHERE ID=@id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                cmd.Parameters.Add("@intitule", MySqlDbType.VarChar).Value = intitule;
                cmd.Parameters.Add("@nbJour", MySqlDbType.Int64).Value = nbJour;
                cmd.Parameters.Add("@types", MySqlDbType.VarChar).Value = types;
                cmd.Parameters.Add("@id", MySqlDbType.Int64).Value = id;

                cmd.ExecuteNonQuery();

                //TODO faire verif update dans BDD

                IsDo = true;
            }
            catch (Exception) { IsDo = false; }
            finally
            {
                MyConn.Close();
            }

            return IsDo;
        }

        public bool AddFormations(String intitule, int nbJour, String types)
        {
            // On teste les valeurs passé en paramètre
            if (intitule == String.Empty || types == String.Empty) { throw new ArgumentException(); }


            // REQUETE
            bool IsDo = false;
            MyConn.Open();
            try
            {
                string requete = "INSERT INTO T_FORMATIONS (INTITULE, NB_JOUR, FORMATIONS_TYPE_ID, EST_ACTIVE) VALUES (@intitule, @nbJour, (SELECT ID FROM T_FORMATIONS_TYPES WHERE LIBELLE=@types), 1)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                cmd.Parameters.Add("@intitule", MySqlDbType.VarChar).Value = intitule;
                cmd.Parameters.Add("@types", MySqlDbType.VarChar).Value = types;
                cmd.Parameters.Add("@nbJour", MySqlDbType.Int16).Value = nbJour;
                cmd.ExecuteNonQuery();

                //TODO faire verif ajout dans BDD

                IsDo = true;
            }
            catch (Exception) { IsDo = false; }
            finally
            {
                MyConn.Close();
            }

            return IsDo;
        }

        public bool DeleteFormation(int id)
        {

            // REQUETE
            bool IsDo = false;

            // REQUETE
            MyConn.Open();
            try
            {
                string requete = "DELETE FROM `T_FORMATIONS` WHERE ID = @id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                cmd.Parameters.Add("@id", MySqlDbType.Int64).Value = id;

                cmd.ExecuteNonQuery();

                IsDo = true;
            }
            catch (Exception) { IsDo = false; }
            finally
            {
                MyConn.Close();
            }

            return IsDo;
        }

        public bool AddTypeFormations(String types)
        {
            // On teste les valeurs passé en paramètre
            if (types == String.Empty) { throw new ArgumentException(); }


            // REQUETE
            bool IsDo = false;
            MyConn.Open();
            try
            {
                string requete = "INSERT INTO T_FORMATIONS_TYPES (LIBELLE) VALUES (@types)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                cmd.Parameters.Add("@types", MySqlDbType.VarChar).Value = types;
                cmd.ExecuteNonQuery();

                //TODO faire verif ajout dans BDD

                IsDo = true;
            }
            catch (Exception) { IsDo = false; }
            finally
            {
                MyConn.Close();
            }

            return IsDo;
        }

        public bool GetTypeFormationByType(String types)
        {
            // REQUETE
            bool IsFind = false;
            MyConn.Open();
            try
            {
                string requete = "SELECT LIBELLE FROM T_FORMATIONS_TYPES WHERE LIBELLE = @libelle";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                cmd.Parameters.Add("@libelle", MySqlDbType.VarChar).Value = types;

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        IsFind = true;
                    }
                }

            }
            catch (Exception) { }
            finally
            {
                MyConn.Close();
            }

            return IsFind;
        }

        #endregion

        #region Gestion des formateurs
            
        public List<Formateur> GetAllFormateursFormations()
        {
            List<Formateur> allFormateurs = new List<Formateur>();

            // REQUETE
            MyConn.Open();
            try
            {
                string requete = "SELECT T_FORMATEURS.ID, T_FORMATEURS.NOM, T_FORMATEURS.PRENOM FROM T_FORMATEURS";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                DbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Formateur formateur = new Formateur();
                    formateur.Id = reader.GetInt16(0);
                    formateur.Nom = reader.GetString(1);
                    formateur.Prenom = reader.GetString(2);
                    allFormateurs.Add(formateur);
                }

            }
            catch (Exception) { }
            finally
            {
                MyConn.Close();
            }

            return allFormateurs;
        } 

        public bool addFormateurFormation(int idFormation, int idFormateur)
        {
            MyConn.Open();
            bool IsDo = false;
            try
            {
                string requete = "INSERT INTO T_GROUPE_MATERIELS_REQUIS_FORMATION (FORMATIONS_ID, FORMATEURS_ID) VALUES (@idFormation, @idFormateur)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                cmd.Parameters.Add("@idFormation", MySqlDbType.Int32).Value = idFormation;
                cmd.Parameters.Add("@idFormateur", MySqlDbType.Int32).Value = idFormateur;
                DbDataReader reader = cmd.ExecuteReader();

                IsDo = true;
            }
            catch (Exception) { }
            finally
            {
                MyConn.Close();
            }

            return IsDo;
        }

        public bool deleteFormateurFormation(int id)
        {
            MyConn.Open();
            bool IsDo = false;
            try
            {
                string requete = "DELETE FROM T_GROUPE_FORMATIONS_FORMATEURS WHERE ID = @id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                DbDataReader reader = cmd.ExecuteReader();

                IsDo = true;

            }
            catch (Exception) { }
            finally
            {
                MyConn.Close();
            }

            return IsDo;
        }

        #endregion

        #region Gestion des personnes

        #endregion

        #region Gestion des lieux

        #endregion

        #region Gestion du matériel
        public List<Materiel> GetAllMateriels()
        {
            List<Materiel> allMateteriel = new List<Materiel>();

            // REQUETE
            MyConn.Open();
            try
            {
                string requete = "SELECT ID, LIBELLE, EST_ACTIVE FROM T_MATERIELS";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                DbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Materiel materiel = new Materiel();
                    materiel.Id = reader.GetInt16(0);
                    materiel.Libelle = reader.GetString(1);
                    allMateteriel.Add(materiel);
                }

            }
            catch (Exception) { }
            finally
            {
                MyConn.Close();
            }
            return allMateteriel;
        }

        public List<Materiel> GetListMaterielsFormation(int id)
        {
            MyConn.Open();
            List<Materiel> listMateriel = new List<Materiel>();
            try
            {
                string requete = "SELECT T_GROUPE_MATERIELS_REQUIS_FORMATION.ID, T_MATERIELS.LIBELLE, T_GROUPE_MATERIELS_REQUIS_FORMATION.QUANTITE FROM T_GROUPE_MATERIELS_REQUIS_FORMATION INNER JOIN T_MATERIELS ON T_GROUPE_MATERIELS_REQUIS_FORMATION.MATERIEL_ID=T_MATERIELS.ID WHERE T_GROUPE_MATERIELS_REQUIS_FORMATION.FORMATION_ID = @id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                DbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Materiel materiel = new Materiel();
                    materiel.Id = reader.GetInt16(0);
                    materiel.Libelle = reader.GetString(1);
                    materiel.QuantiteFormation = reader.GetInt16(2);
                    listMateriel.Add(materiel);
                }

            }
            catch (Exception) { }
            finally
            {
                MyConn.Close();
            }

            return listMateriel;
        }

        public bool deleteMaterielFormation(int id)
        {
            MyConn.Open();
            bool IsDo = false;
            try
            {
                //string requete = "DELETE FROM `T_FORMATIONS` WHERE ID = @id";
                string requete = "DELETE FROM T_GROUPE_MATERIELS_REQUIS_FORMATION WHERE ID = @id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                DbDataReader reader = cmd.ExecuteReader();

                IsDo = true;

            }
            catch (Exception) { }
            finally
            {
                MyConn.Close();
            }

            return IsDo;
        }

        public bool addMaterielFormation(int idFormation, string libelle, int quantite)
        {
            MyConn.Open();
            bool IsDo = false;
            try
            {
                string requete = "INSERT INTO T_GROUPE_MATERIELS_REQUIS_FORMATION (FORMATION_ID, MATERIEL_ID, QUANTITE) VALUES (@idFormation, (SELECT ID FROM T_MATERIELS WHERE LIBELLE=@libelle), @quantite)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyConn;
                cmd.CommandText = requete;
                cmd.Parameters.Add("@idFormation", MySqlDbType.Int32).Value = idFormation;
                cmd.Parameters.Add("@libelle", MySqlDbType.VarChar).Value = libelle;
                cmd.Parameters.Add("@quantite", MySqlDbType.Int32).Value = quantite;
                DbDataReader reader = cmd.ExecuteReader();

                IsDo = true;
            }
            catch (Exception) { }
            finally
            {
                MyConn.Close();
            }

            return IsDo;
        }
        #endregion

        #region Planification

        #endregion
    }
}
