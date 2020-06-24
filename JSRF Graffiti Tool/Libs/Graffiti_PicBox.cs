using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSRF_Graffiti_Tool.Libs
{
    public partial class Graffiti_PicBox : UserControl
    {
        public bool selected = false;
        public string filepath { get; set; }

        public Graffiti_PicBox()
        {
            InitializeComponent();
        }

        public void set_image(Image img)
        {
            pictureBox.Image = img;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (selected)
            {
                deselect();
            }
            else
            {
                select();
            }
        }


        public void deselect()
        {
            if (selected)
            {
                selected = false;
                this.BackColor = Color.Gainsboro;
            }
        }

        // display orange background/outline when selected
        public void select()
        {
            if (!selected)
            {
                // deselect other items
                FlowLayoutPanel panel = (FlowLayoutPanel)this.Parent;

                foreach (var item in panel.Controls)
                {
                    (((Graffiti_PicBox)item)).deselect();
                }

                // mark this one as selected
                selected = true;
                this.BackColor = Color.Tomato;
            }
        }
    }
}
