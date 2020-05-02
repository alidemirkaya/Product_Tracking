using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_Manufacturing
{
    public partial class Details : Form
    {
        public Details()
        {
            InitializeComponent();
        }
        public string Track_Code { get; set; }
        DataClasses1DataContext dc = new DataClasses1DataContext();
        Resimleme Resimleme = new Resimleme();

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Details_Load(object sender, EventArgs e)
        {
            var sor = dc.WO_Products.First(x => x.Track_Code == Track_Code);
            pictureBox1.Image = Resimleme.ResimGetirme(sor.Picture.ToArray());
            
            foreach(var deg in dc.Particle_Operations.Where(x => x.O_Track_Code == sor.Track_Code))
            {
                string[] item = new string[]
                {
                    deg.Op_Record.ToString(),
                    deg.Operation_Code,
                    deg.Station,
                    deg.O_Status
                };
                listView1.Items.Add(new ListViewItem(item));
            }
           
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
