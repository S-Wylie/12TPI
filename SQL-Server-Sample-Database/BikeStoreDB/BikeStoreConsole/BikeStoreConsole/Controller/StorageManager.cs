using BikeStoreConsole.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

namespace BikeStoreConsole.Controller
{
    internal class StorageManager
    {
        private SqlConnection conn;

        public StorageManager(string connectionString)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                Console.WriteLine("Connection successfull.");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid operation: The connection is already open or the connection string is invalid");
            }
            catch (SqlException e)
            {
                Console.WriteLine($"SQL Error: {e.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to database: {ex.Message}");
                throw;
            }
        }
        public void CloseConnection()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                Console.WriteLine("Connection closed.");
            }
        }
        public List<Brands> GetsAllBrands()
        {
            List<Brands> brandsList = new List<Brands>();
            string query = "SELECT * FROM production.brands";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Brands brand = new Brands()
                            {
                                BrandID = reader.GetInt32(0),
                                BrandName = reader.GetString(1)
                            };
                            brandsList.Add(brand);
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"SQL Error: {e.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving brands: {ex.Message}");
            }
            return brandsList; }

              public int UpdateBrandName(int brandId, string brandName)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE production.Brands SET BRAND_NAME = @BrandName WHERE BRAND_ID = @BrandId", conn))
            {
                cmd.Parameters.AddWithValue("@BrandName", brandName);
                cmd.Parameters.AddWithValue("@BrandId", brandId);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteBrandByName(string brandName)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM production.Brands WHERE BRAND_NAME = @BrandName", conn))
            {
                cmd.Parameters.AddWithValue("@BrandName", brandName);
                return cmd.ExecuteNonQuery();
            }
        }
    }  
    
}
