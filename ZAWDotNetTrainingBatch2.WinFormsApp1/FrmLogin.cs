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
    public partial class FrmLogin : Form
    {
        private readonly AppDbContext _db;
        public FrmLogin()
        {
            InitializeComponent();
            _db = new AppDbContext();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string staffCode = txtUsername.Text.Trim();
            string Password = txtPassword.Text.Trim();

            var item = _db.TblStaffs
                .FirstOrDefault(x => x.StaffCode == staffCode && x.Password == Password);
            if (item is null)
            {
                MessageBox.Show("Invalid Username or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Hide();
            FrmMenu frm = new FrmMenu();
            frm.ShowDialog();

            this.Show();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtPassword.Focus(); // Move focus to the password field
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e); // Trigger the login button click event
            }
        }
    }
}
