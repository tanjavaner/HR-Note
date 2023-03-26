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
using System.IO;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace HRNote_Plus
{
    public partial class HRNote : Form
    {
        public HRNote()
        {
            InitializeComponent();
        }

        static string connectionstring = "Data Source=DESKTOP-M94OU98\\SQLEXPRESS;Initial Catalog= HRNotePlus;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionstring);
        DateTime today = DateTime.Today;
        private void HRNote_Load(object sender, EventArgs e)
        {
            connection.Open();
            webBrowser1.Navigate("https://translate.google.com/?sl=en&tl=tr&op=translate");

            SqlCommand komut = new SqlCommand("select * from Dictionary", connection);
            using (SqlDataReader okuyucu = komut.ExecuteReader())
            {
                while (okuyucu.Read())
                {
                    if (okuyucu.GetString(0) != "")
                    {
                        comboBox1.Items.Add(okuyucu.GetString(0));
                    }
                }
            }

            SqlCommand komut2 = new SqlCommand("BEGIN\r\n   IF NOT EXISTS (SELECT * FROM HaftalikProgram\r\n                   WHERE date = @p1)\r\n   BEGIN\r\n       INSERT INTO HaftalikProgram(date,saat1,saat2,saat3,saat4,saat5,saat6,saat7,saat8,saat9,saat10,plan1,plan2,plan3,plan4,plan5,plan6,plan7,plan8,plan9,plan10)\r\n       VALUES (@p1,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2)\r\n   END\r\nEND", connection);
            komut2.Parameters.AddWithValue("@p1", today);
            komut2.Parameters.AddWithValue("@p2", string.Empty);
            komut2.ExecuteNonQuery();

            SqlCommand komut3 = new SqlCommand("Select * from HaftalikProgram where date = @p1", connection);
            komut3.Parameters.AddWithValue("@p1", today);
            using (SqlDataReader okuyucu = komut3.ExecuteReader())
            {
                if (okuyucu.Read())
                {
                    saat1.Text = okuyucu.GetString(1);
                    saat2.Text = okuyucu.GetString(2);
                    saat3.Text = okuyucu.GetString(3);
                    saat4.Text = okuyucu.GetString(4);
                    saat5.Text = okuyucu.GetString(5);
                    saat6.Text = okuyucu.GetString(6);
                    saat7.Text = okuyucu.GetString(7);
                    saat8.Text = okuyucu.GetString(8);
                    saat9.Text = okuyucu.GetString(9);
                    saat10.Text= okuyucu.GetString(10);
                    plan1.Text = okuyucu.GetString(11);
                    plan2.Text = okuyucu.GetString(12);
                    plan3.Text = okuyucu.GetString(13);
                    plan4.Text = okuyucu.GetString(14);
                    plan5.Text = okuyucu.GetString(15);
                    plan6.Text = okuyucu.GetString(16);
                    plan7.Text = okuyucu.GetString(17);
                    plan8.Text = okuyucu.GetString(18);
                    plan9.Text = okuyucu.GetString(19);
                    plan10.Text= okuyucu.GetString(20);
                }
            }

            button8.PerformClick();
        }

        private void HRNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
            Application.Exit();
        }

        public void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("BEGIN\r\n   IF NOT EXISTS (SELECT * FROM HaftalikProgram\r\n                   WHERE date = @p1)\r\n   BEGIN\r\n       INSERT INTO HaftalikProgram(date,saat1,saat2,saat3,saat4,saat5,saat6,saat7,saat8,saat9,saat10,plan1,plan2,plan3,plan4,plan5,plan6,plan7,plan8,plan9,plan10)\r\n       VALUES (@p1,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2,@p2)\r\n   END\r\nEND", connection);
            komut2.Parameters.AddWithValue("@p1", monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd"));
            komut2.Parameters.AddWithValue("@p2", string.Empty);
            komut2.ExecuteNonQuery();

            SqlCommand komut3 = new SqlCommand("Select * from HaftalikProgram where date = @p1", connection);
            komut3.Parameters.AddWithValue("@p1", monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd"));
            using (SqlDataReader okuyucu = komut3.ExecuteReader())
            {
                if (okuyucu.Read())
                {
                    saat1.Text = okuyucu.GetString(1);
                    saat2.Text = okuyucu.GetString(2);
                    saat3.Text = okuyucu.GetString(3);
                    saat4.Text = okuyucu.GetString(4);
                    saat5.Text = okuyucu.GetString(5);
                    saat6.Text = okuyucu.GetString(6);
                    saat7.Text = okuyucu.GetString(7);
                    saat8.Text = okuyucu.GetString(8);
                    saat9.Text = okuyucu.GetString(9);
                    saat10.Text = okuyucu.GetString(10);
                    plan1.Text = okuyucu.GetString(11);
                    plan2.Text = okuyucu.GetString(12);
                    plan3.Text = okuyucu.GetString(13);
                    plan4.Text = okuyucu.GetString(14);
                    plan5.Text = okuyucu.GetString(15);
                    plan6.Text = okuyucu.GetString(16);
                    plan7.Text = okuyucu.GetString(17);
                    plan8.Text = okuyucu.GetString(18);
                    plan9.Text = okuyucu.GetString(19);
                    plan10.Text = okuyucu.GetString(20);
                }
            }
            button8.PerformClick();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Document.Body.Style = "zoom:100%";
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                textboxara.Text = comboBox1.SelectedItem.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Dictionary where word = @p1", connection);
            komut.Parameters.AddWithValue("@p1", textboxara.Text);
            using (SqlDataReader okuyucu = komut.ExecuteReader())
            {
                if (okuyucu.Read())
                {
                    anlam1.Text = okuyucu.GetString(1);
                    anlam2.Text = okuyucu.GetString(2);
                    anlam3.Text = okuyucu.GetString(3);
                    cumle1.Text = okuyucu.GetString(4);
                    cumle2.Text = okuyucu.GetString(5);
                    cumle3.Text = okuyucu.GetString(6);
                    cumle4.Text = okuyucu.GetString(7);
                    cumle5.Text = okuyucu.GetString(8);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textboxara.Text != string.Empty)
            {
                SqlCommand komut = new SqlCommand("BEGIN\r\n   IF NOT EXISTS (SELECT * FROM Dictionary\r\n                   WHERE word = @p1)\r\n   BEGIN\r\n       INSERT INTO Dictionary(word,meaning1,meaning2,meaning3,sentence1,sentence2,sentence3,sentence4,sentence5)\r\n       VALUES (@p1, @p2, @p3,@p4,@p5,@p6,@p7,@p8,@p9)\r\n   END\r\nEND", connection);
                komut.Parameters.AddWithValue("@p1", textboxara.Text);
                komut.Parameters.AddWithValue("@p2", anlam1.Text);
                komut.Parameters.AddWithValue("@p3", anlam2.Text);
                komut.Parameters.AddWithValue("@p4", anlam3.Text);
                komut.Parameters.AddWithValue("@p5", cumle1.Text);
                komut.Parameters.AddWithValue("@p6", cumle2.Text);
                komut.Parameters.AddWithValue("@p7", cumle3.Text);
                komut.Parameters.AddWithValue("@p8", cumle4.Text);
                komut.Parameters.AddWithValue("@p9", cumle5.Text);
                komut.ExecuteNonQuery();
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            SqlCommand komut = new SqlCommand("select * from Dictionary", connection);
            using (SqlDataReader okuyucu = komut.ExecuteReader())
            {
                while (okuyucu.Read())
                {
                    if (okuyucu.GetString(0) != "")
                    {
                        comboBox1.Items.Add(okuyucu.GetString(0));
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textboxara.Text != string.Empty)
            {
                SqlCommand komut = new SqlCommand("UPDATE Dictionary SET meaning1=@p2,meaning2=@p3,meaning3=@p4,sentence1 = @p5,sentence2=@p6,sentence3=@p7,sentence4=@p8,sentence5=@p9  WHERE word = @p1", connection);
                komut.Parameters.AddWithValue("@p1", textboxara.Text);
                komut.Parameters.AddWithValue("@p2", anlam1.Text);
                komut.Parameters.AddWithValue("@p3", anlam2.Text);
                komut.Parameters.AddWithValue("@p4", anlam3.Text);
                komut.Parameters.AddWithValue("@p5", cumle1.Text);
                komut.Parameters.AddWithValue("@p6", cumle2.Text);
                komut.Parameters.AddWithValue("@p7", cumle3.Text);
                komut.Parameters.AddWithValue("@p8", cumle4.Text);
                komut.Parameters.AddWithValue("@p9", cumle5.Text);
                komut.ExecuteNonQuery();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textboxara.Text != string.Empty)
            {
                SqlCommand komut = new SqlCommand("Delete from Dictionary WHERE word = @p1", connection);
                komut.Parameters.AddWithValue("@p1", textboxara.Text);
                komut.ExecuteNonQuery();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("Select * from HaftalikProgram where date = @p1", connection);
            komut3.Parameters.AddWithValue("@p1", monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd"));
            using (SqlDataReader okuyucu = komut3.ExecuteReader())
            {
                if (okuyucu.Read())
                {
                    saat1.Text = okuyucu.GetString(1);
                    saat2.Text = okuyucu.GetString(2);
                    saat3.Text = okuyucu.GetString(3);
                    saat4.Text = okuyucu.GetString(4);
                    saat5.Text = okuyucu.GetString(5);
                    saat6.Text = okuyucu.GetString(6);
                    saat7.Text = okuyucu.GetString(7);
                    saat8.Text = okuyucu.GetString(8);
                    saat9.Text = okuyucu.GetString(9);
                    saat10.Text = okuyucu.GetString(10);
                    plan1.Text = okuyucu.GetString(11);
                    plan2.Text = okuyucu.GetString(12);
                    plan3.Text = okuyucu.GetString(13);
                    plan4.Text = okuyucu.GetString(14);
                    plan5.Text = okuyucu.GetString(15);
                    plan6.Text = okuyucu.GetString(16);
                    plan7.Text = okuyucu.GetString(17);
                    plan8.Text = okuyucu.GetString(18);
                    plan9.Text = okuyucu.GetString(19);
                    plan10.Text = okuyucu.GetString(20);
                }
            }
            string hourtime = DateTime.Now.ToString("HH");
            if (monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd") == today.ToString("yyyy-MM-dd"))
            {
                saat1.Enabled = false;
                saat2.Enabled = false;
                saat3.Enabled = false;
                saat4.Enabled = false;
                saat5.Enabled = false;
                saat6.Enabled = false;
                saat7.Enabled = false;
                saat8.Enabled = false;
                saat9.Enabled = false;
                saat10.Enabled = false;
                if (hourtime == "05")
                {
                    saat1.Enabled = true;
                }
                else if (hourtime == "06" | hourtime == "07")
                {
                    saat2.Enabled = true;
                }
                else if (hourtime == "08" | hourtime == "09")
                {
                    saat3.Enabled = true;
                }
                else if (hourtime == "10" | hourtime == "11")
                {
                    saat4.Enabled = true;
                }
                else if (hourtime == "12" | hourtime == "13")
                {
                    saat5.Enabled = true;
                }
                else if (hourtime == "14" | hourtime == "15")
                {
                    saat6.Enabled = true;
                }
                else if (hourtime == "16" | hourtime == "17")
                {
                    saat7.Enabled = true;
                }
                else if (hourtime == "18" | hourtime == "19")
                {
                    saat8.Enabled = true;
                }
                else if (hourtime == "20" | hourtime == "21")
                {
                    saat9.Enabled = true;
                }
                else if (hourtime == "22" | hourtime == "23")
                {
                    saat10.Enabled = true;
                }
            }
            else
            {
                saat1.Enabled = false;
                saat2.Enabled = false;
                saat3.Enabled = false;
                saat4.Enabled = false;
                saat5.Enabled = false;
                saat6.Enabled = false;
                saat7.Enabled = false;
                saat8.Enabled = false;
                saat9.Enabled = false;
                saat10.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update HaftalikProgram set saat1 = @p1,saat2 = @p2,saat3=@p3,saat4=@p4,saat5=@p5,saat6=@p6,saat7=@p7,saat8 = @p8,saat9=@p9,saat10=@p10,plan1=@p11,plan2=@p12,plan3=@p13,plan4=@p14,plan5 = @p15,plan6=@p16,plan7=@p17,plan8=@p18,plan9=@p19,plan10=@p20 where date = @p21", connection);
            komut.Parameters.AddWithValue("@p21", monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd"));
            komut.Parameters.AddWithValue("@p1", saat1.Text);
            komut.Parameters.AddWithValue("@p2", saat2.Text);
            komut.Parameters.AddWithValue("@p3", saat3.Text);
            komut.Parameters.AddWithValue("@p4", saat4.Text);
            komut.Parameters.AddWithValue("@p5", saat5.Text);
            komut.Parameters.AddWithValue("@p6", saat6.Text);
            komut.Parameters.AddWithValue("@p7", saat7.Text);
            komut.Parameters.AddWithValue("@p8", saat8.Text);
            komut.Parameters.AddWithValue("@p9", saat9.Text);
            komut.Parameters.AddWithValue("@p10", saat10.Text);
            komut.Parameters.AddWithValue("@p11", plan1.Text);
            komut.Parameters.AddWithValue("@p12", plan2.Text);
            komut.Parameters.AddWithValue("@p13", plan3.Text);
            komut.Parameters.AddWithValue("@p14", plan4.Text);
            komut.Parameters.AddWithValue("@p15", plan5.Text);
            komut.Parameters.AddWithValue("@p16", plan6.Text);
            komut.Parameters.AddWithValue("@p17", plan7.Text);
            komut.Parameters.AddWithValue("@p18", plan8.Text);
            komut.Parameters.AddWithValue("@p19", plan9.Text);
            komut.Parameters.AddWithValue("@p20", plan10.Text);
            komut.ExecuteNonQuery();
        }
    }
}
