using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsLicenseClasses
    {
        public int LicenseClassID {  get; set; }
        public string ClassDescription {  get; set; }
        public string ClassName { get; set; }
        public byte MinimumAllowedAge {  get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

        public clsLicenseClasses(int licenseClassID, string classDescription, string className,
            byte minimumAllowedAge, byte defaultValidityLength, float classFees)
        {
            LicenseClassID = licenseClassID;
            ClassDescription = classDescription;
            ClassName = className;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
        }

        static public clsLicenseClasses FindLicenseClasseByID(int ID)
        {
            string tmp_ClassDescription = "", tmp_ClassName = "";
            byte tmp_MinimumAllowedAge = 0, tmp_DefaultValidityLength = 0;
            float tmp_ClassFees = 0;
            if (LicenseClassesData.GetLicenseClasseById(ID,ref tmp_ClassDescription,ref tmp_ClassName
                ,ref tmp_MinimumAllowedAge,ref tmp_DefaultValidityLength, ref tmp_ClassFees))
            {
                return new clsLicenseClasses(ID, tmp_ClassDescription, tmp_ClassName,
                    tmp_MinimumAllowedAge,tmp_DefaultValidityLength,tmp_ClassFees);
            }
            else
            {
                return null;
            }
        }

        static public clsLicenseClasses FindLicenseClasseByName(string Name)
        {
            int tmp_ClassID = -1;
            string tmp_ClassDescription = "";
            byte tmp_MinimumAllowedAge = 0, tmp_DefaultValidityLength = 0;
            float tmp_ClassFees = 0;
            if (LicenseClassesData.GetLicenseClasseByName(ref tmp_ClassID, ref tmp_ClassDescription, Name
                , ref tmp_MinimumAllowedAge, ref tmp_DefaultValidityLength, ref tmp_ClassFees))
            {
                return new clsLicenseClasses(tmp_ClassID, tmp_ClassDescription, Name,
                    tmp_MinimumAllowedAge, tmp_DefaultValidityLength, tmp_ClassFees);
            }
            else
            {
                return null;
            }
        }

        static public DataTable ListOfLicenseClasse()
        {
            return LicenseClassesData.GetListLicenseClasses();
        }


    }
}
