using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZAWDotNetTrainingBatch2.WindowsFormApp1.Database.AppDbContexModels;

namespace ZAWDotNetTrainingBatch2.WinFormsApp1
{

    public partial class FrmProduct : Form
    {
        private readonly AppDbContext _db;
        private int _editId;
        public FrmProduct()
        {
            InitializeComponent();
            _db = new AppDbContext();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _db.TblProducts.Add(new TblProduct
                {
                    ProductCode = txtProductCode.Text.Trim(),
                    ProductItem = txtProductItem.Text.Trim(),
                    Price = Convert.ToDecimal(txtPrice.Text.Trim()),
                    IsDelete = false,
                    CreateAt = DateTime.Now,
                });
                int result = _db.SaveChanges();
                string messageStr = result > 0 ? "Saving Successful!" : "Saving Failed";
                MessageBox.Show(messageStr, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtProductCode.Clear();
                txtProductItem.Clear();
                txtPrice.Clear();

                txtProductCode.Focus();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmProduct_Load(object sender, EventArgs e)
        {
            BlindData();
        }

        private void BlindData()
        {
            try
            {
                dgvProductList.DataSource = _db.TblProducts.ToList();
            }
            catch (Exception)
            {


            }

        }

        private void dgvProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
        
    

