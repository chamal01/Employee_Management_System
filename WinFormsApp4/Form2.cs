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

namespace WinFormsApp4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("Data Source=ANONYMOUS;Initial Catalog=employee;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            //insert button

            int empid = int.Parse(textBox1.Text);
            string empname = textBox2.Text, city = comboBox1.Text, contact = textBox6.Text, sex = "";
            double age = double.Parse(textBox4.Text);
            DateTime joindate = DateTime.Parse(dateTimePicker1.Text);
            if (radioButton1.Checked == true) { sex = "Male"; } else { sex = "Female"; }
            con.Open();
            SqlCommand c = new SqlCommand("exec Insert_emp '" + empid + "','" + empname + "','" + city + "','" + age + "','" + sex + "','" + joindate + "','" + contact + "'", con);
            c.ExecuteNonQuery();
            MessageBox.Show("Successful..!!");
            GetEmpList();
        }

        void GetEmpList()
        {
            SqlCommand c = new SqlCommand("exec List_emp", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GetEmpList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update button
            int empid = int.Parse(textBox1.Text);
            string empname = textBox2.Text, city = comboBox1.Text, contact = textBox6.Text, sex = "";
            double age = double.Parse(textBox4.Text);
            DateTime joindate = DateTime.Parse(dateTimePicker1.Text);
            if (radioButton1.Checked == true) { sex = "Male"; } else { sex = "Female"; }
            con.Open();
            SqlCommand c = new SqlCommand("exec Update_emp '" + empid + "','" + empname + "','" + city + "','" + age + "','" + sex + "','" + joindate + "','" + contact + "'", con);
            c.ExecuteNonQuery();
            MessageBox.Show("Successful Updated..!!");
            GetEmpList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete
            if(MessageBox.Show("are you sure to delete that employer ?" ,"Delete Document",MessageBox.YesNo)==DialogResult.Yes)
            {
                int empid = int.Parse(textBox1.Text);
                con.Open();
                SqlCommand c = new SqlCommand("exec Delete_emp '" + empid + "'", con);
                c.ExecuteNonQuery();
                MessageBox.Show("Successful Deleted Employee..!!");
                GetEmpList();
            }
        }
            
    }
}
