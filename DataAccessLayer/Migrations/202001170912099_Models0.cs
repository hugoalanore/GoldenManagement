namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Models0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.APPRENANT",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EstActif = c.Boolean(nullable: false),
                        Civilite = c.Int(nullable: false),
                        Nom = c.String(maxLength: 50, storeType: "nvarchar"),
                        Prenom = c.String(maxLength: 50, storeType: "nvarchar"),
                        DateNaissance = c.DateTime(nullable: false, precision: 0),
                        LieuNaissance = c.String(unicode: false),
                        Nationalite = c.String(unicode: false),
                        Rue = c.String(unicode: false),
                        Ville = c.String(unicode: false),
                        CodePostal = c.String(unicode: false),
                        NumeroPortable = c.String(unicode: false),
                        NumeroDomicile = c.String(unicode: false),
                        AdresseMail = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SESSION_APPRENANT",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Apprenant_Id = c.Int(),
                        Session_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.APPRENANT", t => t.Apprenant_Id)
                .ForeignKey("dbo.SESSION", t => t.Session_Id)
                .Index(t => t.Apprenant_Id)
                .Index(t => t.Session_Id);
            
            CreateTable(
                "dbo.SESSION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Formation_Id = c.Int(),
                        Salle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FORMATION", t => t.Formation_Id)
                .ForeignKey("dbo.SALLE", t => t.Salle_Id)
                .Index(t => t.Formation_Id)
                .Index(t => t.Salle_Id);
            
            CreateTable(
                "dbo.FORMATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Intitule = c.String(unicode: false),
                        NbJours = c.Int(nullable: false),
                        EstActif = c.Boolean(nullable: false),
                        TypeFormation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TYPE_FORMATION", t => t.TypeFormation_Id)
                .Index(t => t.TypeFormation_Id);
            
            CreateTable(
                "dbo.FORMATION_FORMATEUR",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Formateur_Id = c.Int(),
                        Formation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FORMATEUR", t => t.Formateur_Id)
                .ForeignKey("dbo.FORMATION", t => t.Formation_Id)
                .Index(t => t.Formateur_Id)
                .Index(t => t.Formation_Id);
            
            CreateTable(
                "dbo.FORMATEUR",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EstActif = c.Boolean(nullable: false),
                        Civilite = c.Int(nullable: false),
                        Nom = c.String(maxLength: 50, storeType: "nvarchar"),
                        Prenom = c.String(maxLength: 50, storeType: "nvarchar"),
                        DateNaissance = c.DateTime(nullable: false, precision: 0),
                        LieuNaissance = c.String(unicode: false),
                        Nationalite = c.String(unicode: false),
                        Rue = c.String(unicode: false),
                        Ville = c.String(unicode: false),
                        CodePostal = c.String(unicode: false),
                        NumeroPortable = c.String(unicode: false),
                        NumeroDomicile = c.String(unicode: false),
                        AdresseMail = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SESSION_FORMATEUR",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Formateur_Id = c.Int(),
                        Session_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FORMATEUR", t => t.Formateur_Id)
                .ForeignKey("dbo.SESSION", t => t.Session_Id)
                .Index(t => t.Formateur_Id)
                .Index(t => t.Session_Id);
            
            CreateTable(
                "dbo.MATERIEL_FORMATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Formation_Id = c.Int(),
                        Materiel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FORMATION", t => t.Formation_Id)
                .ForeignKey("dbo.MATERIEL", t => t.Materiel_Id)
                .Index(t => t.Formation_Id)
                .Index(t => t.Materiel_Id);
            
            CreateTable(
                "dbo.MATERIEL",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(unicode: false),
                        EstActif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.STOCK_MATERIEL",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantite = c.Int(nullable: false),
                        Materiel_Id = c.Int(),
                        Salle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MATERIEL", t => t.Materiel_Id)
                .ForeignKey("dbo.SALLE", t => t.Salle_Id)
                .Index(t => t.Materiel_Id)
                .Index(t => t.Salle_Id);
            
            CreateTable(
                "dbo.SALLE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EstActif = c.Boolean(nullable: false),
                        Designation = c.String(unicode: false),
                        Batiment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BATIMENT", t => t.Batiment_Id)
                .Index(t => t.Batiment_Id);
            
            CreateTable(
                "dbo.BATIMENT",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EstActif = c.Boolean(nullable: false),
                        Designation = c.String(unicode: false),
                        Rue = c.String(unicode: false),
                        Ville = c.String(unicode: false),
                        CodePostal = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TYPE_FORMATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EstActif = c.Boolean(nullable: false),
                        Designation = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JOUR_SESSION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Jour_Id = c.Int(),
                        Session_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JOUR", t => t.Jour_Id)
                .ForeignKey("dbo.SESSION", t => t.Session_Id)
                .Index(t => t.Jour_Id)
                .Index(t => t.Session_Id);
            
            CreateTable(
                "dbo.JOUR",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ARCHIVAGE_SESSION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ROLE_UTILISATEUR",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UTILISATEUR",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prenom = c.String(unicode: false),
                        Nom = c.String(unicode: false),
                        NomUtilisateur = c.String(unicode: false),
                        MotDePasse = c.String(unicode: false),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ROLE_UTILISATEUR", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UTILISATEUR", "Role_Id", "dbo.ROLE_UTILISATEUR");
            DropForeignKey("dbo.SESSION_APPRENANT", "Session_Id", "dbo.SESSION");
            DropForeignKey("dbo.SESSION", "Salle_Id", "dbo.SALLE");
            DropForeignKey("dbo.JOUR_SESSION", "Session_Id", "dbo.SESSION");
            DropForeignKey("dbo.JOUR_SESSION", "Jour_Id", "dbo.JOUR");
            DropForeignKey("dbo.FORMATION", "TypeFormation_Id", "dbo.TYPE_FORMATION");
            DropForeignKey("dbo.SESSION", "Formation_Id", "dbo.FORMATION");
            DropForeignKey("dbo.STOCK_MATERIEL", "Salle_Id", "dbo.SALLE");
            DropForeignKey("dbo.SALLE", "Batiment_Id", "dbo.BATIMENT");
            DropForeignKey("dbo.STOCK_MATERIEL", "Materiel_Id", "dbo.MATERIEL");
            DropForeignKey("dbo.MATERIEL_FORMATION", "Materiel_Id", "dbo.MATERIEL");
            DropForeignKey("dbo.MATERIEL_FORMATION", "Formation_Id", "dbo.FORMATION");
            DropForeignKey("dbo.FORMATION_FORMATEUR", "Formation_Id", "dbo.FORMATION");
            DropForeignKey("dbo.SESSION_FORMATEUR", "Session_Id", "dbo.SESSION");
            DropForeignKey("dbo.SESSION_FORMATEUR", "Formateur_Id", "dbo.FORMATEUR");
            DropForeignKey("dbo.FORMATION_FORMATEUR", "Formateur_Id", "dbo.FORMATEUR");
            DropForeignKey("dbo.SESSION_APPRENANT", "Apprenant_Id", "dbo.APPRENANT");
            DropIndex("dbo.UTILISATEUR", new[] { "Role_Id" });
            DropIndex("dbo.JOUR_SESSION", new[] { "Session_Id" });
            DropIndex("dbo.JOUR_SESSION", new[] { "Jour_Id" });
            DropIndex("dbo.SALLE", new[] { "Batiment_Id" });
            DropIndex("dbo.STOCK_MATERIEL", new[] { "Salle_Id" });
            DropIndex("dbo.STOCK_MATERIEL", new[] { "Materiel_Id" });
            DropIndex("dbo.MATERIEL_FORMATION", new[] { "Materiel_Id" });
            DropIndex("dbo.MATERIEL_FORMATION", new[] { "Formation_Id" });
            DropIndex("dbo.SESSION_FORMATEUR", new[] { "Session_Id" });
            DropIndex("dbo.SESSION_FORMATEUR", new[] { "Formateur_Id" });
            DropIndex("dbo.FORMATION_FORMATEUR", new[] { "Formation_Id" });
            DropIndex("dbo.FORMATION_FORMATEUR", new[] { "Formateur_Id" });
            DropIndex("dbo.FORMATION", new[] { "TypeFormation_Id" });
            DropIndex("dbo.SESSION", new[] { "Salle_Id" });
            DropIndex("dbo.SESSION", new[] { "Formation_Id" });
            DropIndex("dbo.SESSION_APPRENANT", new[] { "Session_Id" });
            DropIndex("dbo.SESSION_APPRENANT", new[] { "Apprenant_Id" });
            DropTable("dbo.UTILISATEUR");
            DropTable("dbo.ROLE_UTILISATEUR");
            DropTable("dbo.ARCHIVAGE_SESSION");
            DropTable("dbo.JOUR");
            DropTable("dbo.JOUR_SESSION");
            DropTable("dbo.TYPE_FORMATION");
            DropTable("dbo.BATIMENT");
            DropTable("dbo.SALLE");
            DropTable("dbo.STOCK_MATERIEL");
            DropTable("dbo.MATERIEL");
            DropTable("dbo.MATERIEL_FORMATION");
            DropTable("dbo.SESSION_FORMATEUR");
            DropTable("dbo.FORMATEUR");
            DropTable("dbo.FORMATION_FORMATEUR");
            DropTable("dbo.FORMATION");
            DropTable("dbo.SESSION");
            DropTable("dbo.SESSION_APPRENANT");
            DropTable("dbo.APPRENANT");
        }
    }
}
