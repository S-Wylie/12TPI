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
        public int UpdatePlane(int r /* = RegistartionID */, string ma /* = Manufacturer */, string mo /* = Model */, int p /* = PassengerCapcity */, int c /* = CargoCapacity */, decimal t /* = MinimumTakeoff */, decimal l /* = MinimumLanding*/)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Planes SET MANUFACTURER = @Manufacturer, MODEL = @Model, PASSENGER_CAPACITY = @PassengerCapacity, CARGO_CAPACITY = @CargoCapacity, MINIMUM_TAKEOFF = @MinimumTakeoff, MINIMUM_LANDING = @MinimumLanding WHERE REGISTRATION_ID = @RegistrationId", conn))
            {
                cmd.Parameters.AddWithValue("@RegistrationId", r);
                cmd.Parameters.AddWithValue("@Manufacturer", ma);
                cmd.Parameters.AddWithValue("@Model", mo);
                cmd.Parameters.AddWithValue("@PassengerCapacity", p);
                cmd.Parameters.AddWithValue("@CargoCapacity", c);
                cmd.Parameters.AddWithValue("@MinimumTakeoff", t);
                cmd.Parameters.AddWithValue("@MinimumLanding", l);
                return cmd.ExecuteNonQuery();
            }
        }
        public int UpdateFlight(int fi /* = FlightID */, int pr /* = PlaneRegistrationID */, int fn /* = FlightNumber*/, string p /* = PilotName */, DateTime dt /* = DepartingDateTime */, string da /* = DepartingAirport */, DateTime at /* = ArrivingDateTime */, string aa /* = ArrivingAirport */, string s /* = Status */)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Flights SET PLANE_REGISTRATION_ID = @PlaneRegistrationId, FLIGHT_NUMBER = @FlightNumber, PILOT_NAME = @PilotName, DEPARTING_DATETIME = @DepartingDateTime, DEPARTING_AIRPORT = @DepartingAirport, ARRIVING_DATETIME = @ArrivingDateTime, ARRIVING_AIRPORT = @ArrivingAirport, STATUS = @Status WHERE FLIGHT_ID = @FlightId", conn))
            {
                cmd.Parameters.AddWithValue("@FlightId", fi);
                cmd.Parameters.AddWithValue("@PlaneRegistrationId", pr);
                cmd.Parameters.AddWithValue("@FlightNumber", fn);
                cmd.Parameters.AddWithValue("@PilotName", p);
                cmd.Parameters.AddWithValue("@DepartingDateTime", dt);
                cmd.Parameters.AddWithValue("@DepartingAirport", da);
                cmd.Parameters.AddWithValue("@ArrivingDateTime", at);
                cmd.Parameters.AddWithValue("@ArrivingAirport", aa);
                cmd.Parameters.AddWithValue("@Status", s);
                return cmd.ExecuteNonQuery();
            }
        }
        public int UpdateAirport(int i /* = IATACode */, string n /* = Name */, string cor /* = Coordinates */, string con /* = Country */ , string t /* Timezone */)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Airports SET NAME = @Name, COORDINATES = @Coordinates, COUNTRY = @Country, TIMEZONE = @Timezone WHERE IATA_CODE = @IATACode", conn))
            {
                cmd.Parameters.AddWithValue("@IATACode", i);
                cmd.Parameters.AddWithValue("@Name", n);
                cmd.Parameters.AddWithValue("@Coordinates", cor);
                cmd.Parameters.AddWithValue("@Country", con);
                cmd.Parameters.AddWithValue("@Timezone", t);
                return cmd.ExecuteNonQuery();
            }
        }
        public int UpdatePassenger(int c /* = CustomerID */, string f /* = FirstName */ , string l /* = LastName */ , string m /* = MembershipStatus */)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Passengers SET FIRST_NAME = @FirstName, LAST_NAME = @LastName, MEMBERSHIP_STATUS = @MembershipStatus WHERE CUSTOMER_ID = @CustomerID", conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", c);
                cmd.Parameters.AddWithValue("@FirstName", f);
                cmd.Parameters.AddWithValue("@LastName", l);
                cmd.Parameters.AddWithValue("@MembershipStatus", m);
                return cmd.ExecuteNonQuery();
            }
        }
        public int UpdateTicket(int t /* = TicketID */, int f /* = Flight ID */, int ci /* = Customer ID */, string cn /* = ClassName */, string m /* = MealChoice */)
            {
                using (SqlCommand cmd = new SqlCommand($"UPDATE Tickets SET FLIGHT_ID = @FlightId, CUSTOMER_ID = @CustomerId, CLASS_NAME = @ClassName, MEAL_CHOICE = @MealChoice WHERE TICKET_ID = @TicketId", conn))
                {
                    cmd.Parameters.AddWithValue("@TicketId", t);
                    cmd.Parameters.AddWithValue("@FlightId", f);
                    cmd.Parameters.AddWithValue("@CustomerId", ci);
                    cmd.Parameters.AddWithValue("@ClassName", cn);
                    cmd.Parameters.AddWithValue("@MealChoice", m);
                    return cmd.ExecuteNonQuery();
                }
            }
        
        public int UpdateClass(int t /* = TicketID */, int f /* = Flight ID */, int ci /* = Customer ID */, string cn /* = ClassName */, string m /* = MealChoice */)
            {
                using (SqlCommand cmd = new SqlCommand($"UPDATE Tickets SET FLIGHT_ID = @FlightId, CUSTOMER_ID = @CustomerId, CLASS_NAME = @ClassName, MEAL_CHOICE = @MealChoice WHERE TICKET_ID = @TicketId", conn))
                {
                    cmd.Parameters.AddWithValue("@TicketId", t);
                    cmd.Parameters.AddWithValue("@FlightId", f);
                    cmd.Parameters.AddWithValue("@CustomerId", ci);
                    cmd.Parameters.AddWithValue("@ClassName", cn);
                    cmd.Parameters.AddWithValue("@MealChoice", m);
                    return cmd.ExecuteNonQuery();
                }
            }
        public int UpdateMealOption(string m /* = MealCode */, string n /* = Name */, string c /* = Conditions*/)
        {
            using (SqlCommand cmd = new SqlCommand($"MEAL_NAME = @MealName, CONDITIONS = @Conditions WHERE MEAL_CODE = @MealCode", conn))
            {
                cmd.Parameters.AddWithValue("@MealCode", m);
                cmd.Parameters.AddWithValue("@MealName", n);
                cmd.Parameters.AddWithValue("@Conditions", c);
                return cmd.ExecuteNonQuery();
            }
        }
        public int InsertPlane(string ma /* = Manufacturer */, string mo /* = Model */, int p /* = PassengerCapcity */, int c /* = CargoCapacity */, decimal t /* = MinimumTakeoff */, decimal l /* = MinimumLanding*/)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Planes (MANUFACTURER, MODEL, PASSENGER_CAPACITY, CARGO_CAPACITY, MINIMUM_TAKEOFF, MINIMUM_LANDING) VALUES (@Manufacturer, @Model, @PassengerCapacity, @CargoCapacity, @MinimumTakeoff, @MinimumLanding); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@Manufacturer", ma);
                cmd.Parameters.AddWithValue("@Model", mo);
                cmd.Parameters.AddWithValue("@PassengerCapacity", p);
                cmd.Parameters.AddWithValue("@CargoCapacity", c);
                cmd.Parameters.AddWithValue("@MinimumTakeoff", t);
                cmd.Parameters.AddWithValue("@MinimumLanding", l);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int InsertFlight(int pr /* = PlaneRegistrationID */, int fn /* = FlightNumber*/, string p /* = PilotName */, DateTime dt /* = DepartingDateTime */, string da /* = DepartingAirport */, DateTime at /* = ArrivingDateTime */, string aa /* = ArrivingAirport */, string s /* = Status */)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Flights (PLANE_REGISTRATION_ID, FLIGHT_NUMBER, PILOT_NAME, DEPARTING_DATE_TIME, DEPARTING_AIRPORT, ARRIVING_DATE_TIME, ARRIVING_AIRPORT, STATUS) VALUES (@PlaneRegistrationId, @FlightNumber, @PilotName, @DepartingDateTime, @DepartingAirport, @ArrivingDateTime, @ArrivingAirport, @Status); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@PlaneRegistrationId", pr);
                cmd.Parameters.AddWithValue("@FlightNumber", fn);
                cmd.Parameters.AddWithValue("@PilotName", p);
                cmd.Parameters.AddWithValue("@DepartingDateTime", dt);
                cmd.Parameters.AddWithValue("@DepartingAirport", da);
                cmd.Parameters.AddWithValue("@ArrivingDateTime", at);
                cmd.Parameters.AddWithValue("@ArrivingAirport", aa);
                cmd.Parameters.AddWithValue("@Status", s);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int InsertAirport(int i /* = IATACode */, string n /* = Name */, string cor /* = Coordinates */, string con /* = Country */ , string t /* Timezone */)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Airports (IATA_CODE, NAME, COORDINATES, COUNTRY, TIMEZONE) VALUES (@IATACode, @Name, @Coordinates, @Country, @Timezone);", conn))
            {
                cmd.Parameters.AddWithValue("@IATACode", i);
                cmd.Parameters.AddWithValue("@Name", n);
                cmd.Parameters.AddWithValue("@Coordinates", cor);
                cmd.Parameters.AddWithValue("@Country", con);
                cmd.Parameters.AddWithValue("@Timezone", t);
                return cmd.ExecuteNonQuery();
            }
        }
        public int InsertPassenger(string f /* = FirstName */ , string l /* = LastName */ , string m /* = MembershipStatus */)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Passengers (FIRST_NAME, LAST_NAME, MEMBERSHIP_STATUS) VALUES (@FirstName, @LastName, @MembershipStatus);", conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", f);
                cmd.Parameters.AddWithValue("@LastName", l);
                cmd.Parameters.AddWithValue("@MembershipStatus", m);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int InsertTicket(int f /* = Flight ID */, int ci /* = Customer ID */, string cn /* = ClassName */, string m /* = MealChoice */)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Tickets (FLIGHT_ID, CUSTOMER_ID, CLASS_NAME, MEAL_CHOICE) VALUES (@FlightId, @CustomerId, @ClassName, @MealChoice);", conn))
            {
                cmd.Parameters.AddWithValue("@FlightId", f);
                cmd.Parameters.AddWithValue("@CustomerId", ci);
                cmd.Parameters.AddWithValue("@ClassName", cn);
                cmd.Parameters.AddWithValue("@MealChoice", m);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int InsertClasses(string c /* = ClassCode */, string n /* = Name */, string p /* = ChangesPermitted */, int b /* = BaggageAllowance */ , string m /* = MilesAccural */)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Classes (CLASS_CODE, NAME, CHANGES_PERMITTED, BAGGAGE_ALLOWANCE, MILES_ACCRUAL) VALUES (@ClassCode, @Name, @ChangesPermitted, @BaggageAllowance, @MilesAccrual);", conn))
            {
                cmd.Parameters.AddWithValue("@ClassCode", c);
                cmd.Parameters.AddWithValue("@Name", n);
                cmd.Parameters.AddWithValue("@ChangesPermitted", p);
                cmd.Parameters.AddWithValue("@BaggageAllowance", b);
                cmd.Parameters.AddWithValue("@MilesAccrual", m);
                return cmd.ExecuteNonQuery();
            }
        }
        public int InsertMealOptions(string m /* = MealCode */, string n /* = Name */, string c /* = Conditions*/)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO MealOptions (MEAL_CODE, NAME, CONDITIONS) VALUES (@MealCode, @Name, @Conditions);", conn))
            {
                cmd.Parameters.AddWithValue("@MealCode", m);
                cmd.Parameters.AddWithValue("@Name", n);
                cmd.Parameters.AddWithValue("@Conditions", c);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeletePlaneByID(int r /* = RegistartionID */)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Planes WHERE REGISTRATION_ID = @RegistrationID", conn))
            {
                cmd.Parameters.AddWithValue("@RegistrationID", r);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteFlightByID(int fi /* = FlightID */)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Flights WHERE FLIGHT_ID = @FlightID", conn))
            {
                cmd.Parameters.AddWithValue("@FlightID", fi);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteAirportByIATACode(string i /* = IATACode */)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Airports WHERE IATA_CODE = @IATACode", conn))
            {
                cmd.Parameters.AddWithValue("@IATACode", i);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeletePassengerByID(int c /* = CustomerID */)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Passengers WHERE CUSTOMER_ID = @CustomerID", conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", c);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteTicketByID(int t /* = TicketID */)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM PassengerTickets WHERE TICKET_ID = @TicketID", conn))
            {
                cmd.Parameters.AddWithValue("@TicketID", t);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteClassesByCode(string c /* = ClassCode */)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Classes WHERE CLASS_CODE = @ClassCode", conn))
            {
                cmd.Parameters.AddWithValue("@ClassCode", c);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteMealOptionsByCode(string m /* = MealCode */)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM MealOptions WHERE MEAL_CODE = @MealCode", conn))
            {
                cmd.Parameters.AddWithValue("@MealCode", m);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}