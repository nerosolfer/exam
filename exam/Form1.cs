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



namespace exam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class _ConnectDB
        {
            public string conn;
            public string Host;
            public string Port;
            public string User;
            public string Database;
            public string Password;

            public string Initialization()
            {
                Host = "chuc.caseum.ru";
                Port = "33333";
                User = "exem_is";
                Database = "exem_is";
                Password = "12345";
                string connecionString;
                connecionString = $"server={Host};port={Port};user={User};database={Database};password={Password};";

                conn = connecionString;
                return conn;
            }
        }
       
        
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            _ConnectDB ConnDb = new _ConnectDB();
            MySqlConnection connDb = new MySqlConnection(ConnDb.Initialization());
            string zapros = "SELECT id, fio, age, s FROM var2 ORDER BY fio ASC";
            
            label1.Text = Convert.ToString(dataGridView1.Rows.Count);
            try
            {
                connDb.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(zapros, connDb);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message);
                this.Close();
            }

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersVisible = true;

            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[2].HeaderText = "Возраст";
            dataGridView1.Columns[3].HeaderText = "Пол";

        }
  
        private void button1_Click(object sender, EventArgs e)
        {
            _ConnectDB ConnDb = new _ConnectDB();
            MySqlConnection connDb = new MySqlConnection(ConnDb.Initialization());
          
            foreach(DataGridViewRow row in dataGridView1.Rows)
            if (Convert.ToString(row.Cells[3].Value) == "м") { row.DefaultCellStyle.BackColor = Color.Red; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
