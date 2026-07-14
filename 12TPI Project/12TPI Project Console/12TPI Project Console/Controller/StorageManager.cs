using _12TPI_Project_Console.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

namespace _12TPI_Project_Console.Controller
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
        public List<Planes> GetAllPlanes()
        {
            List<Planes> planesList = new List<Planes>();

            string query = "SELECT * FROM Planes";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Planes plane = new Planes()
                            {
                                RegistrationID = reader.GetInt32(0),
                                Manufacturer = reader.GetString(1),
                                Model = reader.GetString(2),
                                PassengerCapacity = reader.GetInt32(3),
                                CargoCapacity = reader.GetInt32(4),
                                MinimumTakeoff = reader.GetInt32(5),
                                MinimumLanding = reader.GetInt32(6)
                            };
                            planesList.Add(plane);
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
                Console.WriteLine($"Error retrieving Planes: {ex.Message}");
            }
            return planesList;
        }
        public List<Flights> GetAllFlights()
        {
            List<Flights> flightsList = new List<Flights>();

            string query = "SELECT * FROM Flights";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Flights flight = new Flights()
                            {
                                FlightID = reader.GetInt32(0),
                                PlaneRegistrationID = reader.GetInt32(1),
                                FlightNumber = reader.GetInt32(2),
                                PilotName = reader.GetString(3),
                                DepartingDateTime = reader.GetDateTime(4),
                                DepartingAirport = reader.GetString(5),
                                ArrivingDateTime = reader.GetDateTime(6),
                                ArrivingAirport = reader.GetString(7),
                                Status = reader.GetString(8)
                            };
                            flightsList.Add(flight);
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
                Console.WriteLine($"Error retrieving Flights: {ex.Message}");
            }
            return flightsList;
        }
        public List<Airports> GetAllAirports()
        {
            List<Airports> airportsList = new List<Airports>();

            string query = "SELECT * FROM Airports";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Airports airport = new Airports()
                            {
                                IATACode = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Coordinates = reader.GetString(2),
                                Country = reader.GetString(3),
                                Timezone = reader.GetString(4),
                            };
                            airportsList.Add(airport);
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
                Console.WriteLine($"Error retrieving Airports: {ex.Message}");
            }
            return airportsList;
        }
        public List<Passengers> GetAllPassengers()
        {
            List<Passengers> passengersList = new List<Passengers>();

            string query = "SELECT * FROM Passengers";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Passengers passenger = new Passengers()
                            {
                                CustomerID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                MembershipStatus = reader.GetString(3)
                            };
                            passengersList.Add(passenger);
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
                Console.WriteLine($"Error retrieving Passengers: {ex.Message}");
            }
            return passengersList;
        }
        public List<PassengerTickets> GetAllPassengerTickets()
        {
            List<PassengerTickets> passengerTicketsList = new List<PassengerTickets>();

            string query = "SELECT * FROM PassengerTickets";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PassengerTickets passengerTicket = new PassengerTickets()
                            {
                                TicketID = reader.GetInt32(0),
                                FlightID = reader.GetInt32(1),
                                CustomerID = reader.GetInt32(2),
                                ClassName = reader.GetString(3),
                                MealChoice = reader.GetString(4),
                            };
                            passengerTicketsList.Add(passengerTicket);
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
                Console.WriteLine($"Error retrieving Tickets: {ex.Message}");
            }
            return passengerTicketsList;
        }
        public List<Classes> GetAllClasses()
        {
            List<Classes> classesList = new List<Classes>();

            string query = "SELECT * FROM Classes";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Classes Class = new Classes()
                            {
                                ClassCode = reader.GetString(0),
                                Name = reader.GetString(1),
                                ChangesPermitted = reader.GetString(2),
                                BaggageAllowance = reader.GetInt32(3),
                                MilesAccural = reader.GetString(4)
                            };
                            classesList.Add(Class);
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
                Console.WriteLine($"Error retrieving Classes: {ex.Message}");
            }
            return classesList;
        }
        public List<MealOptions> GetAllMealOptions()
        {
            List<MealOptions> mealOptionsList = new List<MealOptions>();

            string query = "SELECT * FROM MealOptions";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MealOptions mealOption = new MealOptions()
                            {
                                MealCode = reader.GetString(0),
                                Name = reader.GetString(1),
                                Conditions = reader.GetString(2)
                            };
                            mealOptionsList.Add(mealOption);
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
                Console.WriteLine($"Error retrieving MealOptions: {ex.Message}");
            }
            return mealOptionsList;
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