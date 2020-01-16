namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Annotation_0 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.APPRENANT", "Nom", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.APPRENANT", "Prenom", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.FORMATION", "Intitule", c => c.String(nullable: false, maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.FORMATEUR", "Nom", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.FORMATEUR", "Prenom", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.MATERIEL", "Designation", c => c.String(nullable: false, maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.SALLE", "Designation", c => c.String(nullable: false, maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.BATIMENT", "Designation", c => c.String(nullable: false, maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.TYPE_FORMATION", "Designation", c => c.String(nullable: false, maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.ARCHIVAGE_SESSION", "Description", c => c.String(nullable: false, maxLength: 100, storeType: "nvarchar"));
            AlterColumn("dbo.UTILISATEUR", "Prenom", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.UTILISATEUR", "Nom", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.UTILISATEUR", "NomUtilisateur", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.UTILISATEUR", "MotDePasse", c => c.String(nullable: false, maxLength: 50, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UTILISATEUR", "MotDePasse", c => c.String(unicode: false));
            AlterColumn("dbo.UTILISATEUR", "NomUtilisateur", c => c.String(unicode: false));
            AlterColumn("dbo.UTILISATEUR", "Nom", c => c.String(unicode: false));
            AlterColumn("dbo.UTILISATEUR", "Prenom", c => c.String(unicode: false));
            AlterColumn("dbo.ARCHIVAGE_SESSION", "Description", c => c.String(unicode: false));
            AlterColumn("dbo.TYPE_FORMATION", "Designation", c => c.String(unicode: false));
            AlterColumn("dbo.BATIMENT", "Designation", c => c.String(unicode: false));
            AlterColumn("dbo.SALLE", "Designation", c => c.String(unicode: false));
            AlterColumn("dbo.MATERIEL", "Designation", c => c.String(unicode: false));
            AlterColumn("dbo.FORMATEUR", "Prenom", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.FORMATEUR", "Nom", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.FORMATION", "Intitule", c => c.String(unicode: false));
            AlterColumn("dbo.APPRENANT", "Prenom", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.APPRENANT", "Nom", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
    }
}
