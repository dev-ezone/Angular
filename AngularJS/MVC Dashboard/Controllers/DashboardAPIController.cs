using MVC_Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_Dashboard.Controllers
{
    public class DashboardAPIController : ApiController
    {
        [HttpGet]
        public string GetDashboardDetails(string sqlQuery, string columnName, string tableNames, Nullable<int> isCondition, string conditionList, Nullable<int> isGroupBY, string groupBYList, Nullable<int> isOrderBY, string orderBYList)
        {
            if (sqlQuery == null)
                sqlQuery = "";

            if (columnName == null)
                columnName = "";

            if (tableNames == null)
                tableNames = "";

            if (isCondition == null)
                isCondition = 0;

            if (conditionList == null)
                conditionList = "";

            if (isGroupBY == null)
                isGroupBY = 0;

            if (groupBYList == null)
                groupBYList = "";

            if (isOrderBY == null)
                isOrderBY = 0;

            if (orderBYList == null)
                orderBYList = "";

            string connectionString = Config.ConnectionString;
                //ConfigurationManager.ConnectionStrings["dashboard"].ToString();
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the SQL command and add Sp name
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "USP_Dashboard_Select";
                command.CommandType = CommandType.StoredProcedure;

                // Add parameter for Query.
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@sqlQuery";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = sqlQuery;

                command.Parameters.Add(parameter);

                // Add parameter for Column Names
                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@columnName";
                parameter1.SqlDbType = SqlDbType.NVarChar;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = columnName;

                command.Parameters.Add(parameter1);

                // Add parameter for Table names
                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@tableNames";
                parameter2.SqlDbType = SqlDbType.NVarChar;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = tableNames;

                command.Parameters.Add(parameter2);

                // Add parameter to check for  Where condition
                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@isCondition";
                parameter3.SqlDbType = SqlDbType.NVarChar;
                parameter3.Direction = ParameterDirection.Input;
                parameter3.Value = isCondition;

                command.Parameters.Add(parameter3);

                // Add parameter for Where conditions
                SqlParameter parameter4 = new SqlParameter();
                parameter4.ParameterName = "@ConditionList";
                parameter4.SqlDbType = SqlDbType.NVarChar;
                parameter4.Direction = ParameterDirection.Input;
                parameter4.Value = conditionList;

                command.Parameters.Add(parameter4);

                // Add parameter to check for  Group By 
                SqlParameter parameter5 = new SqlParameter();
                parameter5.ParameterName = "@isGroupBY";
                parameter5.SqlDbType = SqlDbType.NVarChar;
                parameter5.Direction = ParameterDirection.Input;
                parameter5.Value = isGroupBY;

                command.Parameters.Add(parameter5);

                // Add parameter for Group By
                SqlParameter parameter6 = new SqlParameter();
                parameter6.ParameterName = "@groupBYList";
                parameter6.SqlDbType = SqlDbType.NVarChar;
                parameter6.Direction = ParameterDirection.Input;
                parameter6.Value = groupBYList;

                command.Parameters.Add(parameter6);

                // Add parameter to check for Order By
                SqlParameter parameter7 = new SqlParameter();
                parameter7.ParameterName = "@isOrderBY";
                parameter7.SqlDbType = SqlDbType.NVarChar;
                parameter7.Direction = ParameterDirection.Input;
                parameter7.Value = isOrderBY;

                command.Parameters.Add(parameter7);

                // Add parameter  for OrderBY
                SqlParameter parameter8 = new SqlParameter();
                parameter8.ParameterName = "@orderBYList";
                parameter8.SqlDbType = SqlDbType.NVarChar;
                parameter8.Direction = ParameterDirection.Input;
                parameter8.Value = orderBYList;

                command.Parameters.Add(parameter8);

                connection.Open();

                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    da.Fill(ds);
                    connection.Close();
                }

            }

            return Utilities.DataTableToJSONWithJavaScriptSerializer(ds.Tables[0]);
        }
    }
}
