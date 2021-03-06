﻿namespace DataAccessLayer.AccessLayer
{
    using DataAccessLayer.Outiles.Chiffrement;
    using DataAccessLayer.Exceptions;
    using DataAccessLayer.Models;
    using MySql.Data.Entity;
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DBContext : DbContext
    {
        public virtual DbSet<Apprenant> Apprenants { get; set; }
        public virtual DbSet<ArchivageSession> ArchivageSessions { get; set; }
        public virtual DbSet<Batiment> Batiments { get; set; }
        public virtual DbSet<DomaineFormation> DomaineFormations { get; set; }
        public virtual DbSet<Formateur> Formateurs { get; set; }
        public virtual DbSet<FormationFormateur> FormationFormateurs { get; set; }
        public virtual DbSet<Formation> Formations { get; set; }
        public virtual DbSet<Jour> Jours { get; set; }
        public virtual DbSet<JourSession> JourSessions { get; set; }
        public virtual DbSet<MaterielFormation> MaterielFormations { get; set; }
        public virtual DbSet<Materiel> Materiels { get; set; }
        public virtual DbSet<RoleUtilisateur> RoleUtilisateurs { get; set; }
        public virtual DbSet<Salle> Salles { get; set; }
        public virtual DbSet<SessionApprenant> SessionApprenants { get; set; }
        public virtual DbSet<SessionFormateur> SessionFormateurs { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<StockMateriel> StockMateriels { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

        // À la fin du dev, passer le constructeur en "private"
        public DBContext()
            : base(StringCipher.Decrypt(ConfigurationManager.ConnectionStrings["DB_MYSQL_RMS"].ConnectionString))
        {
            Database.SetInitializer<DBContext>(new DBInitializer());
            this.Configuration.LazyLoadingEnabled = false;

            // Pour désactiver l'initialiseur
            // Database.SetInitializer<DBContext>(null);
        }

        private static readonly Lazy<DBContext> lazy = new Lazy<DBContext>(() => new DBContext());

        public static DBContext Instance {
            get {
                if (CheckConnection()) { return lazy.Value; }
                else { throw new DALException("Impossible de se connecter à la base de données."); }
            }
        }

        private static bool CheckConnection()
        {
            try
            {
                lazy.Value.Database.Connection.Open();
                lazy.Value.Database.Connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //}
    }

    // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
    // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.
}