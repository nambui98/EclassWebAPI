using EclassWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EclassWebAPI.DTO;
namespace EclassWebAPI.Controllers
{
    public class StudentController : ApiController
    {
        // GET: api/Student
        public HttpResponseMessage Get()
        {
            EClassEntities db = new EClassEntities();
            var result = from s in db.Students
                         select new { s.StudentID, s.FullName, s.Class.Period };
            return Request.CreateResponse(HttpStatusCode.OK, result.ToList());
        }
        // GET: api/Student/5
            public StudentDTO Get(string id)
        {
            using(EClassEntities db=new EClassEntities())
            {
                Student s = db.Students.SingleOrDefault(x => x.StudentID == id);
                if (s != null)
                {
                    return new StudentDTO(s.StudentID,s.FullName, s.Birthday);
                }
                else
                {
                    return null;
                }
            }
        }

        // POST: api/Student
        public HttpResponseMessage Post([FromBody]Student obj)
        {
            try
            {
                using (EClassEntities db = new EClassEntities())
                {
                    db.Students.Add(obj);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }

        // PUT: api/Student/5
        public HttpResponseMessage Put(string id, [FromBody] Student value)
        {
            try
            {
             
            using (EClassEntities db = new EClassEntities())
            {
                Student s = db.Students.SingleOrDefault(b => b.StudentID == id);
                if (s != null)
                {
                    s.StudentID = id;
                    s.FullName = value.FullName;
                    s.Email = value.Email;
                    s.Address = value.Address;
                    s.ClassID = value.ClassID;
                    s.PhoneNumber = value.PhoneNumber;
                    db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, s);
                    }
                else
                {
                    return null;
                }
            }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        public List<Student> getStudentsByGender(string gender)
        {
            using(EClassEntities db =new EClassEntities())
            {
                List<Student> liststudent = new List<Student>();
                if (gender == "all")
                {
                    liststudent = db.Students.ToList();

                }else if (gender == "female")
                {
                    liststudent = db.Students.Where(s => s.Gender == false).ToList();
                }
                else
                {
                    liststudent = db.Students.Where(s => s.Gender == true).ToList();
                }
                return liststudent;
            }
        }
        // DELETE: api/Student/5
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                using (EClassEntities db = new EClassEntities())
                {
                    Student s = db.Students.SingleOrDefault(x => x.StudentID == id);
                    db.Students.Remove(s);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
    }
}
