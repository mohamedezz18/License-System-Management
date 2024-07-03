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
    public partial class uclPersonDetailsWithFilter : UserControl
    {       
        public event Action <int> GetPersonID;
       
        protected virtual void ReturnPersonID(int PersonID)
        {
            Action<int> handler = GetPersonID;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }
        private int _PersonId = -1;

        public int PersonID
        {
            get { return _PersonId; }
        }

        public clsPerson SelectedPerson
        {
            get
            {
                return uclPersonDetails.SelectedPerson;
            }
        }

        private bool _FilterEnable = true;
        public bool FilterEnable
        {
            get {return _FilterEnable;}
            set
            {
                _FilterEnable = value;
                gbFilter.Enabled = _FilterEnable;
            }
        }

        public uclPersonDetailsWithFilter()
        {
            InitializeComponent();
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
                default:
                    return "";
            }
        }

        private void uclPersonDetailsWithFilter_Load(object sender, EventArgs e)
        {
            cbFilter.Text = "None";
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text != "None")
            {
                txbSearch.Visible = true;
                btnSearch.Visible = true;
                btnAddPerson.Visible = true;
            }
            else
            {
                txbSearch.Visible = false;
                btnSearch.Visible = false;
                btnAddPerson.Visible = false;
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string FilterColumn = _Filter();
            if (txbSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                return;
            }
            if (FilterColumn == "PersonID")
            {
                int.TryParse(txbSearch.Text.Trim(), out int _PersonID);
                uclPersonDetails.LoadDataByPersonID(_PersonID);
                 _PersonId = uclPersonDetails.PersonId;
               
            }
            else if (FilterColumn == "NationalNO")
            {
                uclPersonDetails.LoadDataByNationalNO(txbSearch.Text.Trim());
                _PersonId = uclPersonDetails.PersonId;
            }

            if (GetPersonID != null)
            {
                GetPersonID(_PersonId);
            }

        }
 
        public void LoadData(int PersonID)
        {
            _PersonId=PersonID;
            uclPersonDetails.LoadDataByPersonID(PersonID);
            if (GetPersonID != null)
            {
                GetPersonID(_PersonId);
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddNewPerson addNewPerson = new frmAddNewPerson();
            addNewPerson.DataBack += AddPersonDataBack;
            addNewPerson.ShowDialog();
        }

        private void AddPersonDataBack(object sender, int PersonID)
        {
            _PersonId = PersonID;
            uclPersonDetails.LoadDataByPersonID(_PersonId);
        }
    }
}
