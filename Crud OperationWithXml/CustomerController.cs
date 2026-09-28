using Microsoft.AspNetCore.Mvc;
using MVCDHProject.Models;

namespace MVCDHProject.Controllers
{
    public class CustomerController : Controller
    {
        CustomerXmlDAL obj = new CustomerXmlDAL();
        
        public ViewResult DisplayCustomers()
        {
            return View(obj.Customer_Select());
        }
        public ViewResult DisplayCustomer(int Custid)
        {
            return View(obj.Customer_Select(Custid));
        }
        [HttpGet]
        public ViewResult AddCustomer()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            obj.Customer_Insert(customer);
            return RedirectToAction("DisplayCustomers");
        }
        public ViewResult EditCustomer(int Custid)
        {
            return View(obj.Customer_Select(Custid));
        }
        public ActionResult UpdateCustomer(Customer customer)
        {
            obj.Customer_Update(customer);
            return RedirectToAction("DisplayCustomers");
        }
        public ActionResult DeleteCustomer(int Custid)
        {
            obj.Customer_Delete(Custid);
            return RedirectToAction("DisplayCustomers");
        }
    }
}
