using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

/*
Để cài đặt các thư viện về webapi, http:
    1. Tools -> Nuget Package Manager -> Console
    2. Chạy lệnh: Install-Package Microsoft.AspNet.WebApi.Core
*/
namespace WebAPI.Controllers
{
    public class CustomersController : ApiController
    {
        static String connectionString = "Data Source=DungNguyen;Initial Catalog = CSDL_EXAMPLE_WEB_API; Integrated Security = True";
        //httpGet: dùng để lấy thông tin khách hàng
        //1. Dịch vụ lấy thông tin của toàn bộ khách hàng
        [HttpGet]
        public List<tblKhach> GetCustomerLists()
        {
            DBCustomersDataContext dbCustomer = new DBCustomersDataContext(connectionString);
            return dbCustomer.tblKhaches.ToList();
        }
        //2. Dịch vụ lấy thông tin một khách hàng với mã nào đó
         [HttpGet]
 public tblKhach GetCustomer(string id)
        {
            DBCustomersDataContext dbCustomer = new DBCustomersDataContext(connectionString);
            return dbCustomer.tblKhaches.FirstOrDefault(x =>x.MaKhach == id);
        }
        //3. httpPost, dịch vụ thêm mới một khách hàng
        [HttpPost]
        public bool InsertNewCustomer(string id, string name,
       string address, string phoneNumber)
        {
            try
            {
                DBCustomersDataContext dbCustomer = new DBCustomersDataContext(connectionString);
                tblKhach customer = new tblKhach();
                customer.MaKhach = id;
                customer.TenKhach = name;
                customer.DiaChi = address;
                customer.DienThoai = phoneNumber;

                dbCustomer.tblKhaches.InsertOnSubmit(customer);
                dbCustomer.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //4. httpPut để chỉnh sửa thông tin một khách hàng
        [HttpPut]
        public bool UpdateCustomer(string id, string name,
       string address, string phoneNumber)
        {
            try
            {
                DBCustomersDataContext dbCustomer = new DBCustomersDataContext(connectionString);
                //Lấy mã khách đã có
                tblKhach customer =
               dbCustomer.tblKhaches.FirstOrDefault(x => x.MaKhach == id);
                if (customer == null) return false;
                customer.MaKhach = id;
                customer.TenKhach = name;
                customer.DiaChi = address;
                customer.DienThoai = phoneNumber;
                dbCustomer.SubmitChanges();//Xác nhận chỉnh sửa
            return true;
            }
            catch
            {
                return false;
            }
        }
        //5.httpDelete để xóa một Khách hàng
        [HttpDelete]
        public bool DeleteCustomer(string id)
        {
            try
            {
                DBCustomersDataContext dbCustomer = new DBCustomersDataContext(connectionString);
                //Lấy mã khách đã có
                tblKhach customer =
               dbCustomer.tblKhaches.FirstOrDefault(x => x.MaKhach == id);
                if (customer == null) return false;

                dbCustomer.tblKhaches.DeleteOnSubmit(customer);
                dbCustomer.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
