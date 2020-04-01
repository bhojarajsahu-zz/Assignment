using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Models;

namespace Assignment.DAL
{
    public class UtilityMethods
    {
        public bool AddProperty(PropertyData property)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Utility.GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("spAddProperty", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Address", property.Address); 
                    cmd.Parameters.AddWithValue("@Year_built", property.YearBuilt);
                    cmd.Parameters.AddWithValue("@List_price", property.ListPrice);
                    cmd.Parameters.AddWithValue("@Monthly_rent", property.MonthlyRent);
                    cmd.Parameters.AddWithValue("@Gross_yield", property.GrossYield);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
