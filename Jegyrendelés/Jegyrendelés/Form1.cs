using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jegyrendelés
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int km = 0;
            try
            {
                //Beolvasom a Textboxxból az értéket
                km = Convert.ToInt32(txKM.Text);
            }
            catch (Exception hiba)
            {

               MessageBox.Show("Számot adj meg!");
            }
            
            //km-enként 35Ft
            double fizetendo = km * 35;
            //Az 1.Osztály a comboboxban másfélszeresét kell fizetni
            if (cbOsztaly.SelectedIndex == 0)
            {
                fizetendo *= 1.5;
            }
            // cdOsztaly.SelectedItem  - Ez az az érték(Item) Ami bele van Írva a comboboxba


            //Rásoógombok vizsgalata
            if (radioButton2.Checked == true)
            {
                fizetendo *= 0.5;
            }
            else if (radioButton3.Checked == true)
            {
                fizetendo *= 0.1;
            }
            txFizetendo.Text = Convert.ToString(fizetendo);
        }
    }
}
