using System;

namespace OOP04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01 : Theoretical Questions

            #region Q1 
            /*
             * * 1. Static Binding Early Binding:
             * - It happens at Compile-time.
             * - The compiler knows exactly which method to call based on the reference type.
             * - Example: Method Overloading.
             * * 2. Dynamic Binding Late Binding :
             * - It happens at Run-time.
             * - The exact method to call is decided while the program is running based on the actual object type.
             * - Example: Method Overriding Virtual Methods.
             */
            #endregion

            #region Q2
            /*
             * 1. Method Overloading:
             * - Same method name but different parameters count or type
             * - Happens within the same class.
             * - It is a Compile-time polymorphism.
             * * 2. Method Overriding:
             * - Same method name and same parameters.
             * - Happens between a Parent class and a Child class.
             * - It is a Run-time polymorphism to change parent's behavior
             */
            #endregion

            #region Q3 
            /*
             * 1. virtual: Used in the Parent class to mark a method that can be overridden by child classes.
             * 2. override: Used in the Child class to provide a new different implementation for a virtual method.
             * 3. base: Used inside the child class to call the original version of the method from the parent class.
             */
            #endregion

            #endregion

            #region Part 02 : Practical (Extending the Movie Ticket Booking System)

            // a. Create a Cinema and open it
            Cinema myCinema = new Cinema("Galaxy Cinema");
            myCinema.OpenCinema();

            // b. Create tickets
            StandardTicket st = new StandardTicket("Inception", 100m, "A-5");
            VIPTicket vip = new VIPTicket("Avengers", 200m, true);
            IMAXTicket imax = new IMAXTicket("Dune", 180m, false);

            // c. Test both versions of SetPrice Method Overloading on one ticket
            Console.WriteLine("\n========== SetPrice Test ==========");
            Console.Write("Setting price directly: ");
            st.SetPrice(150m); // Version 1
            Console.WriteLine(st.Price);

            Console.Write("Setting price with multiplier: 100 x 1.5 = ");
            st.SetPrice(100m, 1.5m); // Version 2
            Console.WriteLine(st.Price);

            // d. Add all tickets to the Cinema and call PrintAllTickets
            myCinema.AddTicket(st);
            myCinema.AddTicket(vip);
            myCinema.AddTicket(imax);

            myCinema.PrintAllTickets();

            // e. Call ProcessTicket() with one of the tickets (Dynamic Binding)
            Console.WriteLine("\n========== Process Single Ticket ==========");
            ProcessTicket(vip);

            // f. Close the Cinema
            myCinema.CloseCinema();

            #endregion
        }

        // 4. Static method for Dynamic Binding
        public static void ProcessTicket(Ticket t)
        {
            if (t != null)
            {
                t.PrintTicket(); // Calls the overridden version based on Object type
            }
        }
    }

    #region Part 02 Classes

    public class Ticket
    {
        private static int _ticketCounter = 0;
        public string MovieName { get; set; }
        public int TicketId { get; private set; }
        public decimal Price { get; protected set; }
        public decimal PriceAfterTax => Price * 1.14m;

        public Ticket(string movieName, decimal price)
        {
            MovieName = movieName;
            Price = price;
            TicketId = ++_ticketCounter;
        }

        // 1.a. Virtual method for Polymorphism
        public virtual void PrintTicket()
        {
            Console.WriteLine($"Ticket #{TicketId} | {MovieName} | Price: {Price:F0} EGP | After Tax: {PriceAfterTax:F2} EGP");
        }

        // 1.b. Method Overloading (SetPrice)
        public void SetPrice(decimal price)
        {
            if (price > 0) Price = price;
        }

        public void SetPrice(decimal basePrice, decimal multiplier)
        {
            decimal calculated = basePrice * multiplier;
            if (calculated > 0) Price = calculated;
        }
    }

    // 2.a. Child Classes with PrintTicket Overrides
    public class StandardTicket : Ticket
    {
        public string SeatNumber { get; set; }
        public StandardTicket(string movieName, decimal price, string seat) : base(movieName, price) => SeatNumber = seat;

        public override void PrintTicket()
        {
            base.PrintTicket();
            Console.WriteLine($"  Seat: {SeatNumber}");
        }
    }

    public class VIPTicket : Ticket
    {
        public bool LoungeAccess { get; set; }
        public decimal ServiceFee { get; set; } = 50m;

        public VIPTicket(string movieName, decimal price, bool lounge) : base(movieName, price) => LoungeAccess = lounge;

        public override void PrintTicket()
        {
            base.PrintTicket();
            string access = LoungeAccess ? "Yes" : "No";
            Console.WriteLine($"  Lounge: {access} | Service Fee: {ServiceFee:F0} EGP");
        }
    }

    public class IMAXTicket : Ticket
    {
        public bool Is3D { get; set; }
        public IMAXTicket(string movieName, decimal price, bool is3D) : base(movieName, price) => Is3D = is3D;

        public override void PrintTicket()
        {
            base.PrintTicket();
            string threeD = Is3D ? "Yes" : "No";
            Console.WriteLine($"  IMAX 3D: {threeD}");
        }
    }

    // Cinema & Projector Composition
    public class Projector
    {
        public void Start() => Console.WriteLine("Projector started.");
        public void Stop() => Console.WriteLine("Projector stopped.");
    }

    public class Cinema
    {
        public string CinemaName { get; set; }
        private Projector _projector = new Projector();
        private Ticket[] _tickets = new Ticket[20];
        private int _count = 0;

        public Cinema(string name) => CinemaName = name;

        public void AddTicket(Ticket t)
        {
            if (_count < 20) _tickets[_count++] = t;
        }

        // 3. Update PrintAllTickets to use Polymorphism
        public void PrintAllTickets()
        {
            Console.WriteLine("\n========== All Tickets ==========");
            for (int i = 0; i < _count; i++)
            {
                _tickets[i].PrintTicket(); // Dynamic Binding
            }
        }

        public void OpenCinema()
        {
            Console.WriteLine("========== Cinema Opened ==========");
            _projector.Start();
        }

        public void CloseCinema()
        {
            Console.WriteLine("\n========== Cinema Closed ==========");
            _projector.Stop();
        }
    }

    #endregion
}