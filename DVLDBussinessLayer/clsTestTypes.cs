using DVLDDataAccessLayer;
using System.Data;

namespace DVLDBussinessLayer
{
    public class clsTestTypes
    {
        public enum enTestType { VisionTest = 1 , WriteTest = 2, StreetTest = 3 }

        public int TestTypeID { get; set; }
        public string TypeTitle { get; set; }
        public string TypeDescription { get; set; }
        public float TypeFees { get; set; }

        private clsTestTypes(int ID, string Title, string Description, float Fees)
        {
            TestTypeID = ID;
            TypeTitle = Title;
            TypeDescription = Description;
            TypeFees = Fees;
        }

        static public clsTestTypes FindTestTypeByID(int TestType_ID)
        {
            string tmpTestTypeString = "", tmpTypeDescription = "";
            float tmpTestTypeFees = 0;
            if (TestTypesData.GetTestTypeByID(TestType_ID, ref tmpTestTypeString, ref tmpTypeDescription, ref tmpTestTypeFees))
            {
                return new clsTestTypes(TestType_ID, tmpTestTypeString, tmpTypeDescription, tmpTestTypeFees);
            }
            else
            {
                return null;
            }
        }

        private bool _UpdateTestType()
        {
            return TestTypesData.UpdateTestType(this.TestTypeID,
                this.TypeTitle, this.TypeDescription, this.TypeFees);
        }


        public bool SaveUpdate()
        {
            if (_UpdateTestType())
            {
                return true;
            }
            return false;
        }

        static public DataView GetAllTestTypes()
        {
            try
            {
                DataView data = TestTypesData.AllTestTypes().DefaultView;
                return data;
            }
            catch
            {
                return null;
            }
        }
    }
}
