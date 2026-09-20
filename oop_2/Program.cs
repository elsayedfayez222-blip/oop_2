using System;

namespace SmartDeliveryManagementSystem
{
    #region Theoretical Questions Code & Answers

    #region Question 1
    // Question 1:
    // a) What is the difference between a class and a struct?
    // answer:
    // - class is a Reference Type stored on the Heap, supports Inheritance, and its default value is null.
    // - struct is a Value Type stored on the Stack, does NOT support Inheritance, and has a non-null default value.

    // b) why are classes more suitable than structs for large applications?
    // answer:
    // classes support OOP concepts like Inheritance and Polymorphism, allowing easy extension and code reuse.
    // they are passed by reference, avoiding heavy object copying in memory for large structures.
    #endregion

    #region Question 2
    // consider the code:
    // public class Shipment { public string TrackingCode { get; set; } }
    // public class ExpressShipment : Shipment { public decimal ExtraFee { get; set; } }

    // a) which class is the parent class?
    // answer: shipment

    // b) which class is the child class?
    // answer: ExpressShipment

    // c) What members are inherited by ExpressShipment?
    // Answer: The property  TrackingCode  (along with standard methods inherited from System.Object)

    // d) Why is inheritance better than duplicating the same code in multiple classes?
    // Answer:
    // It promotes Code Reusability, simplifies Maintenance (changing code in parent updates all children),
    // and enables Polymorphism (treating derived objects as base instances).
    #endregion

    #endregion

    #region Practical Code Implementation

    // 1. deliveryAddress Struct (Kept as Value Object)
    public struct DeliveryAddress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }

        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }

        public string GetFullAddress()
        {
            return $"{BuildingNumber} {Street}, {City}";
        }
    }

    // 2. Shipment Base Class (Converted from Struct to Class)
    public class Shipment
    {
        private string trackingCode;
        private string description;
        private double weight;
        private decimal deliveryFee;

        public string TrackingCode
        {
            get { return trackingCode; }
            protected set { trackingCode = value; }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    description = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                    weight = value;
            }
        }

        public decimal DeliveryFee
        {
            get { return deliveryFee; }
            protected set
            {
                if (value >= 0)
                    deliveryFee = value;
            }
        }

        public DeliveryAddress Destination { get; set; }

        public virtual decimal EstimatedCost
        {
            get { return DeliveryFee + (decimal)(Weight * 5); }
        }

        // Constructors with Chaining
        public Shipment(string trackingCode)
            : this(trackingCode, "Unknown", 1, 50, new DeliveryAddress("Cairo", "Default Street", 1))
        {
        }

        public Shipment(string trackingCode, string description, double weight, decimal deliveryFee, DeliveryAddress destination)
        {
            TrackingCode = !string.IsNullOrWhiteSpace(trackingCode) ? trackingCode : "UNKNOWN";
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }

        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee >= 0)
                DeliveryFee = newFee;
        }

        public virtual void PrintShipment()
        {
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Weight        : {Weight} KG");
            Console.WriteLine($"Delivery Fee  : {DeliveryFee} EGP");
            Console.WriteLine($"Destination   : {Destination.GetFullAddress()}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }
    }

    // 3. Derived Shipment Types

    // StandardShipment Class
    public class StandardShipment : Shipment
    {
        public StandardShipment(string trackingCode, string description, double weight, decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }
    }

    // ExpressShipment Class
    public class ExpressShipment : Shipment
    {
        private decimal extraFee;

        public decimal ExtraFee
        {
            get { return extraFee; }
            set
            {
                if (value >= 0)
                    extraFee = value;
            }
        }

        public override decimal EstimatedCost
        {
            get { return base.EstimatedCost + ExtraFee; }
        }

        public ExpressShipment(string trackingCode, string description, double weight, decimal deliveryFee, DeliveryAddress destination, decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }

        public override void PrintShipment()
        {
            base.PrintShipment();
            Console.WriteLine($"Extra Fee     : {ExtraFee} EGP");
        }
    }

    // InternationalShipment Class
    public class InternationalShipment : Shipment
    {
        private string destinationCountry;
        private decimal customsFee;

        public string DestinationCountry
        {
            get { return destinationCountry; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    destinationCountry = value;
            }
        }

        public decimal CustomsFee
        {
            get { return customsFee; }
            set
            {
                if (value >= 0)
                    customsFee = value;
            }
        }

        public override decimal EstimatedCost
        {
            get { return base.EstimatedCost + CustomsFee; }
        }

        public InternationalShipment(string trackingCode, string description, double weight, decimal deliveryFee, DeliveryAddress destination, string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        public override void PrintShipment()
        {
            base.PrintShipment();
            Console.WriteLine($"Country       : {DestinationCountry}");
            Console.WriteLine($"Customs Fee   : {CustomsFee} EGP");
        }
    }

    // 4. DeliveryCenter Class (Converted from Struct to Class)
    public class DeliveryCenter
    {
        public string CenterName { get; set; }
        private Shipment[] shipments;
        private int count;

        public DeliveryCenter(string centerName)
        {
            CenterName = centerName;
            shipments = new Shipment[20];
            count = 0;
        }

        // Indexer by position
        public Shipment this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    return null;
                return shipments[index];
            }
        }

        // Indexer by tracking code
        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < count; i++)
                {
                    if (shipments[i] != null && shipments[i].TrackingCode.Equals(trackingCode, StringComparison.OrdinalIgnoreCase))
                    {
                        return shipments[i];
                    }
                }
                return null;
            }
        }

        public bool AddShipment(Shipment shipment)
        {
            if (shipment != null && count < 20)
            {
                shipments[count] = shipment;
                count++;
                return true;
            }
            return false;
        }

        public bool RemoveShipment(string trackingCode)
        {
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (shipments[i] != null && shipments[i].TrackingCode.Equals(trackingCode, StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                for (int i = index; i < count - 1; i++)
                {
                    shipments[i] = shipments[i + 1];
                }
                shipments[count - 1] = null;
                count--;
                return true;
            }
            return false;
        }

        public void PrintAllShipments()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine($"Delivery Center : {CenterName}");
            Console.WriteLine("==================================================");

            if (count == 0)
            {
                Console.WriteLine("No shipments available.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                if (shipments[i] is StandardShipment)
                    Console.WriteLine("\n--- Standard Shipment ---");
                else if (shipments[i] is ExpressShipment)
                    Console.WriteLine("\n--- Express Shipment ---");
                else if (shipments[i] is InternationalShipment)
                    Console.WriteLine("\n--- International Shipment ---");

                shipments[i].PrintShipment();
                Console.WriteLine("--------------------------------------------------");
            }
        }
    }

    // 5. Main Program Execution
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Read center name and create DeliveryCenter
            Console.Write("Enter Delivery Center Name: ");
            string centerName = Console.ReadLine();
            DeliveryCenter center = new DeliveryCenter(centerName);

            // Default shared address for test input
            DeliveryAddress defaultAddress = new DeliveryAddress("Cairo", "El-Nassr St", 10);

            // 2. Create StandardShipment
            Console.WriteLine("\n--- Entering Standard Shipment Data ---");
            StandardShipment std = new StandardShipment("SH001", "Laptop", 3, 80, defaultAddress);
            if (center.AddShipment(std))
                Console.WriteLine("Shipment Added Successfully.");

            // 3. Create ExpressShipment
            Console.WriteLine("\n--- Entering Express Shipment Data ---");
            ExpressShipment exp = new ExpressShipment("SH002", "Mobile Phone", 2, 60, defaultAddress, 30);
            if (center.AddShipment(exp))
                Console.WriteLine("Shipment Added Successfully.");

            // 4. Create InternationalShipment
            Console.WriteLine("\n--- Entering International Shipment Data ---");
            InternationalShipment inter = new InternationalShipment("SH003", "Documents", 1, 100, defaultAddress, "Germany", 150);
            if (center.AddShipment(inter))
                Console.WriteLine("Shipment Added Successfully.");

            // 5. Print All Shipments
            Console.WriteLine();
            center.PrintAllShipments();

            // 6. Search for a shipment using indexer
            Console.Write("\nEnter Tracking Code to Search: ");
            string searchCode = Console.ReadLine();
            Shipment found = center[searchCode];

            if (found != null)
            {
                Console.WriteLine($"\n[FOUND] Shipment Details:");
                found.PrintShipment();
            }
            else
            {
                Console.WriteLine("\nShipment Not Found!");
            }

            // 7. Remove a shipment
            Console.Write("\nEnter Tracking Code to Remove: ");
            string removeCode = Console.ReadLine();
            if (center.RemoveShipment(removeCode))
            {
                Console.WriteLine($"Shipment {removeCode} removed successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to remove shipment {removeCode}.");
            }

            // 8. Print Remaining Shipments
            Console.WriteLine("\n--- Remaining Shipments After Removal ---");
            center.PrintAllShipments();
        }
    }

    #endregion
}