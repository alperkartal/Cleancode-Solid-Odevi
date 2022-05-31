//Kötü kod örneği

interface ICustomer
{
    void Add();
}

interface ICustomerImproved
{
    void Add();
    void Read(); 
}

//İyi kod örneği

interface ICustomerV1 : ICustomer
{
    void Read();
}

class CustomerWithRead : ICustomer, ICustomerV1
{
    void Add()
    {
        var customer = new Customer();
        customer.Add(new Database());
    }

    void Read()
    {
        
    }
}

// e.g.
void ManipulateCustomers()
{
    var database = new Database();
    var customer = new Customer();
    customer.Add(database); 
    var readCustomer = new CustomerWithRead();
    readCustomer.Read(); 
}