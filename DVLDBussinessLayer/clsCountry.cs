using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;
namespace DVLDBussinessLayer
{
    public class clsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        private clsCountry(int ID, string Country)
        {
            CountryID = ID;
            CountryName = Country;
        }

        public clsCountry()
        {
            CountryID = -1;
            CountryName = "";
        }
        
        static public clsCountry FindCountryByID(int CountryID)
        {
            string tmp_Countryname = "";
            if (CountryData.GetCountryByID(CountryID,ref tmp_Countryname))
            {
                return new clsCountry(CountryID,tmp_Countryname);
            }
            else
            {
                return null;
            }      
        }

        static public clsCountry FindCountryByName(string CountryName)
        {
            int tmp_CountryID = 0;
            if (CountryData.GetCountryByName(ref tmp_CountryID, CountryName))
            {
                return new clsCountry(tmp_CountryID, CountryName);
            }
            else
            {
                return null;
            }
        }

        static public DataTable ListCountry()
        {
             
            return CountryData.GetListCountry();
        }
    }
}
