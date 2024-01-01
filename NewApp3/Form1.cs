using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;



namespace NewApp3
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5AGT64T;Initial Catalog=Gargi;Integrated Security=True");

        //  SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\C_#1\MyApp3\Gargi.mdf;Integrated Security=True;Connect Timeout=30");

        //   SqlConnection conn = new SqlConnection(@"Data Source=.;(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\App4DM\Gargi.mdf;Integrated Security=True;Connect Timeout=30");


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fill();
        }
        private void Fill()
        {
            SqlCommand cmd = new SqlCommand("Select * from dbo.Table_1", conn);
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            conn.Close();
            dataGridView1.DataSource = dt;
        }
        private void insrt()
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {

                MessageBox.Show("Please Fill the Class", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                //if (string.IsNullOrWhiteSpace(textBoxID.Text))          //  string.IsNullOrEmpty(textBoxID.Text) &&
                //{


                //    MessageBox.Show("Please Fill the information", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else

                //{

                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Table_1 (Name, Address) VALUES (@Name , @Address)", conn);
                // check Empty
                try
                {
                    conn.Open();
                    cmd.CommandType = CommandType.Text;

                    //  cmd.Parameters.AddWithValue("@subID", textBoxID.Text);
                    cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox3.Text);


                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Fill();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insrt();
        }
    }
}

