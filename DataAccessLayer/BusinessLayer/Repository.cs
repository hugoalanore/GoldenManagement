using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLayer
{
    public static class Repository
    {
        public static ApprenantRepository Apprenants { get; set; } = new ApprenantRepository();
        public static ArchivageSessionRepository ArchivageSessions { get; set; } = new ArchivageSessionRepository();
        public static BatimentRepository Batiments { get; set; } = new BatimentRepository();
        public static FormateurRepository Formateurs { get; set; } = new FormateurRepository();
        public static FormationFormateurRepository FormationFormateurs { get; set; } = new FormationFormateurRepository();
        public static FormationRepository Formations { get; set; } = new FormationRepository();
        public static JourRepository Jours { get; set; } = new JourRepository();
        public static JourSessionRepository JourSessions { get; set; } = new JourSessionRepository();
        public static MaterielFormationRepository MaterielFormations { get; set; } = new MaterielFormationRepository();
        public static MaterielRepository Materiels { get; set; } = new MaterielRepository();
        public static RoleUtilisateurRepository RoleUtilisateurs { get; set; } = new RoleUtilisateurRepository();
        public static SalleRepository Salles { get; set; } = new SalleRepository();
        public static SessionApprenantRepository SessionApprenants { get; set; } = new SessionApprenantRepository();
        public static SessionFormateurRepository SessionFormateurs { get; set; } = new SessionFormateurRepository();
        public static SessionRepository Sessions { get; set; } = new SessionRepository();
        public static StockMaterielRepository StockMateriels { get; set; } = new StockMaterielRepository();
        public static TypeFormationRepository TypeFormations { get; set; } = new TypeFormationRepository();
        public static UtilisateurRepository Utilisateurs { get; set; } = new UtilisateurRepository();
    }
}
