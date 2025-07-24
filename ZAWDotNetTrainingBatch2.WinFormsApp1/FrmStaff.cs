

using Azure.Core.GeoJson;
using MailKit.Net.Smtp;
using MimeKit;
using ZAWDotNetTrainingBatch2.WindowsFormApp1.Database.AppDbContexModels;

namespace ZAWDotNetTrainingBatch2.WinFormsApp1

{
    public partial class FrmStaff : Form
    {
        private readonly AppDbContext _db;
        private int _editId;
        public FrmStaff()
        {
            InitializeComponent();
            _db = new AppDbContext();
            dgvData.AutoGenerateColumns = false;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtPassword.Text = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);

                _db.TblStaffs.Add(new TblStaff
                {
                    Email = txtEmail.Text.Trim(), // " Mg Mg "
                    IsDelete = false,
                    MobileNo = txtMobileNo.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Position = cobPosition.Text.Trim(),
                    StaffCode = txtCode.Text.Trim(),
                    StaffName = txtName.Text.Trim()
                });
                int result = _db.SaveChanges();
                string messageStr = result > 0 ? "Saving Successful." : "Saving Failed.";
                MessageBox.Show(messageStr, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Sann Lynn Htun", "sannlynnhtun.ace@gmail.com"));
                message.To.Add(new MailboxAddress(txtName.Text.Trim(), txtEmail.Text.Trim()));
                message.Subject = "Mini POS - User Creation";

                string body = $@"Your Staff Code is {txtCode.Text.Trim()}.
                                Your password is {txtPassword.Text}.";

                message.Body = new TextPart("plain")
                {
                    Text = body
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate("zawhtweoo888@gmail.com", "kgom bcum apzn sqin"); // email & app password https://myaccount.google.com/apppasswords

                    client.Send(message);
                    client.Disconnect(true);
                }

                txtCode.Clear();
                txtEmail.Clear();
                txtMobileNo.Clear();
                txtName.Clear();
                txtPassword.Clear();
                cobPosition.SelectedIndex = -1;
                txtCode.Focus();
                BindData();

            }
            catch (Exception ex)
            {


            }

        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            try
            {

                dgvData.DataSource = _db.TblStaffs.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return; // Ignore header row

            //if (e.ColumnIndex == 0)
            if (e.ColumnIndex == dgvData.Columns["colEdit"].Index)
            {
                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString()!);
                var item = _db.TblStaffs.FirstOrDefault(x => x.StaffId == id);
                if (item is null)
                {
                    return;
                }

                txtCode.Text = item.StaffCode;
                txtEmail.Text = item.Email;
                txtMobileNo.Text = item.MobileNo;
                txtName.Text = item.StaffName;
                cobPosition.Text = item.Position;
                txtPassword.Text = item.Password;
                _editId = id;

                btnSave.Text = "Update";

            }
            else if (e.ColumnIndex == dgvData.Columns["colDelete"].Index)
            {
               var confirm =  MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString()!);
                var item = _db.TblStaffs.FirstOrDefault(x => x.StaffId == id);
                if (item is null)
                {
                    return;
                }
                _db.TblStaffs.Remove(item);
               int result = _db.SaveChanges();

                string messageStr = result > 0 ? "Delete Successful." : "Delete Failed.";
                MessageBox.Show(messageStr, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindData();

            }
        }
    }
}