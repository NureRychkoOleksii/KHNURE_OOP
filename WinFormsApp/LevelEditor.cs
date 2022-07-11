using Core.NewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class LevelEditor : Form
    {
        Map map;
        public LevelEditor()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(mapXSize.Text);
            int y = Convert.ToInt32(mapYSize.Text);
            map = new Map(x, y);
            CreateMap(x, y);
        }
        
        private void CreateMap(int x, int y)
        {
            mapPicture.Size = new Size(x * 15, y * 15);
            map.CreateEmptyMap();
        }
    }
}
