using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLayer
{
    public static class Repository
    {
        public static ApprenantRepository Apprenant { get; set; } = new ApprenantRepository();
        public static ArchivageSessionRepository ArchivageSession { get; set; } = new ArchivageSessionRepository();
        public static BatimentRepository Batiment { get; set; } = new BatimentRepository();
        public static FormateurRepository Formateur { get; set; } = new FormateurRepository();
        public static FormationFormateurRepository FormationFormateur { get; set; } = new FormationFormateurRepository();
        public static FormationRepository Formation { get; set; } = new FormationRepository();
        public static JourRepository Jour { get; set; } = new JourRepository();
        public static JourSessionRepository JourSession { get; set; } = new JourSessionRepository();
        public static MaterielFormationRepository MaterielFormation { get; set; } = new MaterielFormationRepository();
        public static MaterielRepository Materiel { get; set; } = new MaterielRepository();
        public static RoleUtilisateurRepository RoleUtilisateur { get; set; } = new RoleUtilisateurRepository();
        public static SalleRepository Salle { get; set; } = new SalleRepository();
        public static SessionApprenantRepository SessionApprenant { get; set; } = new SessionApprenantRepository();
        public static SessionFormateurRepository SessionFormateur { get; set; } = new SessionFormateurRepository();
        public static SessionRepository Session { get; set; } = new SessionRepository();
        public static StockMaterielRepository StockMateriel { get; set; } = new StockMaterielRepository();
        public static DomaineFormationRepository DomaineFormation { get; set; } = new DomaineFormationRepository();
        public static UtilisateurRepository Utilisateur { get; set; } = new UtilisateurRepository();
    }
}
