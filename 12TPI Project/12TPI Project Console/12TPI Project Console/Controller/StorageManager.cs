using _12TPI_Project_Console.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;

namespace _12TPI_Project_Console.Controller
{
    public static class DataReaderExtensions
    {
        public static string GetSafeString(this SqlDataReader reader, int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= reader.FieldCount)
            {
                throw new IndexOutOfRangeException($"Column index {columnIndex} is out of range.");
            }
            return reader.IsDBNull(columnIndex) ? "(unknown)" : reader.GetString(columnIndex);
        }
    }
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

        public Logins ValidateUserLogin(string usernName, string userPIN)
        {
            Logins login = null;
            string query = "SELECT Username, PINHash, AccessLevel FROM Logins WHERE Username = @Username AND PINHash = CONVERT(char(42),HASHBYTES('SHA1',CONVERT(varchar(50),@PIN)),1)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", usernName);
                    cmd.Parameters.AddWithValue("@PIN", userPIN);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            login = new Logins()
                            {
                                Username = reader.GetSafeString(0),
                                PINHash = reader.GetSafeString(1),
                                AccessLevel = reader.GetSafeString(2)
                            };
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
                Console.WriteLine($"Error validating user login: {ex.Message}");
            }
            return login;
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
                                Manufacturer = reader.GetSafeString(1),
                                Model = reader.GetSafeString(2),
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
                                FlightNumber = reader.GetSafeString(2),
                                PilotName = reader.GetSafeString(3),
                                DepartingDateTime = reader.GetDateTime(4),
                                DepartingAirport = reader.GetSafeString(5),
                                ArrivingDateTime = reader.GetDateTime(6),
                                ArrivingAirport = reader.GetSafeString(7),
                                Status = reader.GetSafeString(8)
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
                                IATACode = reader.GetSafeString(0),
                                Name = reader.GetSafeString(1),
                                Coordinates = reader.GetSafeString(2),
                                Country = reader.GetSafeString(3),
                                Timezone = reader.GetSafeString(4),
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
                                FirstName = reader.GetSafeString(1),
                                LastName = reader.GetSafeString(2),
                                MembershipStatus = reader.GetSafeString(3)
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
                                ClassCode = reader.GetSafeString(3),
                                MealChoice = reader.GetSafeString(4),
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
                                ClassCode = reader.GetSafeString(0),
                                Name = reader.GetSafeString(1),
                                ChangesPermitted = reader.GetSafeString(2),
                                BaggageAllowance = reader.GetInt32(3),
                                MilesAccrual = reader.GetSafeString(4)
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
                                MealCode = reader.GetSafeString(0),
                                Name = reader.GetSafeString(1),
                                Conditions = reader.GetSafeString(2)
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

        public List<Logins> GetAllLogins()
        {
            List<Logins> loginsList = new List<Logins>();

            string query = "SELECT * FROM Logins";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Logins login = new Logins()
                            {
                                Username = reader.GetSafeString(0),
                                PINHash = reader.GetSafeString(1),
                                AccessLevel = reader.GetSafeString(2)
                            };
                            loginsList.Add(login);
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
                Console.WriteLine($"Error retrieving Logins: {ex.Message}");
            }
            return loginsList;
        }
        public int UpdatePlane(Planes plane)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Planes SET Manufacturer = @Manufacturer, Model = @Model, PassengerCapacity = @PassengerCapacity, CargoCapacity = @CargoCapacity, MinimumTakeoff = @MinimumTakeoff, MinimumLanding = @MinimumLanding WHERE RegistrationID = @RegistrationID", conn))
            {
                cmd.Parameters.AddWithValue("@RegistrationID", plane.RegistrationID);
                cmd.Parameters.AddWithValue("@Manufacturer", plane.Manufacturer);
                cmd.Parameters.AddWithValue("@Model", plane.Model);
                cmd.Parameters.AddWithValue("@PassengerCapacity", plane.PassengerCapacity);
                cmd.Parameters.AddWithValue("@CargoCapacity", plane.CargoCapacity);
                cmd.Parameters.AddWithValue("@MinimumTakeoff", plane.MinimumTakeoff);
                cmd.Parameters.AddWithValue("@MinimumLanding", plane.MinimumLanding);
                return cmd.ExecuteNonQuery();
            }
        }
        public int UpdateFlight(Flights flight)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Flights SET PlaneRegistrationID = @PlaneRegistrationId, FlightNumber = @FlightNumber, PilotName = @PilotName, DepartingDateTime = @DepartingDateTime, DepartingAirport = @DepartingAirport, ArrivingDateTime = @ArrivingDateTime, ArrivingAirport = @ArrivingAirport, Status = @Status WHERE FlightID = @FlightID", conn))
            {
                cmd.Parameters.AddWithValue("@FlightID", flight.FlightID);
                cmd.Parameters.AddWithValue("@PlaneRegistrationId", flight.PlaneRegistrationID);
                cmd.Parameters.AddWithValue("@FlightNumber", flight.FlightNumber);
                cmd.Parameters.AddWithValue("@PilotName", flight.PilotName);
                cmd.Parameters.AddWithValue("@DepartingDateTime", flight.DepartingDateTime);
                cmd.Parameters.AddWithValue("@DepartingAirport", flight.DepartingAirport);
                cmd.Parameters.AddWithValue("@ArrivingDateTime", flight.ArrivingDateTime);
                cmd.Parameters.AddWithValue("@ArrivingAirport", flight.ArrivingAirport);
                cmd.Parameters.AddWithValue("@Status", flight.Status);
                return cmd.ExecuteNonQuery();
            }
        }
        public int UpdateAirport(Airports airport)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Airports SET Name = @Name, Coordinates = @Coordinates, Country = @Country, Timezone = @Timezone WHERE IATACode = @IATACode", conn))
            {
                cmd.Parameters.AddWithValue("@IATACode", airport.IATACode);
                cmd.Parameters.AddWithValue("@Name", airport.Name);
                cmd.Parameters.AddWithValue("@Coordinates", airport.Coordinates);
                cmd.Parameters.AddWithValue("@Country", airport.Country);
                cmd.Parameters.AddWithValue("@Timezone", airport.Timezone);
                return cmd.ExecuteNonQuery();
            }
        }
        public int UpdatePassenger(Passengers passenger)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Passengers SET FirstName = @FirstName, LastName = @LastName, MembershipStatus = @MembershipStatus WHERE CustomerID = @CustomerID", conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", passenger.CustomerID);
                cmd.Parameters.AddWithValue("@FirstName", passenger.FirstName);
                cmd.Parameters.AddWithValue("@LastName", passenger.LastName);
                cmd.Parameters.AddWithValue("@MembershipStatus", passenger.MembershipStatus);
                return cmd.ExecuteNonQuery();
            }
        }
        public int UpdateTicket(PassengerTickets ticket)
            {
                using (SqlCommand cmd = new SqlCommand($"UPDATE Tickets SET FlightID = @FlightID, CustomerID = @CustomerID, ClassCode = @ClassCode, MealChoice = @MealChoice WHERE TicketID = @TicketID", conn))
                {
                    cmd.Parameters.AddWithValue("@TicketID", ticket.TicketID);
                    cmd.Parameters.AddWithValue("@FlightID", ticket.FlightID);
                    cmd.Parameters.AddWithValue("@CustomerID", ticket.CustomerID);
                    cmd.Parameters.AddWithValue("@ClassCode", ticket.ClassCode);
                    cmd.Parameters.AddWithValue("@MealChoice", ticket.MealChoice);
                    return cmd.ExecuteNonQuery();
                }
            }
        
        public int UpdateClass(Classes Class)
            {
                using (SqlCommand cmd = new SqlCommand($"UPDATE Classes SET Name = @Name, ChangesPermitted = @ChangesPermitted, BaggageAllowance = @BaggageAllowance, MilesAccrual = @MilesAccrual WHERE ClassCode = @ClassCode", conn))
                {
                    cmd.Parameters.AddWithValue("@ClassCode", Class.ClassCode);
                    cmd.Parameters.AddWithValue("@Name", Class.Name);
                    cmd.Parameters.AddWithValue("@ChangesPermitted", Class.ChangesPermitted);
                    cmd.Parameters.AddWithValue("@BaggageAllowance", Class.BaggageAllowance);
                    cmd.Parameters.AddWithValue("@MilesAccrual", Class.MilesAccrual);
                    return cmd.ExecuteNonQuery();
                }
            }
        public int UpdateMealOption(MealOptions meal)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE MealOptions SET Name = @Name, Conditions = @Conditions WHERE MealCode = @MealCode", conn))
            {
                cmd.Parameters.AddWithValue("@MealCode", meal.MealCode);
                cmd.Parameters.AddWithValue("@Name", meal.Name);
                cmd.Parameters.AddWithValue("@Conditions", meal.Conditions);
                return cmd.ExecuteNonQuery();
            }
        }
        public int UpdateLogin(Logins login)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Logins SET PINHash = @PINHash, AccessLevel = @AccessLevel WHERE Username = @Username", conn))
            {
                cmd.Parameters.AddWithValue("@Username", login.Username);
                cmd.Parameters.AddWithValue("@PINHash", login.PINHash);
                cmd.Parameters.AddWithValue("@AccessLevel", login.AccessLevel);
                return cmd.ExecuteNonQuery();
            }
        }
        public int AddPlane(Planes plane)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Planes (Manufacturer, Model, PassengerCapacity, CargoCapacity, MinimumTakeoff, MinimumLanding) VALUES (@Manufacturer, @Model, @PassengerCapacity, @CargoCapacity, @MinimumTakeoff, @MinimumLanding); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@Manufacturer", plane.Manufacturer);
                cmd.Parameters.AddWithValue("@Model", plane.Model);
                cmd.Parameters.AddWithValue("@PassengerCapacity", plane.PassengerCapacity);
                cmd.Parameters.AddWithValue("@CargoCapacity", plane.CargoCapacity);
                cmd.Parameters.AddWithValue("@MinimumTakeoff", plane.MinimumTakeoff);
                cmd.Parameters.AddWithValue("@MinimumLanding", plane.MinimumLanding);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int AddFlight(Flights flight)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Flights (PlaneRegistrationID, FlightNumber, PilotName, DepartingDateTime, DepartingAirport, ArrivingDateTime, ArrivingAirport, Status) VALUES (@PlaneRegistrationID, @FlightNumber, @PilotName, @DepartingDateTime, @DepartingAirport, @ArrivingDateTime, @ArrivingAirport, @Status); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@PlaneRegistrationID", flight.PlaneRegistrationID);
                cmd.Parameters.AddWithValue("@FlightNumber", flight.FlightNumber);
                cmd.Parameters.AddWithValue("@PilotName", flight.PilotName);
                cmd.Parameters.AddWithValue("@DepartingDateTime", flight.DepartingDateTime);
                cmd.Parameters.AddWithValue("@DepartingAirport", flight.DepartingAirport);
                cmd.Parameters.AddWithValue("@ArrivingDateTime", flight.ArrivingDateTime);
                cmd.Parameters.AddWithValue("@ArrivingAirport", flight.ArrivingAirport);
                cmd.Parameters.AddWithValue("@Status", flight.Status);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int AddAirport(Airports airport)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Airports (IATACode, Name, Coordinates, Country, Timezone) VALUES (@IATACode, @Name, @Coordinates, @Country, @Timezone);", conn))
            {
                cmd.Parameters.AddWithValue("@IATACode", airport.IATACode);
                cmd.Parameters.AddWithValue("@Name", airport.Name);
                cmd.Parameters.AddWithValue("@Coordinates", airport.Coordinates);
                cmd.Parameters.AddWithValue("@Country", airport.Country);
                cmd.Parameters.AddWithValue("@Timezone", airport.Timezone);
                return cmd.ExecuteNonQuery();
            }
        }
        public int AddPassenger(Passengers passenger)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Passengers (FirstName, LastName, MembershipStatus) VALUES (@FirstName, @LastName, @MembershipStatus);", conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", passenger.FirstName);
                cmd.Parameters.AddWithValue("@LastName", passenger.LastName);
                cmd.Parameters.AddWithValue("@MembershipStatus", passenger.MembershipStatus );
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int AddTicket(PassengerTickets tickets)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO PassengerTickets (FlightID, CustomerID, ClassCode, MealChoice) VALUES (@FlightID, @CustomerID, @ClassCode, @MealChoice);", conn))
            {
                cmd.Parameters.AddWithValue("@FlightID", tickets.FlightID);
                cmd.Parameters.AddWithValue("@CustomerID", tickets.CustomerID);
                cmd.Parameters.AddWithValue("@ClassCode", tickets.ClassCode);
                cmd.Parameters.AddWithValue("@MealChoice", tickets.MealChoice);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int AddClasses(Classes Class)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Classes (ClassCode, Name, ChangesPermitted, BaggageAllowance, MilesAccrual) VALUES (@ClassCode, @Name, @ChangesPermitted, @BaggageAllowance, @MilesAccrual);", conn))
            {
                cmd.Parameters.AddWithValue("@ClassCode", Class.ClassCode);
                cmd.Parameters.AddWithValue("@Name", Class.Name);
                cmd.Parameters.AddWithValue("@ChangesPermitted", Class.ChangesPermitted);
                cmd.Parameters.AddWithValue("@BaggageAllowance", Class.BaggageAllowance);
                cmd.Parameters.AddWithValue("@MilesAccrual", Class.MilesAccrual);
                return cmd.ExecuteNonQuery();
            }
        }
        public int AddMealOption(MealOptions meal)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO MealOptions (MealCode, Name, Conditions) VALUES (@MealCode, @Name, @Conditions);", conn))
            {
                cmd.Parameters.AddWithValue("@MealCode", meal.MealCode);
                cmd.Parameters.AddWithValue("@Name", meal.Name);
                cmd.Parameters.AddWithValue("@Conditions", meal.Conditions);
                return cmd.ExecuteNonQuery();
            }
        }
        public int AddLogin(Logins login)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Logins (Username, PINHash, AccessLevel) VALUES (@Username, @PINHash, @AccessLevel);", conn))
            {
                cmd.Parameters.AddWithValue("@Username", login.Username);
                cmd.Parameters.AddWithValue("@PINHash", login.PINHash);
                cmd.Parameters.AddWithValue("@AccessLevel", login.AccessLevel);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeletePlaneByID(int r /* = RegistartionID */)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Planes WHERE RegistrationID = @RegistrationID", conn))
            {
                cmd.Parameters.AddWithValue("@RegistrationID", r);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteFlightByID(int fi /* = FlightID */)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Flights WHERE FlightID = @FlightID", conn))
            {
                cmd.Parameters.AddWithValue("@FlightID", fi);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteAirportByIATACode(string i /* = IATACode */)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Airports WHERE IATACode = @IATACode", conn))
            {
                cmd.Parameters.AddWithValue("@IATACode", i);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeletePassengerByID(int c /* = CustomerID */)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Passengers WHERE CustomerID = @CustomerID", conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", c);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteTicketByID(int t /* = TicketID */)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM PassengerTickets WHERE TicketID = @TicketID", conn))
            {
                cmd.Parameters.AddWithValue("@TicketID", t);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteClassByCode(string c /* = ClassCode */)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Classes WHERE ClassCode = @ClassCode", conn))
            {
                cmd.Parameters.AddWithValue("@ClassCode", c);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteMealOptionByCode(string m /* = MealCode */)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM MealOptions WHERE MealCode = @MealCode", conn))
            {
                cmd.Parameters.AddWithValue("@MealCode", m);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteLoginByUsername(string u /* = Username */)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Logins WHERE Username = @Username", conn))
            {
                cmd.Parameters.AddWithValue("@Username", u);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}