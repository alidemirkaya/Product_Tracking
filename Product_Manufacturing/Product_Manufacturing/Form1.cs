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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Resimleme Resimleme = new Resimleme();
        DataClasses1DataContext dc = new DataClasses1DataContext();

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(var deg in dc.WO_Products)
            {
                UC_Products uc = new UC_Products();
                if (deg.Due_Date != null)
                {
                    uc.t_duedate.Text = deg.Due_Date.Value.ToShortDateString();
                }
                else
                {
                    uc.t_enddate.Text = "---";
                }
                if (deg.End_Date != null)
                {
                    uc.t_enddate.Text = deg.End_Date.Value.ToShortDateString();
                }
                else
                {
                    uc.t_enddate.Text = "---";
                }
                if(deg.Status=="In Process")
                {
                    uc.bunifuCards1.color = Color.FromArgb(241, 210, 124);
                    uc.bunifuCards1.BackColor= Color.FromArgb(241, 210, 124);

                }
                else if (deg.Status == "Complete")
                {
                    uc.bunifuCards1.color = Color.FromArgb(167, 241, 124);
                    uc.bunifuCards1.BackColor = Color.FromArgb(167, 241, 124);
                }
                else
                {
                    uc.bunifuCards1.color = Color.FromArgb(99, 241, 232);
                    uc.bunifuCards1.BackColor = Color.FromArgb(99, 241, 232);
                }
                uc.t_piece.Text = "1";
                uc.t_startdate.Text = deg.Start_Date.Value.ToShortDateString();
                uc.t_status.Text = deg.Status;
                var sor = dc.Particle_Operations.Where(x => x.O_Track_Code == deg.Track_Code);
                int say = (sor.Count(x => x.O_Status == "Complete") * 100) /5 ;
                uc.bunifuImageButton1.Tag = deg.Track_Code;
                uc.bunifuProgressBar1.Value = Convert.ToInt32(say);
                uc.t_trackcode.Text = deg.Track_Code;
                uc.pictureBox1.Image = Resimleme.ResimGetirme(deg.Picture.ToArray());
                uc.Dock = DockStyle.Top;
                panel1.Controls.Add(uc);
                //
                
                
            }
        }
    }
}
