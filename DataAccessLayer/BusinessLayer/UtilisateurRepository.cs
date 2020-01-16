using DataAccessLayer.AccessLayer;
using DataAccessLayer.Chiffrement;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLayer
{
    public class UtilisateurRepository : ARepository<Utilisateur>
    {
        public new void Create(Utilisateur utilisateur)
        {
            try
            {
                utilisateur.MotDePasse = StringCipher.Encrypt(utilisateur.MotDePasse);
                DBContext.Instance.Utilisateurs.Add(utilisateur);
                Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error on Create", e);
            }
        }

        public new Utilisateur GetById(int id)
        {
            try
            {
                Utilisateur utilisateur = DBContext.Instance.Utilisateurs.Find(id).Clone();
                utilisateur.MotDePasse = StringCipher.Decrypt(utilisateur.MotDePasse);
                return utilisateur;
            }
            catch (Exception e)
            {
                throw new Exception("Error on GetById", e);
            }
        }

        public new void Update(Utilisateur utilisateur)
        {
            try
            {
                utilisateur = DBContext.Instance.Utilisateurs.Attach(utilisateur);
                utilisateur.MotDePasse = StringCipher.Encrypt(utilisateur.MotDePasse);
                DBContext.Instance.Entry(utilisateur).State = System.Data.Entity.EntityState.Modified;
                Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error on Update", e);
            }
        }

        public new ICollection<Utilisateur> GetAll()
        {
            try
            {
                List<Utilisateur> utilisateurs = new List<Utilisateur>();
                DBContext.Instance.Utilisateurs.ToList().ForEach(u => utilisateurs.Add(u.Clone()));
                utilisateurs.ForEach(u => u.MotDePasse = StringCipher.Decrypt(u.MotDePasse));
                return utilisateurs.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Error on GetAll", e);
            }
        }

        public Utilisateur GetUtilisateurByNomUtilisateur(string nomUtilisateur)
        {
            try
            {
                return GetAll().Where(u => u.NomUtilisateur == nomUtilisateur).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("Error on GetUtilisateurByNomUtilisateur", e);
            }
        }
    }
}
