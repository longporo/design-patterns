using System;

namespace behavior_mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            FreeNowController freeNowController = new FreeNowController();
            Customer customer = new Customer(freeNowController);
            Driver driver = new Driver(freeNowController);
            freeNowController.Customer = customer;
            freeNowController.Driver = driver;
            customer.CallingDriver(new object());
            driver.AcceptCalling(customer);
        }
    }

    /// <summary>
    /// The 'Mediator' abstract class
    /// </summary>
    public abstract class Mediator
    {
        public abstract void CallingDrivers(Object routeDetail, Customer customer);
        public abstract void AcceptCalling(Driver driver, Customer customer);
    }

    /// <summary>
    /// The FreeNowController concrete class
    /// </summary>
    public class FreeNowController : Mediator
    {
        Customer customer;
        Driver driver;

        public Customer Customer
        {
            set { customer = value; }
        }

        public Driver Driver
        {
            set { driver = value; }
        }

        /// <summary>
        /// Customer call drivers with route detail
        /// </summary>
        /// <param name="routeDetail"></param>
        /// <param name="customer"></param>
        public override void CallingDrivers(object routeDetail, Customer customer)
        {
            Console.WriteLine("Customer is calling drivers");
            // notify driver
            driver.Notify(routeDetail, customer);
        }

        /// <summary>
        /// Driver accepts customer's call and notify customer
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="customer"></param>
        public override void AcceptCalling(Driver driver, Customer customer)
        {
            // driver accept the call, notify customer
            customer.Notify("Customer gets message: Driver has accepted your call!");
        }
    }

    /// <summary>
    /// The 'User' abstract class
    /// </summary>
    public abstract class User
    {
        protected Mediator mediator;

        // Constructor
        public User(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    /// <summary>
    /// The Customer class can call drivers
    /// </summary>
    public class Customer : User
    {
        // Constructor
        public Customer(Mediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Call driver with route detail
        /// </summary>
        /// <param name="routeDetail"></param>
        public void CallingDriver(Object routeDetail)
        {
            mediator.CallingDrivers(routeDetail, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine(message);
        }
    }

    /// <summary>
    /// The Driver class can accept customer's call
    /// </summary>
    public class Driver : User
    {
        // Constructor
        public Driver(Mediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Accept customer's call
        /// </summary>
        /// <param name="customer"></param>
        public void AcceptCalling(Customer customer)
        {
            Console.WriteLine("Driver decides to accept the call");
            mediator.AcceptCalling(this, customer);
        }

        public void Notify(Object routeDetail, Customer customer)
        {
            Console.WriteLine("Driver gets message of the route detail and caller");
        }
    }
}