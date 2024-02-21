using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt;
using System.Text.RegularExpressions;

namespace AmNet_Cloud
{
    public partial class Inscription : Form
    {

        public Inscription()
        {
            InitializeComponent();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Connexion SignIn = new Connexion();
            SignIn.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Récupérer les données du formulaire
            string pseudo = txtboxPseudo.Text;
            string email = txtboxEmail.Text;
            string password = txtboxPassword.Text;
            string cryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // Vérifier si l'email existe déjà
            string query = "SELECT COUNT(*) FROM users WHERE email = @email";

            using MySqlConnection connexion = new MySqlConnection("server=localhost; port=6033; user=root; password=root; database=db_P_Bulles_Cloud");
            using MySqlCommand cmd = new MySqlCommand(query, connexion);
            {
                cmd.Parameters.AddWithValue("@email", email);

                try
                {
                    connexion.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        if (emailExists(email))
                        {
                            MessageBox.Show("Erreur : Cet email est déjà utilisé, veuillez en choisir un autre.");
                        }
                        return;
                    }

                    // Validation de l'email
                    if (!Regex.IsMatch(email, @"^[a-zA-Z.-]+@[a-zA-Z.-]+\.[a-zA-Z]+$"))
                    {
                        MessageBox.Show("Erreur : L'email indiqué n'est pas au bon format.");
                        return;
                    }

                    // Validation du mot de passe
                    if (txtboxPassword.Text != txtBoxPassword2.Text)
                    {
                        MessageBox.Show("Erreur : Les mots de passe ne sont pas identiques.");
                    }
                    else if (password.Length < 8 || !(password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit)))
                    {
                        MessageBox.Show("Erreur : Le mot de passe doit avoir au moins 8 caractères avec au moins une lettre majuscule, une lettre minuscule et un chiffre.");
                    }
                    else
                    {
                        // Requête SQL d'insertion
                        query = "INSERT INTO users (pseudo, email, password) VALUES (@pseudo, @email, @mdp)";

                        // Créer la commande SQL
                        cmd.CommandText = query;

                        // Ajouter les paramètres
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@pseudo", pseudo);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@mdp", cryptedPassword);

                        // Exécuter la commande
                        cmd.ExecuteNonQuery();

                        // Afficher un message de réussite
                        MessageBox.Show("Le compte a bien été créé");
                    }
                }
                catch (Exception ex)
                {
                    // Gérer les erreurs ici
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private bool emailExists(string email)
        {
            string query = "SELECT COUNT(*) FROM users WHERE email = @email";
            using MySqlConnection connexion = new MySqlConnection("server=localhost; port=6033; user=root; password=root; database=db_P_Bulles_Cloud");
            using MySqlCommand cmd = new MySqlCommand(query, connexion);
            {
                cmd.Parameters.AddWithValue("@email", email);
                connexion.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
