using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string email, userName, pass;

        private void button2_Click(object sender, EventArgs e)
        {
            string login, corPass ;
            FileStream fs2 = new FileStream("password.txt", FileMode.Open, FileAccess.Read);
            StreamReader srp = new StreamReader(fs2);
            corPass = srp.ReadLine();
            srp.Close();
            fs2.Close();

            FileStream fs1 = new FileStream("login.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs1);
            login = sr.ReadLine();
            sr.Close();
            fs1.Close();
            if (textBox5.Text == login && textBox6.Text == corPass)
            {
                  
                Main main = new Main();
                main.Show();
                
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Correct.Clear();
            inCorrect.Clear();
            userName = textBox1.Text;
            email = textBox2.Text;
            if (textBox3.Text == textBox4.Text)
            {
                pass = textBox3.Text;
                Correct.SetError(textBox4, "Correct!!!");
                FileStream fs = new FileStream("login.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(userName);
                sw.Close();
                fs.Close();
                FileStream fsp = new FileStream("password.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter swp = new StreamWriter(fsp);
                swp.WriteLine(pass);
                swp.Close();
                fsp.Close();
                MessageBox.Show("Registration completed successfully");
            }
            else
            {
                inCorrect.SetError(textBox4, "Incorrect!!!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
