using CSharp301.BusinessLayer.Abstract;
using CSharp301.BusinessLayer.Concrete;
using CSharp301.DataAccessLayer.EntityFramework;
using CSharp301.EntityLayer.Concrete;
using System;
using System.Windows.Forms;


namespace CSharp301.PresentationLayer
{
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;
        public FrmCategory()
        {
            _categoryService = new CategoryManeger(new EfCategoryDal());
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.GetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            category.CategoryStatus = true;
            _categoryService.TInsert(category);
            MessageBox.Show("Kategori Eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryId.Text);
            var deletedValue = _categoryService.TGetById(id);
            _categoryService.TDelete(deletedValue);
            MessageBox.Show("Kategori Silindi");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryId.Text);
            var categoryValue = _categoryService.TGetById(id);
            dataGridView1.DataSource = categoryValue;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int updateId = Convert.ToInt32(txtCategoryId.Text);
            var updatedValue = _categoryService.TGetById(updateId);
            updatedValue.CategoryName = txtCategoryName.Text;
            updatedValue.CategoryStatus = true;
            _categoryService.TUpdate(updatedValue);
            MessageBox.Show("Kategori Güncellendi");
        }
    }
}
