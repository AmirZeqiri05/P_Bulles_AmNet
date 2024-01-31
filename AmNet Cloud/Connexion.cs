using MySql.Data.MySqlClient;

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inscription SignUp = new Inscription();
            SignUp.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
