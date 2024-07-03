using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLDBussinessLayer.clsUser;

namespace DVLDBussinessLayer
{
    public class clsApplicationTypes
    {
        public enum enApplicationTypes
        {
            NewLocalDrivingLicense = 1 ,
            RenewDrivingLicense,
            ReplacementForLostDrivingLicense,
            ReplacementForDamagedDrivingLicense,
            ReleaseDetainedDrivingLicense,
            NewInternationalLicense,
            RetakeTest
        }

        public int ApplicationTypeID {  get; set; }
        public string ApplicationTypeTitle {  get; set; }
        public float ApplicationTypeFees {  get; set; }

        private clsApplicationTypes(int ID, string Title, float Fees)
        {
            ApplicationTypeID = ID;
            ApplicationTypeTitle = Title;
            ApplicationTypeFees = Fees;
        }

        static public clsApplicationTypes FindApplicationTypeByID(int ApplicationType_ID)
        {
            string tmpApplicationTypeString = "";
            float tmpApplicationTypeFees = 0;
            if(ApplicationTypeData.GetApplicationTypeByID(ApplicationType_ID,ref tmpApplicationTypeString,ref tmpApplicationTypeFees))
            {
                return new clsApplicationTypes(ApplicationType_ID,tmpApplicationTypeString, tmpApplicationTypeFees);
            }
            else
            {
                return null;
            }
        }

        private bool _UpdateclsApplicationType()
        {
            return ApplicationTypeData.UpdateclsApplicationType(this.ApplicationTypeID,
                this.ApplicationTypeTitle, this.ApplicationTypeFees);
        }


        public bool SaveUpdate()
        {
            if(_UpdateclsApplicationType())
            {
                return true;
            }
            return false;
        }

        static public DataView GetAllApplicationTypes()
        {
            try
            {
                DataView data = ApplicationTypeData.AllApplicationTypes().DefaultView;
                return data;
            }
            catch
            {
                return null;
            }
        }


    }
}
