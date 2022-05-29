using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportEventResultsV2.DbContent
{
    public class SqlStrings
    {
        public static string selectedGender = "";
        public static string selectedCompany = "";
        private string _allResults = "SELECT name, city, company, result, gender, updatedAt FROM UserSchemas";
        private string _resultsWithGenderFilter = $"SELECT name, city, company, result, gender, updatedAt FROM UserSchemas WHERE gender = '{selectedGender}'";
        private string _resultsWithCompanyFilter = $"SELECT name, city, company, result, gender, updatedAt FROM UserSchemas WHERE company = '{selectedCompany}'";
        private string _resultsWithCompanyAndGenderFilter = $"SELECT name, city, company, result, gender, updatedAt FROM UserSchemas WHERE gender = '{selectedGender}' AND company = '{selectedCompany}'";

        public string SqlString(string gender, string company)
        {
            if ((gender == string.Empty || gender == "все" || gender == null) && (company == string.Empty || company == "Все предприятия" || company == null))
            {
                return _allResults;
            }
            else if (gender != string.Empty && gender != "все" && gender != null && (company == string.Empty || company == "Все предприятия" || company == null))
            {
                selectedGender = gender;
                return _resultsWithGenderFilter = $"SELECT name, city, company, result, gender, updatedAt FROM UserSchemas WHERE gender = '{selectedGender}'";
            }
            else if ((gender == string.Empty || gender == "все") && (company != string.Empty && company != "Все предприятия"))
            {
                selectedCompany = company;
                return _resultsWithCompanyFilter = $"SELECT name, city, company, result, gender, updatedAt FROM UserSchemas WHERE company = '{selectedCompany}'";
            }
            else
            {
                selectedGender = gender;
                selectedCompany = company;
                return _resultsWithCompanyAndGenderFilter = $"SELECT name, city, company, result, gender, updatedAt FROM UserSchemas WHERE gender = '{selectedGender}' AND company = '{selectedCompany}'";
            }
        }
    }
}
