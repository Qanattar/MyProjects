using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Daily_tasks : UserControl
    {
        public Daily_tasks()
        {
            InitializeComponent();
        }
        int poss = 10;
        public void addItem(string text)
        {
            ToDoItem item = new ToDoList.ToDoItem(text);
            panel2.Controls.Add(item);
            item.Top = poss;
            poss = (item.Top + item.Height + 10);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            string taskName = textBox.Text;
            addItem(taskName);
            textBox.Text = "";
        }
    }
}
