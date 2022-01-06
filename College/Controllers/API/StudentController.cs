using College.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace College.Controllers.API
{
    public class StudentController : ApiController
    {
        static string ConnectionString = "Data Source=desktop-l8k7db0;Initial Catalog=CollegeDB;Integrated Security=True;Pooling=False";
        // GET: api/Student
        DataClasses1DataContext CollegeDB = new DataClasses1DataContext(ConnectionString);
     
        public IHttpActionResult Get()
        {


            try
            {
         return Ok(CollegeDB.Students.ToList());
                

            }
            catch (SqlException err)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            //return Ok();
        }

        //GET: api/Student/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(CollegeDB.Students.First((StudentItem) => StudentItem.Id == id));
                

            }
            catch (SqlException err)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: api/Student
        public IHttpActionResult Post([FromBody] Student student)
        {
            try
            {
                CollegeDB.Students.InsertOnSubmit(student);
                CollegeDB.SubmitChanges();
                return Ok("item was add");
             

            }
            catch (SqlException err)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Student/5
        public IHttpActionResult Put(int id, [FromBody] Student student)
        {
            try
            {
                Student StudentFound = CollegeDB.Students.First((StudentItem) => StudentItem.Id == id);
                StudentFound.FName = student.FName;
                StudentFound.LName=student.LName;
                StudentFound.Email=student.Email;
                StudentFound.BirthDay=student.BirthDay;
                StudentFound.YearSchool=student.YearSchool;
                CollegeDB.SubmitChanges();
                return Ok("item was update");
            }
            catch(SqlException err)
            {
                return Ok(new { err.Message });
            }
            catch(Exception err)
            {
                return Ok(new { err.Message });
            }
        }

        // DELETE: api/Student/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                CollegeDB.Students.DeleteOnSubmit(CollegeDB.Students.First((studentItem) => studentItem.Id == id));
                CollegeDB.SubmitChanges();

                return Ok("item was deleted");
            }
            catch (SqlException err)
            {
                return Ok(new { err.Message });
            }
            catch(Exception err)
            {
                return Ok(new { err.Message });
            }
        }

    }
}
