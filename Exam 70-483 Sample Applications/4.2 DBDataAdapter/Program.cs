using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _4._2_DBDataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection cn = new SqlConnection();
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["database1"];
            cn.ConnectionString = settings.ConnectionString;

            /**
             * InsertCommand Example
             **/
            try
            {
                cn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Product", cn);

                // Create insert command
                SqlCommand insert = new SqlCommand();
                insert.Connection = cn;
                insert.CommandType = CommandType.Text;
                insert.CommandText = "INSERT INTO Product (Name, Price) VALUES (@Name, @Price)";

                // Create the parameters
                insert.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50, "Name"));
                insert.Parameters.Add(new SqlParameter("@Price", SqlDbType.Money, 8, "Price"));

                // Associate the insert command with the DataAdapter
                da.InsertCommand = insert;

                // Get the data
                DataSet ds = new DataSet();
                da.Fill(ds, "Product");

                // Add a new row
                DataRow newRow = ds.Tables[0].NewRow();
                newRow["Name"] = "Mars Bar";
                newRow["Price"] = 2.50;
                ds.Tables[0].Rows.Add(newRow);

                // Update the database
                da.Update(ds.Tables[0]);

                // Close database connection
                cn.Close();

            }
            catch (SqlException e)
            {
                Debug.WriteLine("Error: " + e.Message);
            }

            /**
             * DeleteCommand and UpdateCommand Example
             * */
            try
            {
                cn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Product", cn);

                // Create the Update command
                SqlCommand update = new SqlCommand();
                update.Connection = cn;
                update.CommandType = CommandType.Text;
                update.CommandText = "UPDATE Product SET Name = @Name, Price = @Price " +
                                    "WHERE Id = @Id";

                // Create the parameters
                update.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50, "Name"));
                update.Parameters.Add(new SqlParameter("@Price", SqlDbType.Money, 8, "Price"));
                update.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 4, "Id"));

                // Create the Delete command
                SqlCommand delete = new SqlCommand();
                delete.Connection = cn;
                delete.CommandType = CommandType.Text;
                delete.CommandText = "DELETE FROM Product WHERE Id = @Id";

                // Create the parameters
                SqlParameter deleteParameter = new SqlParameter("@Id", SqlDbType.Int, 4, "Id");
                deleteParameter.SourceVersion = DataRowVersion.Original;
                delete.Parameters.Add(deleteParameter);

                // Associate the update and delete commands with the DataAdapter
                da.UpdateCommand = update;
                da.DeleteCommand = delete;

                // Get the data
                DataSet ds = new DataSet();
                da.Fill(ds, "Product");

                // Update the first row
                ds.Tables[0].Rows[0]["Name"] = "Milky Way";
                ds.Tables[0].Rows[0]["Price"] = 0.75;

                // Delete the second row
                ds.Tables[0].Rows[1].Delete();

                // Update the database
                da.Update(ds.Tables[0]);

                cn.Close();
            }
            catch (SqlException e)
            {
                Debug.WriteLine("Error: " + e.Message);
            }
        }
    }
}
