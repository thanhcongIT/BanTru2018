using DataConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DataConnect.DAO.HungTD;
using QLHSBanTru2018_Demo_V1.Common;

namespace QLHSBanTru2018_Demo_V1.DAO.HungTD
{
    public class LoginDAO
    {
        QLHSSmartKidsDataContext db = new QLHSSmartKidsDataContext();
        Table<Employee> employee;

        public int Login(string username, string password)
        {
            try
            {
                employee = db.GetTable<Employee>();
                HistoryDAO historyDAO = new HistoryDAO();
                var user = (from emp in employee
                            where emp.Username.Equals(username)
                            select new
                            {
                                emp.EmployeeID,
                                emp.Username,
                                emp.Password,
                                emp.FirstName,
                                emp.LastName,
                                emp.Status
                            });
                if (user.Count() > 0)
                {
                    if (user.FirstOrDefault().Password.Equals(password))
                    {
                        if (user.FirstOrDefault().Status.Equals(true))
                        {
                            historyDAO.Insert(user.FirstOrDefault().EmployeeID,1,"Thành công");
                            LoginDetail.LoginID = user.FirstOrDefault().EmployeeID;
                            LoginDetail.LoginName = user.FirstOrDefault().FirstName + " " + user.FirstOrDefault().LastName;
                            //Thêm mới lịch sử hoạt động
                            return 1; //Đăng nhập thành công
                        }
                        else
                        {
                            historyDAO.Insert(user.FirstOrDefault().EmployeeID, 1, "Thất bại");
                            //Thêm mới lịch sử hoạt động
                            return -1; //Tài khoản đã bị khóa
                        }
                    }
                    else
                    {
                        historyDAO.Insert(user.FirstOrDefault().EmployeeID, 1, "Thất bại");
                        //Thêm mới lịch sử hoạt động
                        return 2; //Mật khẩu không chính xác
                    }
                }
                else
                {
                    return -2; //Tài khoản không tồn tại
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return 0; //Đã xảy ra lỗi trong quá trình đăng nhập
            }
        }

    }
}
