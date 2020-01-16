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
        public static FormationRepository Formations { get; set; } = new FormationRepository();
        public static JourRepository Jours { get; set; } = new JourRepository();
        public static MaterielRepository Materiels { get; set; } = new MaterielRepository();
        public static RoleUtilisateurRepository RoleUtilisateurs { get; set; } = new RoleUtilisateurRepository();
        public static SalleRepository Salles { get; set; } = new SalleRepository();
        public static SessionRepository Sessions { get; set; } = new SessionRepository();
        public static TypeFormationRepository TypeFormations { get; set; } = new TypeFormationRepository();
        public static UtilisateurRepository Utilisateurs { get; set; } = new UtilisateurRepository();
    }
}
