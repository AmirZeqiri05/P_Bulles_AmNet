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
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
            string MySqlCon = "server=localhost; user=root; password=root; database=db_P_Bulles_Cloud";
            MySqlConnection mySqlConnection = new MySqlConnection(MySqlCon);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inscription SignUp = new Inscription();
            SignUp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Récupérer les données du formulaire
            string email = txtboxEmail.Text;
            string password = txtboxPassword.Text;
            string cryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // Vérifier si le pseudo ou l'email existe déjà
            string query = "SELECT COUNT(*) FROM users WHERE pseudo = @pseudo OR email = @email";

            {

            }
        }
    }
}
