using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.AccessLayer
{
    public static class SeedDB
    {
        public static void Seed(DBContext dBContext)
        {
            //#region Formations
            //List<TypeFormation> typesFormation = new List<TypeFormation>
            //{
            //    new TypeFormation() { Designation = "Architecture"},
            //    new TypeFormation() { Designation = "Artisanat Bâtiment"},
            //    new TypeFormation() { Designation = "Droit - Justice"},
            //    new TypeFormation() { Designation = "Informatique"},
            //    new TypeFormation() { Designation = "Sport"},
            //};
            //typesFormation.ForEach(tf => tf = dBContext.TypesFormation.Add(tf));
            //dBContext.SaveChanges();

            //List<Formation> formations = new List<Formation>
            //{
            //    new Formation() { Intitule = "Mastère Architecture Intérieure / Design", TypeFormation = typesFormation[0], NbJours = 5, EstActif = true},
            //    new Formation() { Intitule = "Mastère Design Global", TypeFormation = typesFormation[0], NbJours = 45, EstActif = true},

            //    new Formation() { Intitule = "CAP Tailleur de pierre", TypeFormation = typesFormation[1], NbJours = 100, EstActif = true},
            //    new Formation() { Intitule = "CAP Maçon", TypeFormation = typesFormation[1], NbJours = 77, EstActif = true},

            //    new Formation() { Intitule = "Master Droit et Gestion de la santé", TypeFormation = typesFormation[2], NbJours = 600, EstActif = true},
            //    new Formation() { Intitule = "Master 1 Droit des affaires", TypeFormation = typesFormation[2], NbJours = 35, EstActif = true},

            //    new Formation() { Intitule = "Master Administrateur Systèmes et Réseaux", TypeFormation = typesFormation[3], NbJours = 10, EstActif = true},
            //    new Formation() { Intitule = "Développeur WEB", TypeFormation = typesFormation[3], NbJours = 20, EstActif = true},

            //    new Formation() { Intitule = "Bachelor Management du sport", TypeFormation = typesFormation[4], NbJours = 60, EstActif = true},
            //    new Formation() { Intitule = "Bachelor 3 Commerce du sport", TypeFormation = typesFormation[4], NbJours = 420, EstActif = true},
            //};
            //formations.ForEach(f => f = dBContext.Formations.Add(f));
            //dBContext.SaveChanges();
            //#endregion

            //#region Lieux & Biens
            //List<Adresse> adresses = new List<Adresse>
            //{
            //    new Adresse(){ Rue = "Appartement 603-6108 Dolor Route", Ville = "Piracicaba", CodePostal = "74335" },
            //    new Adresse() { Rue = "6250 Enim, Chemin", Ville = "Schwedt", CodePostal = "91321" },
            //    new Adresse() { Rue = "747-2534 Non, Route", Ville = "Green Bay", CodePostal = "55562" },
            //    new Adresse() { Rue = "5334 Volutpat. Route", Ville = "Drachten", CodePostal = "91941" },
            //    new Adresse() { Rue = "CP 796, 8883 Leo. Impasse", Ville = "Champdani", CodePostal = "37156" },
            //    new Adresse() { Rue = "CP 601, 7860 Enim. Ave", Ville = "Daska", CodePostal = "33453" },
            //    new Adresse() { Rue = "1390 Curabitur Rue", Ville = "Oostakker", CodePostal = "18687" },
            //    new Adresse() { Rue = "Appartement 876-3042 Diam Route", Ville = "Malahide", CodePostal = "85584" },
            //    new Adresse() { Rue = "1551 At, Chemin", Ville = "Gorbea", CodePostal = "27891" },
            //    new Adresse() { Rue = "445-6353 Eget Route", Ville = "Livo", CodePostal = "37211" },
            //    new Adresse() { Rue = "Appartement 464-5590 Mi Ave", Ville = "Gwangju", CodePostal = "18940" },
            //    new Adresse() { Rue = "572-8296 Sed Chemin", Ville = "Rance", CodePostal = "22769" },
            //    new Adresse() { Rue = "CP 335, 346 A Av.", Ville = "Victoria", CodePostal = "85550" },
            //    new Adresse() { Rue = "Appartement 352-7338 Suspendisse Av.", Ville = "Quillón", CodePostal = "12489" },
            //    new Adresse() { Rue = "804 Gravida Rue", Ville = "Oevel", CodePostal = "72703" }
            //};

            //List<Batiment> batiments = new List<Batiment>
            //{
            //    new Batiment(){Designation = "Bâtiment 1", Adresse = adresses[0], Salles = null},
            //    new Batiment(){Designation = "Bâtiment 2", Adresse = adresses[1], Salles = null},
            //    new Batiment(){Designation = "Bâtiment 3", Adresse = adresses[2], Salles = null},
            //    new Batiment(){Designation = "Bâtiment 4", Adresse = adresses[3], Salles = null},
            //    new Batiment(){Designation = "Bâtiment 5", Adresse = adresses[4], Salles = null}
            //};
            //batiments.ForEach(b => b = dBContext.Batiments.Add(b));
            //dBContext.SaveChanges();

            //List<Salle> salles = new List<Salle>
            //{
            //    new Salle(){Designation = "Salle 1", Batiment = batiments[0]},

            //    new Salle(){Designation = "Salle 1", Batiment = batiments[1]},
            //    new Salle(){Designation = "Salle 2", Batiment = batiments[1]},

            //    new Salle(){Designation = "Salle 1", Batiment = batiments[2]},
            //    new Salle(){Designation = "Salle 2", Batiment = batiments[2]},
            //    new Salle(){Designation = "Salle 3", Batiment = batiments[2]},

            //    new Salle(){Designation = "Salle 1", Batiment = batiments[3]},
            //    new Salle(){Designation = "Salle 2", Batiment = batiments[3]},
            //    new Salle(){Designation = "Salle 3", Batiment = batiments[3]},
            //    new Salle(){Designation = "Salle 4", Batiment = batiments[3]},

            //    new Salle(){Designation = "Salle 1", Batiment = batiments[4]},
            //    new Salle(){Designation = "Salle 2", Batiment = batiments[4]},
            //    new Salle(){Designation = "Salle 3", Batiment = batiments[4]},
            //    new Salle(){Designation = "Salle 4", Batiment = batiments[4]},
            //    new Salle(){Designation = "Salle 5", Batiment = batiments[4]}
            //};
            //salles.ForEach(s => s = dBContext.Salles.Add(s));
            //dBContext.SaveChanges();

            //List<Materiel> materiels = new List<Materiel>
            //{
            //    new Materiel(){Designation = "Compas", EstActif = true, MaterielRequisFormation = null, StockMateriels = null},
            //    new Materiel(){Designation = "Marteau", EstActif = true, MaterielRequisFormation = null, StockMateriels = null},
            //    new Materiel(){Designation = "Livre de droit", EstActif = true, MaterielRequisFormation = null, StockMateriels = null},
            //    new Materiel(){Designation = "Ordinateur", EstActif = true, MaterielRequisFormation = null, StockMateriels = null},
            //    new Materiel(){Designation = "Sifflet", EstActif = true, MaterielRequisFormation = null, StockMateriels = null}

            //};
            //materiels.ForEach(m => m = dBContext.Materiels.Add(m));
            //dBContext.SaveChanges();

            //List<MaterielRequisFormation> materielRequisFormations = new List<MaterielRequisFormation>
            //{
            //    new MaterielRequisFormation(){Formations = new List<Formation>(){formations[0], formations[1]}, Materiels = new List<Materiel>{materiels[0]}},
            //    new MaterielRequisFormation(){Formations = new List<Formation>(){formations[2], formations[3]}, Materiels = new List<Materiel>{materiels[1]}},
            //    new MaterielRequisFormation(){Formations = new List<Formation>(){formations[4], formations[5]}, Materiels = new List<Materiel>{materiels[2]}},
            //    new MaterielRequisFormation(){Formations = new List<Formation>(){formations[6], formations[7]}, Materiels = new List<Materiel>{materiels[3]}},
            //    new MaterielRequisFormation(){Formations = new List<Formation>(){formations[8], formations[9]}, Materiels = new List<Materiel>{materiels[4]}}
            //};
            //materielRequisFormations.ForEach(mfr => mfr = dBContext.MaterielsRequisFormation.Add(mfr));
            //dBContext.SaveChanges();

            //List<List<StockMateriel>> materielsStockes = new List<List<StockMateriel>>()
            //{
            //    new List<StockMateriel>()
            //    {
            //        new StockMateriel() { Materiel = materiels[0], Salle = salles[0], Quantite = 5}
            //    },
            //    new List<StockMateriel>()
            //    {
            //        new StockMateriel() { Materiel = materiels[0], Salle = salles[1], Quantite = 10},
            //        new StockMateriel() { Materiel = materiels[1], Salle = salles[1], Quantite = 15}
            //    },
            //    new List<StockMateriel>()
            //    {
            //        new StockMateriel() { Materiel = materiels[0], Salle = salles[3], Quantite = 25},
            //        new StockMateriel() { Materiel = materiels[1], Salle = salles[3], Quantite = 30},
            //        new StockMateriel() { Materiel = materiels[2], Salle = salles[3], Quantite = 5}
            //    },
            //    new List<StockMateriel>()
            //    {
            //        new StockMateriel() { Materiel = materiels[0], Salle = salles[6], Quantite = 15},
            //        new StockMateriel() { Materiel = materiels[1], Salle = salles[6], Quantite = 5},
            //        new StockMateriel() { Materiel = materiels[2], Salle = salles[6], Quantite = 20},
            //        new StockMateriel() { Materiel = materiels[3], Salle = salles[6], Quantite = 35}
            //    },
            //    new List<StockMateriel>()
            //    {
            //        new StockMateriel() { Materiel = materiels[0], Salle = salles[10], Quantite = 5},
            //        new StockMateriel() { Materiel = materiels[1], Salle = salles[10], Quantite = 10},
            //        new StockMateriel() { Materiel = materiels[2], Salle = salles[10], Quantite = 10},
            //        new StockMateriel() { Materiel = materiels[3], Salle = salles[10], Quantite = 15},
            //        new StockMateriel() { Materiel = materiels[4], Salle = salles[10], Quantite = 20}
            //    }
            //};

            //materiels[0].MaterielRequisFormation = materielRequisFormations[0];
            //materiels[0].StockMateriels = materielsStockes[0];
            //salles[0].StockMateriels = materielsStockes[0];

            //materiels[1].MaterielRequisFormation = materielRequisFormations[1];
            //materiels[1].StockMateriels = materielsStockes[1];
            //salles[1].StockMateriels = materielsStockes[1];

            //materiels[2].MaterielRequisFormation = materielRequisFormations[2];
            //materiels[2].StockMateriels = materielsStockes[2];
            //salles[3].StockMateriels = materielsStockes[2];

            //materiels[3].MaterielRequisFormation = materielRequisFormations[3];
            //materiels[3].StockMateriels = materielsStockes[3];
            //salles[6].StockMateriels = materielsStockes[3];

            //materiels[4].MaterielRequisFormation = materielRequisFormations[4];
            //materiels[4].StockMateriels = materielsStockes[4];
            //salles[10].StockMateriels = materielsStockes[4];
            //dBContext.SaveChanges();
            //#endregion

            //#region Personnes
            //List<Apprenant> apprenants = new List<Apprenant>
            //{
            //    new Apprenant(){ Adresse = adresses[5], Civilite = EEnum.ECivilite.Monsieur, EstActif = true, Nom = "Dejesus", Prenom = "Bruno", DateNaissance = DateTime.ParseExact("01/18/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "Madagascar", Nationalite = "Comoros", NumeroPortable = "06 25 82 75 58", NumeroDomicile = "02 97 42 19 88", AdresseMail = "felis.adipiscing.fringilla@necante.com" },
            //    new Apprenant(){ Adresse = adresses[6], Civilite = EEnum.ECivilite.Madame, EstActif = true, Nom = "Walton", Prenom = "Callie", DateNaissance = DateTime.ParseExact("07/07/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "Niue", Nationalite = "Tajikistan", NumeroPortable = "06 22 20 96 40", NumeroDomicile = "02 58 51 32 53", AdresseMail = "massa.Vestibulum.accumsan@hendreritneque.org" },
            //    new Apprenant(){ Adresse = adresses[7], Civilite = EEnum.ECivilite.Monsieur, EstActif = true, Nom = "Albert", Prenom = "Kylyan", DateNaissance = DateTime.ParseExact("05/28/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "Maldives", Nationalite = "Virgin Islands, British", NumeroPortable = "06 64 01 83 41", NumeroDomicile = "02 70 45 29 32", AdresseMail = "sed.est.Nunc@liberoProinmi.ca" },
            //    new Apprenant(){ Adresse = adresses[8], Civilite = EEnum.ECivilite.Madame, EstActif = true, Nom = "Leblanc", Prenom = "Iola", DateNaissance = DateTime.ParseExact("03/30/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "Gabon", Nationalite = "Cameroon", NumeroPortable = "06 42 16 58 39", NumeroDomicile = "02 11 94 67 80", AdresseMail = "Sed.diam.lorem@vulputateeu.net" },
            //    new Apprenant(){ Adresse = adresses[9], Civilite = EEnum.ECivilite.Madame, EstActif = true, Nom = "Bender", Prenom = "Lara", DateNaissance = DateTime.ParseExact("05/14/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "Monaco", Nationalite = "Austria", NumeroPortable = "06 13 97 54 50", NumeroDomicile = "02 03 22 95 81", AdresseMail = "suscipit.nonummy@nec.net" }
            //};
            //apprenants.ForEach(a => a = dBContext.Apprenants.Add(a));
            //dBContext.SaveChanges();

            //List<List<Formation>> formationsDelivrables = new List<List<Formation>>()
            //{
            //    new List<Formation>(){ formations[0], formations[1]},
            //    new List<Formation>(){ formations[2], formations[3]},
            //    new List<Formation>(){ formations[4], formations[5]},
            //    new List<Formation>(){ formations[6], formations[7],formations[0], formations[1]},
            //    new List<Formation>(){ formations[8], formations[9], formations[2], formations[3] ,formations[4], formations[5]}
            //};

            //List<Formateur> formateurs = new List<Formateur>
            //{
            //    new Formateur(){ Formations = formationsDelivrables[0], Adresse = adresses[10], Civilite = EEnum.ECivilite.Madame, EstActif = true, Nom = "Ayers", Prenom = "Gwendolyn", DateNaissance = DateTime.ParseExact("02/08/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "United States Minor Outlying Islands", Nationalite = "Iraq", NumeroPortable = "06 33 83 42 02", NumeroDomicile = "02 26 02 34 15", AdresseMail = "senectus.et@Aliquam.ca" },
            //    new Formateur(){ Formations = formationsDelivrables[1], Adresse = adresses[11], Civilite = EEnum.ECivilite.Monsieur, EstActif = true, Nom = "Gomez", Prenom = "Timon", DateNaissance = DateTime.ParseExact("07/11/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "Colombia", Nationalite = "Netherlands", NumeroPortable = "06 57 08 88 66", NumeroDomicile = "02 47 88 34 13", AdresseMail = "orci.tincidunt@ultriciessemmagna.edu" },
            //    new Formateur(){ Formations = formationsDelivrables[2], Adresse = adresses[12], Civilite = EEnum.ECivilite.Madame, EstActif = true, Nom = "Shepard", Prenom = "Gloria", DateNaissance = DateTime.ParseExact("12/14/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "Malawi", Nationalite = "Isle of Man", NumeroPortable = "06 42 79 31 53", NumeroDomicile = "02 25 85 71 38", AdresseMail = "dolor@mattissemper.co.uk" },
            //    new Formateur(){ Formations = formationsDelivrables[3], Adresse = adresses[13], Civilite = EEnum.ECivilite.Monsieur, EstActif = true, Nom = "Conway", Prenom = "Georges", DateNaissance = DateTime.ParseExact("12/10/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "China", Nationalite = "Israel", NumeroPortable = "06 00 72 49 49", NumeroDomicile = "02 88 52 36 93", AdresseMail = "tortor.dictum.eu@iaculis.ca" },
            //    new Formateur(){ Formations = formationsDelivrables[4], Adresse = adresses[14], Civilite = EEnum.ECivilite.Madame, EstActif = true, Nom = "Rodriguez", Prenom = "Claudia", DateNaissance = DateTime.ParseExact("05/09/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "Virgin Islands, United States", Nationalite = "Guam", NumeroPortable = "06 92 33 50 68", NumeroDomicile = "02 38 39 83 61", AdresseMail = "eu.nibh.vulputate@liberoduinec.org" }
            //};
            //formateurs.ForEach(f => f = dBContext.Formateurs.Add(f));
            //dBContext.SaveChanges();
            //#endregion

            //#region Sessions
            // Jour
            // JourSession
            // Session
            //#endregion

        }
    }
}
