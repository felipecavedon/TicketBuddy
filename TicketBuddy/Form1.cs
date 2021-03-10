using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TicketBuddy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void reloadcombobox()
        {
            comboBox1.Items.Clear();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Felipe\source\repos\TicketBuddy\TicketBuddy\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Tickets", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int Id = dr.GetInt32(0);
                comboBox1.Items.Add(Id);
            }
            con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (typeBox.Text == "")
            {
                MessageBox.Show("Please fill the input");
            }
            
            else {
            Clipboard.SetText(typeBox.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (typeBox.Text == "")
            {
                MessageBox.Show("Please fill the input");
            }

            else { 
            Clipboard.SetText(nameBox.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (typeBox.Text == "")
            {
                MessageBox.Show("Please fill the input");
            }
            else { 
            Clipboard.SetText(callbackBox.Text);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (typeBox.Text == "")
            {
                MessageBox.Show("Please fill the input");
            }

            else
            {
                Clipboard.SetText(legazyBox.Text);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (typeBox.Text == "")
            {
                MessageBox.Show("Please fill the input");
            }

            else
            {
                Clipboard.SetText(locationBox.Text);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (typeBox.Text == "")
            {
                MessageBox.Show("Please fill the input");
            }

            else
            {
                Clipboard.SetText(applicationBox.Text);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (typeBox.Text == "")
            {
                MessageBox.Show("Please fill the input");
            }
            else
            { 
            Clipboard.SetText(descriptionBox.Text);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (typeBox.Text == "")
            {
                MessageBox.Show("Please fill the input");
            }
            else 
            { 
            Clipboard.SetText(troubleBox.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            idBox.Text = "";
            typeBox.Text = "";
            nameBox.Text = "";
            callbackBox.Text = "";
            legazyBox.Text = "";
            locationBox.Text = "";
            applicationBox.Text = "";
            descriptionBox.Text = "";
            troubleBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idBox.Text == "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Felipe\source\repos\TicketBuddy\TicketBuddy\Database1.mdf;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("INSERT into Tickets (type, name, callback, legazy, location, application, description, trouble) values ('" + typeBox.Text + "','" + nameBox.Text + "','" + callbackBox.Text + "','" + legazyBox.Text + "','" + locationBox.Text + "','" + applicationBox.Text + "','" + descriptionBox.Text + "','" + troubleBox.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                idBox.Text = "";
                typeBox.Text = "";
                nameBox.Text = "";
                callbackBox.Text = "";
                legazyBox.Text = "";
                locationBox.Text = "";
                applicationBox.Text = "";
                descriptionBox.Text = "";
                troubleBox.Text = "";
                MessageBox.Show("Ticket saved for later");
                reloadcombobox();
            }

            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Felipe\source\repos\TicketBuddy\TicketBuddy\Database1.mdf;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("UPDATE Tickets SET type = '"+typeBox.Text+ "', name = '" + nameBox.Text + "', callback = '" + callbackBox.Text + "', legazy = '" + legazyBox.Text + "', location = '" + locationBox.Text + "', application = '" + applicationBox.Text + "', description = '" + descriptionBox.Text + "', trouble = '" + troubleBox.Text + "' WHERE Id = '"+idBox.Text+"'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Ticket updated");
                reloadcombobox();
            }
        }

       
        private void button11_Click(object sender, EventArgs e)
        {
            string message = "Sure you wanna delete it?";
            string caption = "Check";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                if (idBox.Text == "")
                {

                }

                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Felipe\source\repos\TicketBuddy\TicketBuddy\Database1.mdf;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("DELETE FROM Tickets WHERE Id='" + idBox.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    comboBox1.Items.Clear();
                    comboBox1.Text = "";
                }
            }

            idBox.Text = "";
            typeBox.Text = "";
            nameBox.Text = "";
            callbackBox.Text = "";
            legazyBox.Text = "";
            locationBox.Text = "";
            applicationBox.Text = "";
            descriptionBox.Text = "";
            troubleBox.Text = "";
            reloadcombobox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Felipe\source\repos\TicketBuddy\TicketBuddy\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tickets where Id ='" + comboBox1.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int Id = dr.GetInt32(0);
                string Ids = Id.ToString();
                idBox.Text = Ids;

                var type = (string)dr["type"].ToString();
                typeBox.Text = type;

                var name = (string)dr["name"].ToString();
                nameBox.Text = name;

                var callback = (string)dr["callback"].ToString();
                callbackBox.Text = callback;

                var legazy = (string)dr["legazy"].ToString();
                legazyBox.Text = legazy;

                var location = (string)dr["location"].ToString();
                locationBox.Text = location;

                var application = (string)dr["application"].ToString();
                applicationBox.Text = application;

                var description = (string)dr["description"].ToString();
                descriptionBox.Text = description;

                var trouble = (string)dr["trouble"].ToString();
                troubleBox.Text = trouble;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Tickets' table. You can move, or remove it, as needed.
            this.ticketsTableAdapter.Fill(this.database1DataSet.Tickets);
            reloadcombobox();
        }
    }
}
