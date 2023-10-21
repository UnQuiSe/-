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

namespace праткика_коряка
{
    
    
    public partial class Form1 : Form
    {

        public static double score = 0;
        private string name = "";
        private string login = "";
        public int[] a = new int[20];
        public int[] b = new int[20];
        public int[] c = new int[20];
        public int g = 0;
        public int x = 0;
        public int schet = 0;
        public static int i = 0;
        public static double time = 0;
        public double tumb = 0;
        public bool log = false;
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            string SqlText = "SELECT * FROM [pihta1]"; // текст SQL-запроса
            SqlDataAdapter drug = new SqlDataAdapter(SqlText, @"Data Source=.\SQLEXPRESS;Initial Catalog=afrodisiac;Integrated Security=True");
            DataSet datacaca = new DataSet();
            drug.Fill(datacaca, "[pihta1]");
            dataGridView1.DataSource = datacaca.Tables["[pihta1]"].DefaultView;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "afrodisiacDataSet4.pihta1". При необходимости она может быть перемещена или удалена.
            this.pihta1TableAdapter1.Fill(this.afrodisiacDataSet4.pihta1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "afrodisiacDataSet3.pihta1". При необходимости она может быть перемещена или удалена.
            pictureBox1.Image = Image.FromFile("C:/Users/runga/Desktop/12/5.gif");
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            g = 0;
            int z = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (textBox1.Text == Convert.ToString(dataGridView1.Rows[i].Cells[0].Value)||textBox1.Text=="")
                {
                    login = textBox1.Text;
                    log = true;
                }
            }
            if (log == false)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) == ""&&login=="")
                    {
                        login = textBox1.Text;
                        z = i;
                        textBox1.Text = "";
                    }
                }
                label6.Visible = true;
                label1.Visible = false;
                label6.Text = "Введите псевдоним, который будет отображаться в топ листе";
                button1.Text = "Сохранить";
                name = textBox1.Text;
                if (name !="")
                {
                            textBox1.Text = "";
                            log = true;
                }
                
            }
            if (log == true)
            {
                label6.Visible = false;
                t.Enabled = true;
                t.Start();
                label5.Visible = true;
                textBox1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                button1.Visible = false;
                textBox2.Visible = true;
                label3.Visible = true;
                label7.Visible = true;
                button2.Visible = true;
                label4.Visible = true;
                for (int i = 0; i < 20; i++)
                {
                    a[i] = r.Next(-10, 10);
                    b[i] = r.Next(-10, 10);
                    c[i] = r.Next(0, 2);
                }
               
                tumb = 0;
                label4.Text = Convert.ToString("Пример номер" + (g + 1));
                if (c[g] == 0)
                {
                    label3.Text = Convert.ToString(a[g] + " + " + b[g]);
                    x = a[g] + b[g];
                }
                else if (c[g] == 1)
                {
                    label3.Text = Convert.ToString(a[g] + " - " + b[g]);
                    x = a[g] - b[g];
                }
                else if (c[g] == 2)
                {
                    label3.Text = Convert.ToString(a[g] + " * " + b[g]);
                    x = a[g] * b[g];
                }
                g++;
                schet++;
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (Convert.ToInt32(textBox2.Text) == x)
                {
                    i++;
                }
                textBox2.Text = "";
            }
            label4.Text = Convert.ToString("Пример номер" + (g+1));
            if (g > 19)
            {
                t.Stop();
                t.Dispose();
                t.Enabled = false;
                if (textBox2.Text != "")
                {
                    if (Convert.ToInt32(textBox2.Text) == x)
                    {
                        i++;
                    }
                    textBox2.Text = "";
                }
                label6.Visible = false;
                label5.Visible = false;
                label3.Visible = false;
                label7.Visible = false;
                button2.Visible = false;
                textBox2.Visible = false;
                label4.Visible = false;
                textBox1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                button1.Visible = true;
                time = tumb;
                tumb = 16000 - (tumb * 100);
                score = (i * 1000) + tumb;
                if (login != "")
                {
                   
                    bool nashel = false;
                    int j = 0;
                    for(int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (login == Convert.ToString(dataGridView1.Rows[i].Cells[0].Value))
                        {
                            j = i;
                            nashel = true;
                        }
                    }
                  
                    if (nashel == true)
                    {
                        if (Convert.ToDouble(dataGridView1.Rows[j].Cells[2].Value) < score)
                        {
                            SqlConnection cn;
                            SqlCommand cmd;
                            string SqlText = $"Update pihta1 SET score = {score} WHERE (login) = ('"+login+"')";
                            cn = new SqlConnection(@"Data Source=ANNA;Initial Catalog=afrodisiac;Integrated Security=True");
                            cn.Open();
                            cmd = cn.CreateCommand();
                            cmd.CommandText = SqlText;
                            cmd.ExecuteNonQuery();
                            cn.Close();
                        }
                    }
                    else
                    {
                        SqlConnection cn;
                        SqlCommand cmd;
                        string SqlText = "INSERT INTO [pihta1] ([login],[name],[score]) VALUES ( '" + login + "','" + name + "','" + score + "') ";
                        cn = new SqlConnection(@"Data Source=ANNA;Initial Catalog=afrodisiac;Integrated Security=True");
                        cn.Open();
                        cmd = cn.CreateCommand();
                        cmd.CommandText = SqlText;
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                }
                finish newform = new finish();
                newform.Show();
                name = "";
                login = "";
                g = 0;
                i = 0;
                textBox1.Text = "";
                log = true;
               
            }
            if (c[g] == 0)
            {
                label3.Text = Convert.ToString(a[g]+ " + " + b[g]);
                x = a[g] + b[g];
            }
            else if (c[g] == 1)
            {
                label3.Text = Convert.ToString(a[g] + " - " + b[g]);
                x = a[g] - b[g];
            }
            else if (c[g] == 2)
            {
                label3.Text = Convert.ToString(a[g] + " * " + b[g]);
                x = a[g] * b[g];
            }
            g++;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (t.Enabled == true)
            {
                tumb += 0.1;
                label5.Text = tumb.ToString("#.#");
            }
        }

        private void Button2_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
