using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        Thread th;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(OpenNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void OpenNewForm(object obj)
        {
            Application.Run(new Form1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
