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
using System.Media;

namespace Calculatrice_2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //1 mettre le using System.Media; __ 2Double clic sur ressources.resx dans l'explorateur de solution(une page va s'ouvrir) __ 3clic sur ajouter une ressources et ajouter un fichier existant___ 4une fois le fichier voulu selectionné fermer la fenetre pour l'ajouter a la ressource
        System.Media.SoundPlayer Youpi = new System.Media.SoundPlayer(Calculatrice_2.Properties.Resources.Youpi);

        // Declaration des variables utiles
        long number1 = 0;
        long number2 = 0;
        // Presence ou non d'un opérateur
        string operation = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // On récupére le parametre sender du bouton.
            var userNumber = sender as Button;
            if (Result.Text == "0")
            {
                // On renvoi la valeur du bouton
                Result.Text = userNumber.Content.ToString();
            }
            else
            {
                Result.Text += userNumber.Content.ToString();
            }
        }
        

        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            number1 = long.Parse(Result.Text);
            operation = "+";
            Result.Text = "0";
            //AffichageOpération.Text = $"{number1}+{number2}";
        }
        private void ButtonClickMinus(object sender, RoutedEventArgs e)
        {
            number1 = long.Parse(Result.Text);
            operation = "-";
            Result.Text = "0";
        }
        private void ButtonClickMultiply(object sender, RoutedEventArgs e)
        {
            number1 = long.Parse(Result.Text);
            operation = "*";
            Result.Text = "0";
        }
        private void ButtonClickDivide(object sender, RoutedEventArgs e)
        {
            number1 = long.Parse(Result.Text);
            operation = "/";
            Result.Text = "0";
        }
        private void ButtonClickEqual(object sender, RoutedEventArgs e)
        {
            number2 = long.Parse(Result.Text);
            // Case pour chaque operation basé sur le signe stocké dans OPERATION
            switch (operation)
            {
                case "+":
                    Result.Text = (number1 + number2).ToString();
                    // On stock le resultat dans Number1 pour pouvoir le réutiliser 
                    number1 = (number1 + number2);
                    //Reset Number2
                    number2 = 0;
                    break;
                case "-":
                    Result.Text = (number1 - number2).ToString();
                    number1 = (number1 - number2);
                    number2 = 0;
                    break;
                case "/":
                    if (number2 == 0)
                    {
                        MessageBox.Show("Erreur", "Erreur");
                    }
                    else
                    {
                        Result.Text = (number1 / number2).ToString();
                        number1 = (number1 / number2);
                        number2 = 0;

                    }
                    break;

                case "*":
                    Result.Text = (number1 * number2).ToString();
                    number1 = (number1 * number2);
                    number2 = 0;
                    break;

            }
            
        }
        // RESET
        private void ButtonClickReset(object sender, RoutedEventArgs e)
        {
            number1 = 0;
            number2 = 0;
            operation = "";
            Result.Text = "0";
            //déclanchement du song
            Youpi.Play();
            //System.Media.SoundPlayer sp = new System.Media.SoundPlayer(@"H:\4_2TP_JustePrix_Calculatrice\Calculatrice_2\Calculatrice_2\song\Youpi.wav");
            //sp.Play();
            //SystemSounds.Beep.Play(); //sinon juste un bip
        }
    }
}
