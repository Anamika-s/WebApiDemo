using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDemo.Models;
namespace WebApiDemo.Controllers
{
    public class StudentUsingIHTTPActionController : ApiController
    {
        static List<Student> studentList = null;
        public StudentUsingIHTTPActionController()
        {
            if (studentList == null)

            {
                studentList = new List<Student>()
                 {
               new Student() { StudentId=1, Name="Ajay" , Batch="B001", Marks=89, DateOfBirth=Convert.ToDateTime("12/12/2020")},
               new Student() { StudentId=2, Name="Deepak" , Batch="B002", Marks=78, DateOfBirth=Convert.ToDateTime("10/06/2020")},

                 };
            }
           
       }
        public List<Student> Get()
        {
            return studentList;
        }
        public IHttpActionResult Get(int id)
        {
            Student student = studentList.FirstOrDefault(x => x.StudentId == id);
            if (student != null)
                return Ok(student);
            else
                return NotFound();
            }

        [HttpPost]
        public IHttpActionResult Post(Student student)
        {
            studentList.Add(student);
            return Created("Record inserted", student);
           //return Request.CreateResponse(HttpStatusCode.Created, "Record inserted");
        }

        [HttpPut]
        public void Put (int id, Student student)
        {
            Student obj = studentList.Where(x => x.StudentId == id).FirstOrDefault();

            if (student != null)
            {
                foreach (Student temp in studentList)
                {
                    if (temp.StudentId == id)
                    {
                        temp.Name = student.Name;
                        temp.DateOfBirth = student.DateOfBirth;
                        temp.Batch = student.Batch;
                        temp.Marks = student.Marks;
                    }
                }
            }
           

        }
        public void Delete(int id)
        {
            Student student = studentList.Where(x => x.StudentId == id).FirstOrDefault();

            if (student != null)
            {
                studentList.Remove(student);
            }

        }
    }
}
