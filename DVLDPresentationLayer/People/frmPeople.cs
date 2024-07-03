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

namespace DVLDPresentationLayer.People
{
    public partial class frmPeople : Form
    {
        
        private static DataTable _Allpeople = clsPerson.ListPeople();
        private DataTable _dtPeople = _Allpeople.DefaultView.ToTable();
            
        public frmPeople()
        {
            InitializeComponent();
            
        }

        void _RefreshDataToGrid()
        {
            _Allpeople = clsPerson.ListPeople();
            _dtPeople = _Allpeople.DefaultView.Table;
            dgvPeople.DataSource = _dtPeople;
            lblRecord.Text = dgvPeople.Rows.Count.ToString();
        }

        private string _Filter()
        {
            switch (cbFilter.Text)
            {
                case "None":                   
                    return "None";                    
                case "PersonID":              
                    return "PersonID";
                case "NationalNO":                
                    return "NationalNO";
                case "FirstName":                   
                    return "FirstName";
                case "SecondName":                   
                    return "SecondName";
                case "ThirdName":                  
                    return "ThirdName";
                case "LastName":                  
                    return "LastName";
                case "Nationality":                   
                    return "Nationality";
                case "Gender":                    
                    return "Gender";
                case "Phone":                    
                    return "Phone";
                case "Email":                    
                    return "Email";
                default:
                    return "";
            }
        }

        private void frmPeople_Load(object sender, EventArgs e)
        {
            _RefreshDataToGrid();
            cbFilter.SelectedIndex = 0;
            
            
        }
         

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete person [" + dgvPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.","Delete Perosn",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    _RefreshDataToGrid();
                }
                else
                {
                    MessageBox.Show("Person Was Not Deleted Because it has Data Linked To It.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddNewPerson AddNewPerson = new frmAddNewPerson();
            AddNewPerson.ShowDialog();
            _RefreshDataToGrid();
            
        }

        private void txbSearch_TextChanged(object sender = default, EventArgs e = default)
        {
            string FilterColumn = _Filter();
            if (txbSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecord.Text = _dtPeople.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "PersonID")
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txbSearch.Text.Trim());
            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txbSearch.Text.Trim());
            }
            lblRecord.Text = dgvPeople.Rows.Count.ToString();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbSearch.Visible = (cbFilter.Text != "None");

        }

        private void EditPerson_Click(object sender, EventArgs e)
        {
            frmAddNewPerson EditPerosn = new frmAddNewPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            EditPerosn.ShowDialog();
            _RefreshDataToGrid();
        }

        private void DeletePerson_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete person [" + dgvPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Delete Perosn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _RefreshDataToGrid();
                }
                else
                {
                    MessageBox.Show("Person Was Not Deleted Because it has Data Linked To It.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PersonDetails_Click(object sender, EventArgs e)
        {
            frmPerosnDetails perosnDetails = new frmPerosnDetails((int)dgvPeople.CurrentRow.Cells[0].Value);
            perosnDetails.ShowDialog();
            _RefreshDataToGrid();
        }

        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (_Filter() == "PersonID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // لمنع إدخال الحرف
                }
            }
        }
    }
}
