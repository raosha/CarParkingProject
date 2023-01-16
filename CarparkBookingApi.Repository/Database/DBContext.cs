using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarparkBookingApi.Repository.Interface.DatabaseEnitities;
using CarparkBookingApi.Repository.Interface.DatabaseEntities;
using CarparkBookingApi.Repository.Interface.Interface;

namespace CarparkBookingApi.Repository.Database
{
    /// <summary>
    /// Please note this is a mocked database created for the purpose of this demo. In real app, data will be persisted and retreived from real database using ORM Tool or
    /// ADO.Net api's.
    /// </summary>
    public class DBContext : IDBContext
    {
        private List<Booking> bookings = new List<Booking>();
        private List<BookingItem> bookingItems = new List<BookingItem>();
        private List<Customer> customers = new List<Customer>();
        private List<CustomerAddress> customerAddresses = new List<CustomerAddress>();
        private List<ParkingSlot> parkingSlots= new List<ParkingSlot>();
        private DateTime Now = DateTime.Now;

        public DBContext() 
        {
            SeedMockedDatabaseData();
        }

        

        public List<Booking> BookingsDBSet => bookings;

        public List<BookingItem> BookingItemDBSet => bookingItems;

        public List<Customer> CustomerDBSet => customers;

        public List<CustomerAddress> CustomerAddressDBSet => customerAddresses;

        public List<ParkingSlot> ParkingSlotDBSet => parkingSlots;


        private void SeedMockedDatabaseData()
        {
            SeedParkingSlot();
            SeedCustomers();
            SeedCustomerAddresses();
            SeedBookings();
            SeedBookingItems();
        }

        private void SeedParkingSlot()
        {
            this.ParkingSlotDBSet.Add(new ParkingSlot { ID = 1, Name = "Slot 1" });
            this.ParkingSlotDBSet.Add(new ParkingSlot { ID = 2, Name = "Slot 2" });
            this.ParkingSlotDBSet.Add(new ParkingSlot { ID = 3, Name = "Slot 3" });
            this.ParkingSlotDBSet.Add(new ParkingSlot { ID = 4, Name = "Slot 4" });
            this.ParkingSlotDBSet.Add(new ParkingSlot { ID = 5, Name = "Slot 5" });
            this.ParkingSlotDBSet.Add(new ParkingSlot { ID = 6, Name = "Slot 6" });
            this.ParkingSlotDBSet.Add(new ParkingSlot { ID = 7, Name = "Slot 7" });
            this.ParkingSlotDBSet.Add(new ParkingSlot { ID = 8, Name = "Slot 8" });
            this.ParkingSlotDBSet.Add(new ParkingSlot { ID = 9, Name = "Slot 9" });
            this.ParkingSlotDBSet.Add(new ParkingSlot { ID = 10, Name = "Slot 10" });
        }

        private void SeedCustomers()
        {
            this.CustomerDBSet.Add(new Customer { CustomerID =1, FirstName = "Philip", LastName = "Jones"});
            this.CustomerDBSet.Add(new Customer { CustomerID = 2, FirstName = "Robert", LastName = "Massie" });
            this.CustomerDBSet.Add(new Customer { CustomerID = 3, FirstName = "Harry", LastName = "Joseph" });
            this.CustomerDBSet.Add(new Customer { CustomerID = 4, FirstName = "Jones", LastName = "Rob" });
            this.CustomerDBSet.Add(new Customer { CustomerID = 5, FirstName = "Philip", LastName = "Jones" });
        }

        private void SeedCustomerAddresses()
        {
            this.CustomerAddressDBSet.Add(new CustomerAddress { ID = 1 , CustomerId =1, AddressLine = "123 High street", City = "Stafford", PostCode = "CV12 3DF"});
            this.CustomerAddressDBSet.Add(new CustomerAddress { ID = 2, CustomerId = 2, AddressLine = "13 Norman street", City = "Birmingham", PostCode = "BB5 3DF" });
            this.CustomerAddressDBSet.Add(new CustomerAddress { ID = 3, CustomerId = 3, AddressLine = "4 Chelsea Avenue", City = "Stoke", PostCode = "ST6 3DF" });
            this.CustomerAddressDBSet.Add(new CustomerAddress { ID = 4, CustomerId = 4, AddressLine = "14 Bowden street", City = "London", PostCode = "LD13 3DF" });
            this.CustomerAddressDBSet.Add(new CustomerAddress { ID = 5, CustomerId = 5, AddressLine = "9 Wilkinson Avenue", City = "Reading", PostCode = "CV12 3DF" });
        }

        private void SeedBookings()
        {
            this.BookingsDBSet.Add(new Booking {BookingId = 1, CustomerId = 1, DateFrom = Now, DateTo = Now.AddDays(5) });
            this.BookingsDBSet.Add(new Booking { BookingId = 2, CustomerId = 2, DateFrom = Now, DateTo = Now.AddDays(10) });
            this.BookingsDBSet.Add(new Booking { BookingId = 3, CustomerId = 3, DateFrom = Now.AddDays(1), DateTo = Now.AddDays(4) });
            this.BookingsDBSet.Add(new Booking { BookingId = 4, CustomerId = 4, DateFrom = Now.AddDays(2), DateTo = Now.AddDays(3) });
            this.BookingsDBSet.Add(new Booking { BookingId = 5, CustomerId = 5, DateFrom = Now.AddDays(1), DateTo = Now.AddDays(11) });
        }

        private void SeedBookingItems()
        {
            //First booking item
            this.BookingItemDBSet.Add(new BookingItem { ID = 1, BookingId = 1, BookingDate = Now, IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 2, BookingId = 1, BookingDate = Now.AddDays(1), IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 3, BookingId = 1, BookingDate = Now.AddDays(2) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 4, BookingId = 1, BookingDate = Now.AddDays(3) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 5, BookingId = 1, BookingDate = Now.AddDays(4) , IsActive = true });


            //Second booking item
            this.BookingItemDBSet.Add(new BookingItem { ID = 6, BookingId = 2, BookingDate = Now, IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 7, BookingId = 2, BookingDate = Now.AddDays(1) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 8, BookingId = 2, BookingDate = Now.AddDays(2) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 9, BookingId = 2, BookingDate = Now.AddDays(3) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 10, BookingId = 2, BookingDate = Now.AddDays(4) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 11, BookingId = 2, BookingDate = Now.AddDays(5) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 12, BookingId = 2, BookingDate = Now.AddDays(6) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 13, BookingId = 2, BookingDate = Now.AddDays(7) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 14, BookingId = 2, BookingDate = Now.AddDays(8) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 15, BookingId = 2, BookingDate = Now.AddDays(9) , IsActive = true });

            //Third booking item
            this.BookingItemDBSet.Add(new BookingItem { ID = 16, BookingId = 3, BookingDate = Now.AddDays(1) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 17, BookingId = 3, BookingDate = Now.AddDays(2) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 18, BookingId = 3, BookingDate = Now.AddDays(3) , IsActive = true });

            //Fourth booking item
            this.BookingItemDBSet.Add(new BookingItem { ID = 19, BookingId = 4, BookingDate = Now.AddDays(2) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 20, BookingId = 4, BookingDate = Now.AddDays(3) , IsActive = true });

            //Fifth booking item
            this.BookingItemDBSet.Add(new BookingItem { ID = 21, BookingId = 5, BookingDate = Now.AddDays(1) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 22, BookingId = 5, BookingDate = Now.AddDays(2) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 23, BookingId = 5, BookingDate = Now.AddDays(3) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 24, BookingId = 5, BookingDate = Now.AddDays(4) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 25, BookingId = 5, BookingDate = Now.AddDays(5) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 26, BookingId = 5, BookingDate = Now.AddDays(6) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 27, BookingId = 5, BookingDate = Now.AddDays(7) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 28, BookingId = 5, BookingDate = Now.AddDays(8) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 29, BookingId = 5, BookingDate = Now.AddDays(9) , IsActive = true });
            this.BookingItemDBSet.Add(new BookingItem { ID = 30, BookingId = 5, BookingDate = Now.AddDays(10) , IsActive = true });
        }
    }
}
