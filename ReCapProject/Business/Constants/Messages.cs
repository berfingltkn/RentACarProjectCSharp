using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //Car Message
        public static string CarAdded = "Car Added";
        public static string CarDeleted = "Car Deleted";
        public static string CarUpdate = "Car Update";
        public static string CarNoAdded = "Car could not be added";
        public static string MaintenacneTime = "Maintenacne";
        public static string CarsListed = "Cars Listed";
        public static string CarNameInvalid = "Car name is invalid.";
        public static string CarDetailsListed = "Car details listed.";

        //Brand Message
        public static string BrandAdded = "Brand Added";
        public static string BrandDeleted = "Brand Deleted";
        public static string BrandUpdate = "Brand Update";
        public static string BrandNoAdded = "Brand could not be added";
        public static string BrandMaintenacneTime = "MaintenacneTime";
        public static string BrandListed = "Brand Listed.";
        public static string BrandNameInvalid = "Brand name is invalid.";
        public static string BrandDetailsListed = "Brand details listed";

        //Color Message
        public static string ColorAdded = "Color Added";
        public static string ColorDeleted = "Color Deleted";
        public static string ColorUpdated = "Color Update";
        public static string ColorsListed = "Colors Listed";
        

        //Rental Message-> Kiralama
        public static string RentalAdded = "Rental Added";
        public static string RentalDeleted = "Rental Deleted";
        public static string RentalUpdated = "Rental Update";
        public static string RentalsListed = "Rentals Listed";
        public static string RentalCarError = "Vehicle cannot be rented.";

        //Customer Messages
        public static string CustomerAdded = "Customer Added";
        public static string CustomerDeleted = "Customer Deleted";
        public static string CustomerUpdated = "Customer Update";
        public static string CustomersListed = "Customer Listed";


        //User Messages
        public static string UserAdded = "User Added";
        public static string UserDeleted = "User Deleted";
        public static string UserUpdated = "User Update";
        public static string UsersListed = "Users Listed";


        public static string AuthorizationDenied = "Authorization denied.";

        public static string UserRegistered = "User Registered.";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password Error";
        public static string UserAlreadyExists = "User Already Exists";
        public static string SuccessfulLogin = "Successfull Login";
        public static string AccessTokenCreated = "Access Token Created";
    }
}
