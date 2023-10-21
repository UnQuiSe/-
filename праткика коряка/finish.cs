using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace праткика_коряка
{
    public partial class finish : Form
    {
        public finish()
        {
            InitializeComponent();
         
        }

        private void Finish_Load(object sender, EventArgs e)
        {
            double time = Form1.time;
            double score = Form1.score;
            int i = Form1.i;
            if (score < 36000 && score >= 29000)
            {
                pictureBox1.Image = Image.FromFile("C:/Users/Анна/Desktop/проекты/ИСП-301/Белобородов/испр/12/m41.jpg");
                label1.Text = ("очков" + score.ToString("#.#"));
                label2.Text = ("Правильных ответов " + i);
                label3.Text = (" за " + time.ToString("#.#") + "сек");
                label4.Text = ("а ты хорош");
            }
            if (score <29000 && score >= 23000)
            {
                pictureBox1.Image = Image.FromFile("C:/Users/Анна/Desktop/проекты/ИСП-301/Белобородов/испр/12/m1.jpg");
                label1.Text = ("очков" + score.ToString("#.#"));
                label2.Text = ("Правильных ответов " + i);
                label3.Text = (" за " + time.ToString("#.#") + "сек");
                label4.Text = ("уважаемо");
            }
            if (score < 23000 && score >= 17000)
            {
                pictureBox1.Image = Image.FromFile("C:/Users/Анна/Desktop/проекты/ИСП-301/Белобородов/испр/12/m31.jpg");
                label1.Text = ("очков" + score.ToString("#.#"));
                label2.Text = ("Правильных ответов " + i);
                label3.Text = (" за " + time.ToString("#.#") + "сек");
                label4.Text = ("Мог бы и получше :/");
            }
            if (score < 17000 && score >= 12000)
            {
                pictureBox1.Image = Image.FromFile("C:/Users/Анна/Desktop/проекты/ИСП-301/Белобородов/испр/12/m21.jpg");
                label1.Text = ("очков" + score.ToString("#.#"));
                label2.Text = ("Правильных ответов " + i);
                label3.Text = (" за " + time.ToString("#.#") + "сек");
                label4.Text = ("Мог бы и постараться хоть чуть чуть");
            }
            if (score < 12000 && score >= 6000)
            {
                pictureBox1.Image = Image.FromFile("C:/Users/Анна/Desktop/проекты/ИСП-301/Белобородов/испр/12/m11.jpg");
                label1.Text = ("очков" + score.ToString("#.#"));
                label2.Text = ("Правильных ответов " + i);
                label3.Text = (" за " + time.ToString("#.#") + "сек");
                label4.Text = ("Ну..... Сойдет");
            }
            if (score < 6000 && score >= 0)
            {
                pictureBox1.Image = Image.FromFile("C:/Users/Анна/Desktop/проекты/ИСП-301/Белобородов/испр/12/m01.jpg");
                label1.Text = ("очков" + score.ToString("#.#"));
                label2.Text = ("Правильных ответов " + i);
                label3.Text = (" за " + time.ToString("#.#") + "сек");
                label4.Text = ("очень слабо");
            }
            if (score < 0)
            {
                pictureBox1.Image = Image.FromFile("C:/Users/Анна/Desktop/проекты/ИСП-301/Белобородов/испр/12/m00.jpg");
                label1.Text = ("очков" + score.ToString("#.#"));
                label2.Text=("Правильных ответов " + i);
                label3.Text = (" за " + time.ToString("#.#")+"сек");
                label4.Text = ("Поздравляю с антирекордом");
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
