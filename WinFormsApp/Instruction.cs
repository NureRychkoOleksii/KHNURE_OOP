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
    public partial class Instruction : Form
    {
        private readonly User _user;
        public Instruction(User user)
        {
            _user = user;
            InitializeComponent();
            textBox1.Enabled = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new GameForm(_user);
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new ChooseMapForm(_user);
            form.Show();
        }
    }
}
