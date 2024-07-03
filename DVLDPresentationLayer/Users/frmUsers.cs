using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Users
{
    public partial class frmUsers : Form
    {
        private static DataTable _AllUsers = clsUser.GetAllUsers();
        private DataTable _dtUsers = _AllUsers.DefaultView.ToTable(false, "UserID", "PersonID", "FullName",
            "UserName", "IsActive");

        public frmUsers()
        {
            InitializeComponent();
        }

        void _RefreshDataToGrid()
        {
            _AllUsers = clsUser.GetAllUsers();
            _dtUsers = _AllUsers.DefaultView.ToTable(false, "UserID", "PersonID", "FullName",
            "UserName", "IsActive");
            dgvUsers.DataSource = _dtUsers;
            lblRecord.Text = dgvUsers.Rows.Count.ToString();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {

            _RefreshDataToGrid();
            cbFilter.SelectedIndex = 0;
            
        }

        private string _Filter()
        {
            switch (cbFilter.Text)
            {
                case "None":
                    return "None";
                case "PersonID":
                    return "PersonID";
                case "UserID":
                    return "UserID";
                case "Password":
                    return "Password";
                case "IsActive":
                    return "IsActive";
                case "Username":
                    return "Username";
                default:
                    return "";
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbSearch.Visible = (cbFilter.Text != "None" && cbFilter.Text != "IsActive");
            cbActive.Visible = (cbFilter.Text == "IsActive");
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = _Filter();
            if (txbSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblRecord.Text = _dtUsers.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "PersonID" || FilterColumn == "UserID")
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txbSearch.Text.Trim());
            }
            else
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txbSearch.Text.Trim());
            }
            lblRecord.Text = dgvUsers.Rows.Count.ToString();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditUser AddUser = new frmAddEditUser();
            AddUser.ShowDialog();
            _RefreshDataToGrid();
        }

        private void EditUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser EditUser = new frmAddEditUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            EditUser.ShowDialog();
            _RefreshDataToGrid();
        }

        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (_Filter() == "UserID" || _Filter() == "PersonID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // لمنع إدخال الحرف
                }
            }
        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbActive.Text == "Yes")
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", cbFilter.Text, true);
            }

            else if (cbActive.Text == "No")
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", cbFilter.Text, false);
            }

            else
            {
                _RefreshDataToGrid();
            }
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword ChangePassword = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            ChangePassword.ShowDialog();
            _RefreshDataToGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User [" + dgvUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.", "Delete Perosn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _RefreshDataToGrid();
                }
                else
                {
                    MessageBox.Show("User Was Not Deleted Because it has Data Linked To It.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User [" + dgvUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.", "Delete Perosn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _RefreshDataToGrid();
                }
                else
                {
                    MessageBox.Show("User Was Not Deleted Because it has Data Linked To It.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void UserDetails_Click(object sender, EventArgs e)
        {
            frmUserDetails userDetails = new frmUserDetails((int)dgvUsers.CurrentRow.Cells[0].Value);
            userDetails.ShowDialog();
        }

       
    }
}
