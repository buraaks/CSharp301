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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EFTravelDbEntities db = new EFTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;
            MessageBox.Show("Lokasyonlar Listelendi");
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new 
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();

            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values; 

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Capacity = byte.Parse(nudCapacity.Text);
            location.City=txtCity.Text;
            location.Country=txtCountry.Text;
            location.Price=decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Lokasyon Eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var location = db.Location.Find(id);
            db.Location.Remove(location);
            db.SaveChanges();
            MessageBox.Show("Lokasyon Silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValue= db.Location.Find(id);
            updateValue.DayNight = txtDayNight.Text;
            updateValue.Price = decimal.Parse(txtPrice.Text);
            updateValue.Capacity = byte.Parse(nudCapacity.Text);
            updateValue.City = txtCity.Text;
            updateValue.Country = txtCountry.Text;
            updateValue.GuideId = (int)cmbGuide.SelectedValue;
            db.SaveChanges();
            MessageBox.Show("Lokasyon Güncellendi");
        }
    }
}
