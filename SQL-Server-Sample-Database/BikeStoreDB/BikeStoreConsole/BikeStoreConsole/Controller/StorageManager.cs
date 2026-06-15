using BikeStoreConsole.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

namespace BikeStoreConsole.Controller
{
    public class StorageManager
    {
        private SqlConnection conn;
        public StorageManager(string connectionString)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                Console.WriteLine("Connection Successful");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid connection string or connection already open.");
            }
            catch (SqlException e)
            {
                Console.WriteLine($"SQL Error: {e.Message}");

                Console.WriteLine($"SQL Error: {e.Message}");
                if (e.Message.Contains("attach an auto-named database"))
                {
                    Console.WriteLine("Fix: Database is already attached OR file is in use.");
                    Console.WriteLine("Try this:");
                    Console.WriteLine("1. Remove AttachDbFilename from connection string");
                    Console.WriteLine("2. Use Initial Catalog instead");
                    Console.WriteLine("3. Or delete/rename duplicate DB in SQL Server");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to database: {ex.Message}");
            }
        }
        public void CloseConnection()
        {

            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                Console.WriteLine("Connection Closed");
            }
        }
        public List<Brands> GetAllBrands()
        {
            List<Brands> brandsList = new List<Brands>();

            string query = "SELECT * FROM production.Brands";
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
            return brandsList;
        }
        public int UpdateBrandName(int brandId, string brandName)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE production.Brands SET BRAND_NAME = @BrandName WHERE BRAND_ID = @BrandId", conn))

            {
                cmd.Parameters.AddWithValue("@BrandName", brandName);
                cmd.Parameters.AddWithValue("@BrandId", brandId);
                return cmd.ExecuteNonQuery();
            }
        }
        public int InsertBrand(string brandName)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO production.Brands (BRAND_NAME) VALUES (@BrandName); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@BrandName", brandName);
                return Convert.ToInt32(cmd.ExecuteScalar());
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