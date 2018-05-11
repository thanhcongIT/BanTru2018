using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConnect.DAO.ThanhCongTC.TCViewModle;
using DataConnect.ViewModel;

namespace DataConnect.DAO.ThanhCongTC
{
    public class ClassStudentDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        public static int StudentID = 0;
        
        public List<Student> ListStudent(int ClID)
        {
            var a = dt.Student_Classes.Where(t => t.ClassID == ClID);
            a.ToList();
            List<ReceivableDetail_Student> listStudenReceivableDetail = new List<ReceivableDetail_Student>();
            List<Student> ListStudent = new List<Student>();
            List<TCStudentViewModle> listViewStuden = new List<TCStudentViewModle>();
            foreach (var i in a)
            {
                ReceivableDetail_Student st = new ReceivableDetail_Student();
                st = dt.ReceivableDetail_Students.Where(t => t.StudentID == i.StudentID).FirstOrDefault();
                listStudenReceivableDetail.Add(st);
            }
            foreach (var js in listStudenReceivableDetail)
            {
                Student b = new Student();
                b = dt.Students.FirstOrDefault(t => t.StudentID == js.StudentID);
                ListStudent.Add(b);

               
            }
            return ListStudent;
        }      
        public List<TCStudentViewModle> listviewSD(int classID,int ReceivableID)
        {
            List<ReceivableDetail_Student> listStudenReceivableDetail = new List<ReceivableDetail_Student>();
            List<TCStudentViewModle> listViewStuden = new List<TCStudentViewModle>();
            List<ReceivableDetail> listReceivableDetail = new List<ReceivableDetail>();
            // danh sách chi tiết khoản thu
            var a1 = dt.ReceivableDetails.Where(t => t.ReceivableID == ReceivableID);
            a1.ToList();
            // lấy học sinh của lớp classID
            var a = dt.Student_Classes.Where(t => t.ClassID == classID);
            a.ToList();
            //từ danh sách học sinh của lớp đó lấy ra danh sách học danh sách học sinh với khoản thu tương tứng
            foreach (var i in a)
            {
                ReceivableDetail_Student st = new ReceivableDetail_Student();
                foreach (var item in a1)
                {
                    st = dt.ReceivableDetail_Students.Where(t => t.StudentID == i.StudentID&&t.ReceivableDetailID==item.ReceivableDetailID).FirstOrDefault();
                    if (st!=null)
                    {
                        listStudenReceivableDetail.Add(st);
                    }
                    
                    break;
                }
                
            }
            //danh sách học sinh theo các khoản thu
            foreach (var js in listStudenReceivableDetail)
            {
                Student b = new Student();
                b = dt.Students.FirstOrDefault(t => t.StudentID == js.StudentID);
                //ListStudent.Add(b);
                TCStudentViewModle d = new TCStudentViewModle();
                d.StudentID = b.StudentID;
                d.StudentCode = b.StudentCode;
                d.FirstName = b.FirstName;
                d.LastName = b.LastName;
                d.HomeName = b.HomeName;
                d.Birthday = b.Birthday;
                d.Gender = b.Gender == true ? "Nam" : "Nữ";
                //d.Image = b.Image.ToArray();
                d.Hobby = b.Hobby;
                d.Talent = b.Talent;
                d.DateStudy = b.DateStudy;
                d.EthnicGroupID = b.EthnicGroupID;
                d.ReligionID = b.ReligionID;
                d.BirthPlaceID = b.BirthPlaceID;
                d.LocationID = b.LocationID;
                d.AdressDetail = b.AdressDetail;
                //d.PreferredID = (int)b.PreferredID;
                d.Note = b.Note;
                d.Status = b.Status;
                listViewStuden.Add(d);
            }

            return listViewStuden;
        }
        public Student lookForStuden(int studentID)
        {
            Student a = dt.Students.FirstOrDefault(t => t.StudentID == studentID);
            return a;
        }
    }
}
