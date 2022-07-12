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
        Thread _thread;
        private readonly User _user;
        public Instruction(User user)
        {
            _user = user;
            InitializeComponent();
            textBox1.Enabled = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _thread = new Thread(OpenGame);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }

        private void OpenGame(object obj)
        {
            Application.Run(new GameForm(_user));
        }
        private void OpenMapChoose(object obj)
        {
            Application.Run(new ChooseMapForm(_user));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            _thread = new Thread(OpenMapChoose);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }
    }
}
