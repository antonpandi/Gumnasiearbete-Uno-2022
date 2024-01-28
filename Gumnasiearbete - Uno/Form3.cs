using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gumnasiearbete___Uno
{
    public partial class Form3 : Form
    {
        public Color _selectedColor;
        public Form3()
        {
            InitializeComponent();
        }
        

        private void BtnChooseColor_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;

        }

        private void RbtnRed_CheckedChanged(object sender, EventArgs e)
        {
            this._selectedColor = Color.Red;
        }

        private void RbtnGreen_CheckedChanged(object sender, EventArgs e)
        {
            this._selectedColor = Color.Green;
        }

        private void RbtnBlue_CheckedChanged(object sender, EventArgs e)
        {
            this._selectedColor = Color.Blue;
        }

        private void RbtnYellow_CheckedChanged(object sender, EventArgs e)
        {
            this._selectedColor = Color.Yellow;
        }


    }
}
