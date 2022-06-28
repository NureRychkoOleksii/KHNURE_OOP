using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Models;

namespace WinFormsApp
{
    public partial class Form3 : Form
    {
        Thread th;
        private readonly User _user;
        public Form3(User user)
        {
            _user = user;
            InitializeComponent();
            textBox1.Enabled = false;
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
            Application.Run(new Form1(_user));
        }
    }
}
