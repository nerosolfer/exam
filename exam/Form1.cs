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
                Host = "192.168.25.23";
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
            string id = "SELECT 'id' FROM 'var2'";
            label1.Text = ($"Всего пациентов: {id}");

            _ConnectDB ConnDb = new _ConnectDB();
            MySqlConnection connDb = new MySqlConnection(ConnDb.Initialization());
            string zapros = "SELECT 'id', 'fio','age', 's' FROM 'var2'";
            try
            {
                connDb.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(zapros, connDb);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[1];
                dataGridView1.Sort(new RowComparer(SortOrder.Ascending));
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
        private class RowComparer : System.Collections.IComparer
        {
            private static int sortOrderModifier = 1;

            public RowComparer(SortOrder sortOrder)
            {
                if (sortOrder == SortOrder.Descending)
                {
                    sortOrderModifier = -1;
                }
                else if (sortOrder == SortOrder.Ascending)
                {
                    sortOrderModifier = 1;
                }
            }

            public int Compare(object x, object y)
            {
                DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
                DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;

             
                int CompareResult = System.String.Compare(
                    DataGridViewRow1.Cells[1].Value.ToString(),
                    DataGridViewRow2.Cells[1].Value.ToString());
                return CompareResult * sortOrderModifier;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
