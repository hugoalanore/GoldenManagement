using DataAccessLayer.BusinessLayer;
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
        public static void Seed()
        {
            #region Formations
            List<TypeFormation> typesFormation = new List<TypeFormation>
            {
                new TypeFormation() { Designation = "Architecture"},
                new TypeFormation() { Designation = "Artisanat Bâtiment"},
                new TypeFormation() { Designation = "Droit - Justice"},
                new TypeFormation() { Designation = "Informatique"},
                new TypeFormation() { Designation = "Sport"},
            };
            typesFormation.ForEach(tf => tf = Repository.TypeFormations.Create(tf));

            List<Formation> formations = new List<Formation>
            {
                new Formation() { Intitule = "Mastère Architecture Intérieure / Design", TypeFormation = typesFormation[0], NbJours = 5, EstActif = true},
                new Formation() { Intitule = "Mastère Design Global", TypeFormation = typesFormation[0], NbJours = 45, EstActif = true},

                new Formation() { Intitule = "CAP Tailleur de pierre", TypeFormation = typesFormation[1], NbJours = 100, EstActif = true},
                new Formation() { Intitule = "CAP Maçon", TypeFormation = typesFormation[1], NbJours = 77, EstActif = true},

                new Formation() { Intitule = "Master Droit et Gestion de la santé", TypeFormation = typesFormation[2], NbJours = 600, EstActif = true},
                new Formation() { Intitule = "Master 1 Droit des affaires", TypeFormation = typesFormation[2], NbJours = 35, EstActif = true},

                new Formation() { Intitule = "Master Administrateur Systèmes et Réseaux", TypeFormation = typesFormation[3], NbJours = 10, EstActif = true},
                new Formation() { Intitule = "Développeur WEB", TypeFormation = typesFormation[3], NbJours = 20, EstActif = true},

                new Formation() { Intitule = "Bachelor Management du sport", TypeFormation = typesFormation[4], NbJours = 60, EstActif = true},
                new Formation() { Intitule = "Bachelor 3 Commerce du sport", TypeFormation = typesFormation[4], NbJours = 420, EstActif = true},
            };
            formations.ForEach(f => f = Repository.Formations.Create(f));
            #endregion

            #region Lieux
            List<Adresse> adresses = new List<Adresse>
            {
                new Adresse(){ Rue = "Appartement 603-6108 Dolor Route", Ville = "Piracicaba", CodePostal = "74335" },
                new Adresse() { Rue = "6250 Enim, Chemin", Ville = "Schwedt", CodePostal = "91321" },
                new Adresse() { Rue = "747-2534 Non, Route", Ville = "Green Bay", CodePostal = "55562" },
                new Adresse() { Rue = "5334 Volutpat. Route", Ville = "Drachten", CodePostal = "91941" },
                new Adresse() { Rue = "CP 796, 8883 Leo. Impasse", Ville = "Champdani", CodePostal = "37156" },
                new Adresse() { Rue = "CP 601, 7860 Enim. Ave", Ville = "Daska", CodePostal = "33453" },
                new Adresse() { Rue = "1390 Curabitur Rue", Ville = "Oostakker", CodePostal = "18687" },
                new Adresse() { Rue = "Appartement 876-3042 Diam Route", Ville = "Malahide", CodePostal = "85584" },
                new Adresse() { Rue = "1551 At, Chemin", Ville = "Gorbea", CodePostal = "27891" },
                new Adresse() { Rue = "445-6353 Eget Route", Ville = "Livo", CodePostal = "37211" },
                new Adresse() { Rue = "Appartement 464-5590 Mi Ave", Ville = "Gwangju", CodePostal = "18940" },
                new Adresse() { Rue = "572-8296 Sed Chemin", Ville = "Rance", CodePostal = "22769" },
                new Adresse() { Rue = "CP 335, 346 A Av.", Ville = "Victoria", CodePostal = "85550" },
                new Adresse() { Rue = "Appartement 352-7338 Suspendisse Av.", Ville = "Quillón", CodePostal = "12489" },
                new Adresse() { Rue = "804 Gravida Rue", Ville = "Oevel", CodePostal = "72703" }
            };

            List<Batiment> batiments = new List<Batiment>
            {
                new Batiment(){Designation = "Bâtiment 1", Adresse = adresses[0], Salles = null, EstActif = true},
                new Batiment(){Designation = "Bâtiment 2", Adresse = adresses[1], Salles = null, EstActif = true},
                new Batiment(){Designation = "Bâtiment 3", Adresse = adresses[2], Salles = null, EstActif = true},
                new Batiment(){Designation = "Bâtiment 4", Adresse = adresses[3], Salles = null, EstActif = true},
                new Batiment(){Designation = "Bâtiment 5", Adresse = adresses[4], Salles = null, EstActif = true}
            };
            batiments.ForEach(b => b = Repository.Batiments.Create(b));

            List<Salle> salles = new List<Salle>
            {
                new Salle(){Designation = "Salle 1", Batiment = batiments[0], EstActif = true},

                new Salle(){Designation = "Salle 1", Batiment = batiments[1], EstActif = true},
                new Salle(){Designation = "Salle 2", Batiment = batiments[1], EstActif = true},

                new Salle(){Designation = "Salle 1", Batiment = batiments[2], EstActif = true},
                new Salle(){Designation = "Salle 2", Batiment = batiments[2], EstActif = true},
                new Salle(){Designation = "Salle 3", Batiment = batiments[2], EstActif = true},

                new Salle(){Designation = "Salle 1", Batiment = batiments[3], EstActif = true},
                new Salle(){Designation = "Salle 2", Batiment = batiments[3], EstActif = true},
                new Salle(){Designation = "Salle 3", Batiment = batiments[3], EstActif = true},
                new Salle(){Designation = "Salle 4", Batiment = batiments[3], EstActif = true},

                new Salle(){Designation = "Salle 1", Batiment = batiments[4], EstActif = true},
                new Salle(){Designation = "Salle 2", Batiment = batiments[4], EstActif = true},
                new Salle(){Designation = "Salle 3", Batiment = batiments[4], EstActif = true},
                new Salle(){Designation = "Salle 4", Batiment = batiments[4], EstActif = true},
                new Salle(){Designation = "Salle 5", Batiment = batiments[4], EstActif = true}
            };
            salles.ForEach(s => s = Repository.Salles.Create(s));
            #endregion

            #region Biens
            List<Materiel> materiels = new List<Materiel>
            {
                new Materiel(){Designation = "Compas", EstActif = true, MaterielRequisFormations = new List<MaterielFormation>(), StockMateriels = new List<StockMateriel>()},
                new Materiel(){Designation = "Marteau", EstActif = true, MaterielRequisFormations = new List<MaterielFormation>(), StockMateriels = new List<StockMateriel>()},
                new Materiel(){Designation = "Livre de droit", EstActif = true, MaterielRequisFormations = new List<MaterielFormation>(), StockMateriels = new List<StockMateriel>()},
                new Materiel(){Designation = "Ordinateur", EstActif = true, MaterielRequisFormations = new List<MaterielFormation>(), StockMateriels = new List<StockMateriel>()},
                new Materiel(){Designation = "Sifflet", EstActif = true, MaterielRequisFormations = new List<MaterielFormation>(), StockMateriels = new List<StockMateriel>()}

            };
            materiels.ForEach(m => m = Repository.Materiels.Create(m));

            List<MaterielFormation> materielFormations = new List<MaterielFormation>
            {
                new MaterielFormation(){Formation = formations[0], Materiel = materiels[0]},
                new MaterielFormation(){Formation = formations[1], Materiel = materiels[0]},
                new MaterielFormation(){Formation = formations[2], Materiel = materiels[1]},
                new MaterielFormation(){Formation = formations[3], Materiel = materiels[1]},
                new MaterielFormation(){Formation = formations[4], Materiel = materiels[2]},
                new MaterielFormation(){Formation = formations[5], Materiel = materiels[2]},
                new MaterielFormation(){Formation = formations[6], Materiel = materiels[3]},
                new MaterielFormation(){Formation = formations[7], Materiel = materiels[3]},
                new MaterielFormation(){Formation = formations[8], Materiel = materiels[4]},
                new MaterielFormation(){Formation = formations[9], Materiel = materiels[4]}
            };

            Repository.Materiels.GetById(materiels[0].Id).MaterielRequisFormations.Add(materielFormations[0]);
            Repository.Materiels.GetById(materiels[0].Id).MaterielRequisFormations.Add(materielFormations[1]);

            Repository.Materiels.GetById(materiels[1].Id).MaterielRequisFormations.Add(materielFormations[2]);
            Repository.Materiels.GetById(materiels[1].Id).MaterielRequisFormations.Add(materielFormations[3]);

            Repository.Materiels.GetById(materiels[2].Id).MaterielRequisFormations.Add(materielFormations[4]);
            Repository.Materiels.GetById(materiels[2].Id).MaterielRequisFormations.Add(materielFormations[5]);

            Repository.Materiels.GetById(materiels[3].Id).MaterielRequisFormations.Add(materielFormations[6]);
            Repository.Materiels.GetById(materiels[3].Id).MaterielRequisFormations.Add(materielFormations[7]);

            Repository.Materiels.GetById(materiels[4].Id).MaterielRequisFormations.Add(materielFormations[8]);
            Repository.Materiels.GetById(materiels[4].Id).MaterielRequisFormations.Add(materielFormations[9]);

            List<StockMateriel> stockMateriels = new List<StockMateriel>()
            {
                new StockMateriel() { Materiel = materiels[0], Salle = salles[0], Quantite = 5},
                new StockMateriel() { Materiel = materiels[0], Salle = salles[1], Quantite = 10},
                new StockMateriel() { Materiel = materiels[0], Salle = salles[3], Quantite = 25},
                new StockMateriel() { Materiel = materiels[0], Salle = salles[6], Quantite = 15},
                new StockMateriel() { Materiel = materiels[0], Salle = salles[10], Quantite = 5},

                new StockMateriel() { Materiel = materiels[1], Salle = salles[1], Quantite = 15},
                new StockMateriel() { Materiel = materiels[1], Salle = salles[3], Quantite = 30},
                new StockMateriel() { Materiel = materiels[1], Salle = salles[6], Quantite = 5},
                new StockMateriel() { Materiel = materiels[1], Salle = salles[10], Quantite = 10},

                new StockMateriel() { Materiel = materiels[2], Salle = salles[3], Quantite = 5},
                new StockMateriel() { Materiel = materiels[2], Salle = salles[6], Quantite = 20},
                new StockMateriel() { Materiel = materiels[2], Salle = salles[10], Quantite = 10},

                new StockMateriel() { Materiel = materiels[3], Salle = salles[6], Quantite = 35},
                new StockMateriel() { Materiel = materiels[3], Salle = salles[10], Quantite = 15},

                new StockMateriel() { Materiel = materiels[4], Salle = salles[10], Quantite = 20}
            };

            Repository.Materiels.GetById(materiels[0].Id).StockMateriels.Add(stockMateriels[0]);
            Repository.Materiels.GetById(materiels[0].Id).StockMateriels.Add(stockMateriels[1]);
            Repository.Materiels.GetById(materiels[0].Id).StockMateriels.Add(stockMateriels[2]);
            Repository.Materiels.GetById(materiels[0].Id).StockMateriels.Add(stockMateriels[3]);
            Repository.Materiels.GetById(materiels[0].Id).StockMateriels.Add(stockMateriels[4]);

            Repository.Materiels.GetById(materiels[1].Id).StockMateriels.Add(stockMateriels[5]);
            Repository.Materiels.GetById(materiels[1].Id).StockMateriels.Add(stockMateriels[6]);
            Repository.Materiels.GetById(materiels[1].Id).StockMateriels.Add(stockMateriels[7]);
            Repository.Materiels.GetById(materiels[1].Id).StockMateriels.Add(stockMateriels[8]);

            Repository.Materiels.GetById(materiels[2].Id).StockMateriels.Add(stockMateriels[9]);
            Repository.Materiels.GetById(materiels[2].Id).StockMateriels.Add(stockMateriels[10]);
            Repository.Materiels.GetById(materiels[2].Id).StockMateriels.Add(stockMateriels[11]);

            Repository.Materiels.GetById(materiels[3].Id).StockMateriels.Add(stockMateriels[12]);
            Repository.Materiels.GetById(materiels[3].Id).StockMateriels.Add(stockMateriels[13]);

            Repository.Materiels.GetById(materiels[4].Id).StockMateriels.Add(stockMateriels[14]);
            #endregion

            #region Personnes
            List<Apprenant> apprenants = new List<Apprenant>
            {
                new Apprenant(){ SessionApprenants = new List<SessionApprenant>(), Adresse = adresses[5], Civilite = EEnum.ECivilite.Monsieur, EstActif = true, Nom = "Dejesus", Prenom = "Bruno", DateNaissance = DateTime.ParseExact("01/18/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "Madagascar", Nationalite = "Comoros", NumeroPortable = "06 25 82 75 58", NumeroDomicile = "02 97 42 19 88", AdresseMail = "felis.adipiscing.fringilla@necante.com" },
                new Apprenant(){ SessionApprenants = new List<SessionApprenant>(), Adresse = adresses[6], Civilite = EEnum.ECivilite.Madame, EstActif = true, Nom = "Walton", Prenom = "Callie", DateNaissance = DateTime.ParseExact("07/07/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "Niue", Nationalite = "Tajikistan", NumeroPortable = "06 22 20 96 40", NumeroDomicile = "02 58 51 32 53", AdresseMail = "massa.Vestibulum.accumsan@hendreritneque.org" },
                new Apprenant(){ SessionApprenants = new List<SessionApprenant>(), Adresse = adresses[7], Civilite = EEnum.ECivilite.Monsieur, EstActif = true, Nom = "Albert", Prenom = "Kylyan", DateNaissance = DateTime.ParseExact("05/28/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "Maldives", Nationalite = "Virgin Islands, British", NumeroPortable = "06 64 01 83 41", NumeroDomicile = "02 70 45 29 32", AdresseMail = "sed.est.Nunc@liberoProinmi.ca" },
                new Apprenant(){ SessionApprenants = new List<SessionApprenant>(), Adresse = adresses[8], Civilite = EEnum.ECivilite.Madame, EstActif = true, Nom = "Leblanc", Prenom = "Iola", DateNaissance = DateTime.ParseExact("03/30/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "Gabon", Nationalite = "Cameroon", NumeroPortable = "06 42 16 58 39", NumeroDomicile = "02 11 94 67 80", AdresseMail = "Sed.diam.lorem@vulputateeu.net" },
                new Apprenant(){ SessionApprenants = new List<SessionApprenant>(), Adresse = adresses[9], Civilite = EEnum.ECivilite.Madame, EstActif = true, Nom = "Bender", Prenom = "Lara", DateNaissance = DateTime.ParseExact("05/14/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "Monaco", Nationalite = "Austria", NumeroPortable = "06 13 97 54 50", NumeroDomicile = "02 03 22 95 81", AdresseMail = "suscipit.nonummy@nec.net" }
            };
            apprenants.ForEach(a => Repository.Apprenants.Create(a));

            List<Formateur> formateurs = new List<Formateur>
            {
                new Formateur(){ FormationFormateurs = new List<FormationFormateur>(), Adresse = adresses[10], Civilite = EEnum.ECivilite.Madame, EstActif = true, Nom = "Ayers", Prenom = "Gwendolyn", DateNaissance = DateTime.ParseExact("02/08/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "United States Minor Outlying Islands", Nationalite = "Iraq", NumeroPortable = "06 33 83 42 02", NumeroDomicile = "02 26 02 34 15", AdresseMail = "senectus.et@Aliquam.ca" },
                new Formateur(){ FormationFormateurs = new List<FormationFormateur>(), Adresse = adresses[11], Civilite = EEnum.ECivilite.Monsieur, EstActif = true, Nom = "Gomez", Prenom = "Timon", DateNaissance = DateTime.ParseExact("07/11/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "Colombia", Nationalite = "Netherlands", NumeroPortable = "06 57 08 88 66", NumeroDomicile = "02 47 88 34 13", AdresseMail = "orci.tincidunt@ultriciessemmagna.edu" },
                new Formateur(){ FormationFormateurs = new List<FormationFormateur>(), Adresse = adresses[12], Civilite = EEnum.ECivilite.Madame, EstActif = true, Nom = "Shepard", Prenom = "Gloria", DateNaissance = DateTime.ParseExact("12/14/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "Malawi", Nationalite = "Isle of Man", NumeroPortable = "06 42 79 31 53", NumeroDomicile = "02 25 85 71 38", AdresseMail = "dolor@mattissemper.co.uk" },
                new Formateur(){ FormationFormateurs = new List<FormationFormateur>(), Adresse = adresses[13], Civilite = EEnum.ECivilite.Monsieur, EstActif = true, Nom = "Conway", Prenom = "Georges", DateNaissance = DateTime.ParseExact("12/10/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "China", Nationalite = "Israel", NumeroPortable = "06 00 72 49 49", NumeroDomicile = "02 88 52 36 93", AdresseMail = "tortor.dictum.eu@iaculis.ca" },
                new Formateur(){ FormationFormateurs = new List<FormationFormateur>(), Adresse = adresses[14], Civilite = EEnum.ECivilite.Madame, EstActif = true, Nom = "Rodriguez", Prenom = "Claudia", DateNaissance = DateTime.ParseExact("05/09/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture), LieuNaissance = "Virgin Islands, United States", Nationalite = "Guam", NumeroPortable = "06 92 33 50 68", NumeroDomicile = "02 38 39 83 61", AdresseMail = "eu.nibh.vulputate@liberoduinec.org" }
            };
            formateurs.ForEach(f => Repository.Formateurs.Create(f));

            List<FormationFormateur> formationFormateurs = new List<FormationFormateur>()
            {
                new FormationFormateur(){Formateur = formateurs[0], Formation = formations[0]},
                new FormationFormateur(){Formateur = formateurs[0], Formation = formations[1]},
                new FormationFormateur(){Formateur = formateurs[1], Formation = formations[2]},
                new FormationFormateur(){Formateur = formateurs[1], Formation = formations[3]},
                new FormationFormateur(){Formateur = formateurs[2], Formation = formations[4]},
                new FormationFormateur(){Formateur = formateurs[2], Formation = formations[5]},
                new FormationFormateur(){Formateur = formateurs[3], Formation = formations[6]},
                new FormationFormateur(){Formateur = formateurs[3], Formation = formations[7]},
                new FormationFormateur(){Formateur = formateurs[3], Formation = formations[0]},
                new FormationFormateur(){Formateur = formateurs[3], Formation = formations[1]},
                new FormationFormateur(){Formateur = formateurs[4], Formation = formations[8]},
                new FormationFormateur(){Formateur = formateurs[4], Formation = formations[9]},
                new FormationFormateur(){Formateur = formateurs[4], Formation = formations[2]},
                new FormationFormateur(){Formateur = formateurs[4], Formation = formations[3]},
                new FormationFormateur(){Formateur = formateurs[4], Formation = formations[4]},
                new FormationFormateur(){Formateur = formateurs[4], Formation = formations[5]}
            };

            Repository.Formateurs.GetById(formateurs[0].Id).FormationFormateurs.Add(formationFormateurs[0]);
            Repository.Formateurs.GetById(formateurs[0].Id).FormationFormateurs.Add(formationFormateurs[1]);
            Repository.Formateurs.GetById(formateurs[1].Id).FormationFormateurs.Add(formationFormateurs[2]);
            Repository.Formateurs.GetById(formateurs[1].Id).FormationFormateurs.Add(formationFormateurs[3]);
            Repository.Formateurs.GetById(formateurs[2].Id).FormationFormateurs.Add(formationFormateurs[4]);
            Repository.Formateurs.GetById(formateurs[2].Id).FormationFormateurs.Add(formationFormateurs[5]);
            Repository.Formateurs.GetById(formateurs[3].Id).FormationFormateurs.Add(formationFormateurs[6]);
            Repository.Formateurs.GetById(formateurs[3].Id).FormationFormateurs.Add(formationFormateurs[7]);
            Repository.Formateurs.GetById(formateurs[3].Id).FormationFormateurs.Add(formationFormateurs[8]);
            Repository.Formateurs.GetById(formateurs[3].Id).FormationFormateurs.Add(formationFormateurs[9]);
            Repository.Formateurs.GetById(formateurs[4].Id).FormationFormateurs.Add(formationFormateurs[10]);
            Repository.Formateurs.GetById(formateurs[4].Id).FormationFormateurs.Add(formationFormateurs[11]);
            Repository.Formateurs.GetById(formateurs[4].Id).FormationFormateurs.Add(formationFormateurs[12]);
            Repository.Formateurs.GetById(formateurs[4].Id).FormationFormateurs.Add(formationFormateurs[13]);
            Repository.Formateurs.GetById(formateurs[4].Id).FormationFormateurs.Add(formationFormateurs[14]);
            Repository.Formateurs.GetById(formateurs[4].Id).FormationFormateurs.Add(formationFormateurs[15]);
            #endregion

            #region Sessions
            List<Jour> jours = new List<Jour>()
            {
                new Jour(){JourSessions = new List<JourSession>(), Date = DateTime.Now.AddDays(-7)},
                new Jour(){JourSessions = new List<JourSession>(), Date = DateTime.Now.AddDays(-6)},
                new Jour(){JourSessions = new List<JourSession>(), Date = DateTime.Now.AddDays(-5)},
                new Jour(){JourSessions = new List<JourSession>(), Date = DateTime.Now.AddDays(-4)},
                new Jour(){JourSessions = new List<JourSession>(), Date = DateTime.Now.AddDays(-3)},
                new Jour(){JourSessions = new List<JourSession>(), Date = DateTime.Now.AddDays(-2)},
                new Jour(){JourSessions = new List<JourSession>(), Date = DateTime.Now.AddDays(-1)},
                new Jour(){JourSessions = new List<JourSession>(), Date = DateTime.Now},
                new Jour(){JourSessions = new List<JourSession>(), Date = DateTime.Now.AddDays(1)},
                new Jour(){JourSessions = new List<JourSession>(), Date = DateTime.Now.AddDays(2)},
                new Jour(){JourSessions = new List<JourSession>(), Date = DateTime.Now.AddDays(3)},
                new Jour(){JourSessions = new List<JourSession>(), Date = DateTime.Now.AddDays(4)},
                new Jour(){JourSessions = new List<JourSession>(), Date = DateTime.Now.AddDays(5)},
                new Jour(){JourSessions = new List<JourSession>(), Date = DateTime.Now.AddDays(6)},
                new Jour(){JourSessions = new List<JourSession>(), Date = DateTime.Now.AddDays(7)}
            };
            jours.ForEach(j => j = Repository.Jours.Create(j));

            List<Session> sessions = new List<Session>()
            {
                new Session(){Formation = formations[0], Salle = salles[0], JourSessions = new List<JourSession>(), SessionApprenants = new List<SessionApprenant>(), SessionFormateurs = new List<SessionFormateur>()},
                new Session(){Formation = formations[2], Salle = salles[1], JourSessions = new List<JourSession>(), SessionApprenants = new List<SessionApprenant>(), SessionFormateurs = new List<SessionFormateur>()},
                new Session(){Formation = formations[4], Salle = salles[4], JourSessions = new List<JourSession>(), SessionApprenants = new List<SessionApprenant>(), SessionFormateurs = new List<SessionFormateur>()},
                new Session(){Formation = formations[6], Salle = salles[8], JourSessions = new List<JourSession>(), SessionApprenants = new List<SessionApprenant>(), SessionFormateurs = new List<SessionFormateur>()},
                new Session(){Formation = formations[8], Salle = salles[11], JourSessions = new List<JourSession>(), SessionApprenants = new List<SessionApprenant>(), SessionFormateurs = new List<SessionFormateur>()}
            };
            sessions.ForEach(s => s = Repository.Sessions.Create(s));

            Repository.Sessions.GetById(sessions[0].Id).JourSessions.Add(new JourSession() { Jour = jours[0], Session = sessions[0] });
            Repository.Sessions.GetById(sessions[0].Id).JourSessions.Add(new JourSession() { Jour = jours[1], Session = sessions[0] });
            Repository.Sessions.GetById(sessions[0].Id).JourSessions.Add(new JourSession() { Jour = jours[2], Session = sessions[0] });
            Repository.Sessions.GetById(sessions[0].Id).JourSessions.Add(new JourSession() { Jour = jours[3], Session = sessions[0] });
            Repository.Sessions.GetById(sessions[0].Id).JourSessions.Add(new JourSession() { Jour = jours[4], Session = sessions[0] });

            Repository.Sessions.GetById(sessions[1].Id).JourSessions.Add(new JourSession() { Jour = jours[3], Session = sessions[1] });
            Repository.Sessions.GetById(sessions[1].Id).JourSessions.Add(new JourSession() { Jour = jours[4], Session = sessions[1] });
            Repository.Sessions.GetById(sessions[1].Id).JourSessions.Add(new JourSession() { Jour = jours[5], Session = sessions[1] });
            Repository.Sessions.GetById(sessions[1].Id).JourSessions.Add(new JourSession() { Jour = jours[6], Session = sessions[1] });

            Repository.Sessions.GetById(sessions[2].Id).JourSessions.Add(new JourSession() { Jour = jours[4], Session = sessions[2] });
            Repository.Sessions.GetById(sessions[2].Id).JourSessions.Add(new JourSession() { Jour = jours[5], Session = sessions[2] });
            Repository.Sessions.GetById(sessions[2].Id).JourSessions.Add(new JourSession() { Jour = jours[6], Session = sessions[2] });

            Repository.Sessions.GetById(sessions[3].Id).JourSessions.Add(new JourSession() { Jour = jours[7], Session = sessions[3] });
            Repository.Sessions.GetById(sessions[3].Id).JourSessions.Add(new JourSession() { Jour = jours[8], Session = sessions[3] });
            Repository.Sessions.GetById(sessions[3].Id).JourSessions.Add(new JourSession() { Jour = jours[9], Session = sessions[3] });
            Repository.Sessions.GetById(sessions[3].Id).JourSessions.Add(new JourSession() { Jour = jours[10], Session = sessions[3] });

            Repository.Sessions.GetById(sessions[4].Id).JourSessions.Add(new JourSession() { Jour = jours[3], Session = sessions[4] });
            Repository.Sessions.GetById(sessions[4].Id).JourSessions.Add(new JourSession() { Jour = jours[6], Session = sessions[4] });
            Repository.Sessions.GetById(sessions[4].Id).JourSessions.Add(new JourSession() { Jour = jours[9], Session = sessions[4] });
            Repository.Sessions.GetById(sessions[4].Id).JourSessions.Add(new JourSession() { Jour = jours[11], Session = sessions[4] });
            Repository.Sessions.GetById(sessions[4].Id).JourSessions.Add(new JourSession() { Jour = jours[14], Session = sessions[4] });

            Repository.Sessions.GetById(sessions[0].Id).SessionApprenants.Add(new SessionApprenant() { Apprenant = apprenants[0], Session = sessions[0] });

            Repository.Sessions.GetById(sessions[1].Id).SessionApprenants.Add(new SessionApprenant() { Apprenant = apprenants[0], Session = sessions[1] });
            Repository.Sessions.GetById(sessions[1].Id).SessionApprenants.Add(new SessionApprenant() { Apprenant = apprenants[1], Session = sessions[1] });

            Repository.Sessions.GetById(sessions[2].Id).SessionApprenants.Add(new SessionApprenant() { Apprenant = apprenants[0], Session = sessions[2] });
            Repository.Sessions.GetById(sessions[2].Id).SessionApprenants.Add(new SessionApprenant() { Apprenant = apprenants[1], Session = sessions[2] });
            Repository.Sessions.GetById(sessions[2].Id).SessionApprenants.Add(new SessionApprenant() { Apprenant = apprenants[2], Session = sessions[2] });

            Repository.Sessions.GetById(sessions[3].Id).SessionApprenants.Add(new SessionApprenant() { Apprenant = apprenants[0], Session = sessions[3] });
            Repository.Sessions.GetById(sessions[3].Id).SessionApprenants.Add(new SessionApprenant() { Apprenant = apprenants[1], Session = sessions[3] });
            Repository.Sessions.GetById(sessions[3].Id).SessionApprenants.Add(new SessionApprenant() { Apprenant = apprenants[2], Session = sessions[3] });
            Repository.Sessions.GetById(sessions[3].Id).SessionApprenants.Add(new SessionApprenant() { Apprenant = apprenants[3], Session = sessions[3] });

            Repository.Sessions.GetById(sessions[4].Id).SessionApprenants.Add(new SessionApprenant() { Apprenant = apprenants[0], Session = sessions[4] });
            Repository.Sessions.GetById(sessions[4].Id).SessionApprenants.Add(new SessionApprenant() { Apprenant = apprenants[1], Session = sessions[4] });
            Repository.Sessions.GetById(sessions[4].Id).SessionApprenants.Add(new SessionApprenant() { Apprenant = apprenants[2], Session = sessions[4] });
            Repository.Sessions.GetById(sessions[4].Id).SessionApprenants.Add(new SessionApprenant() { Apprenant = apprenants[3], Session = sessions[4] });
            Repository.Sessions.GetById(sessions[4].Id).SessionApprenants.Add(new SessionApprenant() { Apprenant = apprenants[4], Session = sessions[4] });

            Repository.Sessions.GetById(sessions[0].Id).SessionFormateurs.Add(new SessionFormateur() { Formateur = formateurs[0], Session = sessions[0] });

            Repository.Sessions.GetById(sessions[1].Id).SessionFormateurs.Add(new SessionFormateur() { Formateur = formateurs[0], Session = sessions[1] });
            Repository.Sessions.GetById(sessions[1].Id).SessionFormateurs.Add(new SessionFormateur() { Formateur = formateurs[1], Session = sessions[1] });

            Repository.Sessions.GetById(sessions[2].Id).SessionFormateurs.Add(new SessionFormateur() { Formateur = formateurs[2], Session = sessions[2] });

            Repository.Sessions.GetById(sessions[3].Id).SessionFormateurs.Add(new SessionFormateur() { Formateur = formateurs[2], Session = sessions[3] });
            Repository.Sessions.GetById(sessions[3].Id).SessionFormateurs.Add(new SessionFormateur() { Formateur = formateurs[4], Session = sessions[3] });

            Repository.Sessions.GetById(sessions[4].Id).SessionFormateurs.Add(new SessionFormateur() { Formateur = formateurs[4], Session = sessions[4] });
            #endregion

            #region Utilisateurs
            List<Utilisateur> utilisateurs = new List<Utilisateur>()
            {
                new Utilisateur(){Prenom = "Dir", Nom = "Igeant", NomUtilisateur = "dir", MotDePasse = "pass", Role = new RoleUtilisateur(){Designation = EEnum.ERoleUtilisateur.Dirigeant } },
                new Utilisateur(){Prenom = "Sec", Nom = "Retaire", NomUtilisateur = "sec", MotDePasse = "pass", Role = new RoleUtilisateur(){Designation = EEnum.ERoleUtilisateur.Secretaire} },
                new Utilisateur(){Prenom = "Com", Nom = "Ptable", NomUtilisateur = "com", MotDePasse = "pass", Role = new RoleUtilisateur(){Designation = EEnum.ERoleUtilisateur.Comptable } }
            };
            utilisateurs.ForEach(u => u = Repository.Utilisateurs.Create(u));

            #endregion
        }
    }
}
