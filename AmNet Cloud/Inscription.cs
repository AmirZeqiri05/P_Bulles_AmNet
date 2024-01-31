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

namespace AmNet_Cloud
{
    public partial class Inscription : Form
    {

        public Inscription()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Inscription_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Connexion SignIn = new Connexion();
            SignIn.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MySqlCon = "server=localhost; port=6033; user=root; password=root; database=db_P_Bulles_Cloud";
            MySqlConnection mySqlConnection = new MySqlConnection(MySqlCon);

            // Récupérer les données du formulaire
            string pseudo = txtboxPseudo.Text;
            string email = txtboxEmail.Text;
            string password = txtboxPassword.Text;
            // Ajoutez d'autres champs en fonction de votre table

            // Créer la connexion à la base de données
            using (MySqlConnection connexion = new MySqlConnection(MySqlCon))
            {
                try
                {
                    // Ouvrir la connexion
                    connexion.Open();

                    // Requête SQL d'insertion
                    string query = "INSERT INTO users (pseudo, email, password) VALUES (@Pseudo, @Email, @Mdp)";

                    // Créer la commande SQL
                    using (MySqlCommand cmd = new MySqlCommand(query, connexion))
                    {
                        // Ajouter les paramètres
                        cmd.Parameters.AddWithValue("@Pseudo", pseudo);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Mdp", password);

                        // Exécuter la commande
                        cmd.ExecuteNonQuery();

                        // Afficher un message de réussite
                        MessageBox.Show("Utilisateur enregistré avec succès !");
                    }
                }
                catch (Exception ex)
                {
                    // Gérer les erreurs ici
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void txtboxPseudo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}