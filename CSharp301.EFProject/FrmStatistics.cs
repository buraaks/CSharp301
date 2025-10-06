using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EFTravelDbEntities db = new EFTravelDbEntities();

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapasity.Text = db.Location.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAvgCapasity.Text = ((double)(db.Location.Average(x => (double?)x.Capacity) ?? 0)).ToString("F2");
            lblAvgLocationPrice.Text = ((decimal)(db.Location.Average(x => (decimal?)x.Price) ?? 0)).ToString("F2") + " ₺";
            int LastLocationID = db.Location.Max(x => x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == LastLocationID).Select(y => y.Country).FirstOrDefault();
            lblBerlinCapasity.Text = db.Location.Where(x => x.City == "Berlin").Select(y => y.Capacity).FirstOrDefault().ToString();
            lblTürkiyeCapasityAvg.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();
            lblRomaGuideName.Text = db.Location.Where(x => x.City == "Roma").Select(y => y.Guide.GuideName + " " + y.Guide.GuideSurname).FirstOrDefault();
            lblMaxCapasityLocaiton.Text = db.Location.Where(x => x.Capacity == db.Location.Max(y => y.Capacity)).Select(z => z.City).FirstOrDefault();
            lblMaxPriceLocation.Text = db.Location.Where(x => x.Price == db.Location.Max(y => y.Price)).Select(z => z.City).FirstOrDefault();
            lblErenLocationCount.Text = db.Location.Where(x => x.Guide.GuideName == "Eren").Count().ToString();
        }
    }
}
