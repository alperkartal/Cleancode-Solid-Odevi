//Kötü kod örneği

class Enquiry : Customer
{
    override int Discount(int sales)
    {
        return sales * 5;
    }

    override void Add(Database db)
    {
        throw new Exception("Not allowed");
    }
}

class BetterGoldCustomer : Customer
{
    override int Discount(int sales)
    {
        return sales - 100;
    }
}

class BetterSilverCustomer : Customer
{
    override int Discount(int sales)
    {
        return sales - 50;
    }
}

class ViolatingLiskovs
{
    void ParseCustomers()
    {
        var database = new Database();
        var customers = new List<Customer>
        {
            new GoldCustomer(),
            new SilverCustomer(),
            new Enquiry()
        };

        foreach (Customer c in customers)
        {
            // Enquiry.Add() will throw an exception here!
            c.Add(database);
        }
    }
}

//İyi kod örneği

interface IDiscount {
    int Discount(int sales);
}

interface IDatabase {
    void Add(Database db);
}

internal class Customer : IDiscount, IDatabase
{
    int Discount(int sales) { return sales; }
    void Add(Database db) { db.Add(); }
}

class AdheringToLiskovs
{
    public void ParseCustomers()
    {
        var database = new Database();
        var customers = new List<Customer>
        {
            new GoldCustomer(),
            new SilverCustomer(),
            new Enquiry()
        };

        foreach (Customer c in customers)
        {
            c.Add(database);
        }
    }
}