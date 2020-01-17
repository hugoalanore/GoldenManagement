using GoldenManagement.Controllers;
using GoldenManagement.Controllers.GestionUtilisateur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoldenManagement.Views.GestionUtilisateur
{
    /// <summary>
    /// Logique d'interaction pour AccueilMonProfilPage.xaml
    /// </summary>
    public partial class AccueilMonProfilPage : Page
    {
        private readonly UtilisateurController UtilisateurController = UtilisateurController.Instance;
        private readonly GoldenApp GoldenApp = GoldenApp.Instance;

        public AccueilMonProfilPage()
        {
            InitializeComponent();
            GetMonProfil();
        }

        private void GetMonProfil()
        {
            TB_monPrenom.Text = "Prenom : " + GoldenApp.LivingData.UtilisateurActif.Prenom;
            TB_monNom.Text = "Nom : " + GoldenApp.LivingData.UtilisateurActif.Nom;
            TB_monNomUtilisateur.Text = "Nom Utilisateur : " + GoldenApp.LivingData.UtilisateurActif.NomUtilisateur;
            TB_monRole.Text = "Role : " + GoldenApp.LivingData.UtilisateurActif.Role;
        }

        private void BTN_updatePassWord_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PB_newMotDePasse.Password == PB_newMotDePasseConfirmation.Password)
                {
                    var IsOK = UtilisateurController.UpdatePassWord(GoldenApp.LivingData.UtilisateurActif.Id, PB_motDePasse.Password, PB_newMotDePasse.Password, GoldenApp.LivingData.UtilisateurActif.NomUtilisateur);

                    if (IsOK)
                    {
                        PB_motDePasse.Password = String.Empty;
                        PB_newMotDePasse.Password = String.Empty;
                        PB_newMotDePasseConfirmation.Password = String.Empty;
                        TB_message.Text = "Mot de Passe modifier avec succès";
                    }
                    else
                    {
                        PB_motDePasse.Password = String.Empty;
                        TB_message.Text = "Mot de Passe Incorrect";
                    }
                }
                else
                {
                    PB_newMotDePasse.Password = String.Empty;
                    PB_newMotDePasseConfirmation.Password = String.Empty;
                    TB_message.Text = "Confirmation mot de passe différent";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

