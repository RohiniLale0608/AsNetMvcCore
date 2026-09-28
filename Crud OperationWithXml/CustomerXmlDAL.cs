using System.Data;

namespace MVCDHProject.Models
{
    public class CustomerXmlDAL
    {
        DataSet ds;
        public CustomerXmlDAL() 
        { 
            ds = new DataSet();
            ds.ReadXml("Customer.xml");
            // Adding Primary Key on Custid of DataTable
            // In XMl it Don't Have Primary Key Thats Why We are creating here using Dataset
            ds.Tables[0].PrimaryKey = new DataColumn[]{ds.Tables[0].Columns["Custid"]};
        }
        public List<Customer> Customer_Select()
        {
            List<Customer> customer = new List<Customer>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Customer obj = new Customer
                {
                    Custid = Convert.ToInt32(dr["Custid"]),
                    Name = Convert.ToString(dr["Name"]),
                    Balance = Convert.ToDecimal(dr["Balance"]),
                    City = Convert.ToString(dr["City"]),
                    Status = Convert.ToBoolean(dr["Status"])
                };
                customer.Add(obj);
            }
            return customer;
        }
        public Customer Customer_Select(int Custid)
        {
            // Finding a DataRow based on its Primary Key value
            // we can enable nullable reference type
            // This variable may hold either a DataRow object or null
            // This helps avoid null reference exceptions and makes your code safer.
            DataRow? dr = ds.Tables[0].Rows.Find(Custid);
            Customer customer = new Customer
            {
                Custid = Convert.ToInt32(dr["Custid"]),
                Name = Convert.ToString(dr["Name"]),
                Balance = Convert.ToDecimal(dr["Balance"]),
                City = Convert.ToString(dr["City"]),
                Status = Convert.ToBoolean(dr["Status"])
            };
            return customer;
        }
        public void Customer_Insert(Customer customer)
        {
            // Creating new DataRow based on DataTable structure
            DataRow dr = ds.Tables[0].NewRow();
            // Assigning values to each Column of the DataRow
            dr["Custid"] = customer.Custid;
            dr["Name"] = customer.Name;
            dr["Balance"] = customer.Balance;
            dr["City"] = customer.City;
            dr["Status"] = customer.Status;
            // Adding the new DataRow to DataTable
            ds.Tables[0].Rows.Add(dr);
            // saving data back to XML file
            ds.WriteXml("Customer.xml");
        }
        public void Customer_Update(Customer customer)
        {
            // Finding DataRow based on its Primary Key value
            DataRow? dr = ds.Tables[0].Rows.Find(customer.Custid);
            // Finding the index of DataRow by calling IndexOf method
            int index = ds.Tables[0].Rows.IndexOf(dr);
            // Overriding the old value in dataRow with new values based on the Index
            ds.Tables[0].Rows[index]["Name"] = customer.Name;
            ds.Tables[0].Rows[index]["Balance"] = customer.Balance;
            ds.Tables[0].Rows[index]["City"] = customer.City;
            // Saving data back to Xml file
            ds.WriteXml("Customer.xml");
        }
        public void Customer_Delete(int Custid)
        {
            // find datarow based on its primary key
            DataRow? dr = ds.Tables[0].Rows.Find(Custid);
            // finding the index of DataRow by calling IndexOf method
            int index = ds.Tables[0].Rows.IndexOf(dr);
            // Deleting the DataRow from Datatable by using Index
            ds.Tables[0].Rows[index].Delete();
            ds.WriteXml("Customer.xml");
        }
    }
}
