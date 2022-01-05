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
        string ConnectionString = "Data Source=desktop-l8k7db0;Initial Catalog=CollegeDB;Integrated Security=True;Pooling=False";
        // GET: api/Student
        List<Student> listOfStudents = new List<Student>();
        public IHttpActionResult Get()
        {


            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = @"SELECT * FROM Students";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader dataFromDB = command.ExecuteReader();
                    if (dataFromDB.HasRows)
                    {
                        while (dataFromDB.Read())
                        {
                            listOfStudents.Add(new Student(
                                dataFromDB.GetString(1),
                            dataFromDB.GetString(2),
                            dataFromDB.GetDateTime(3),
                            dataFromDB.GetString(4),
                            dataFromDB.GetInt32(5)));
                        }
                        return Ok(new { listOfStudents });
                    }
                    //else
                    //{
                    //    Console.WriteLine("no rows in table");
                    //}
                    //return listOfStudents;
                    connection.Close();
                    return Ok(new { listOfStudents });
                }

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
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = $@"SELECT * FROM Students WHERE Id={id}";
                    SqlCommand Command = new SqlCommand(query, connection);
                    SqlDataReader dataFromDB = Command.ExecuteReader();
                    if (dataFromDB.HasRows)
                    {
                        while (dataFromDB.Read())
                        {
                            listOfStudents.Add(new Student(
                            dataFromDB.GetString(1),
                            dataFromDB.GetString(2),
                            dataFromDB.GetDateTime(3),
                            dataFromDB.GetString(4),
                            dataFromDB.GetInt32(5)));
                        }
                        return Ok(new { listOfStudents });
                    }
                    connection.Close();
                    return Ok(new { listOfStudents });
                }

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
        public IHttpActionResult Post([FromBody] string value)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO Students (FName,LName,BirthDay,Email,YearSchool)
                                     VALUES('djfs','jkfhcds',01-01-2020,'kdsj@jfhjk',8)";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader dataFromDB = command.ExecuteReader();
                    if (dataFromDB.HasRows)
                    {
                        while (dataFromDB.Read())
                        {
                            listOfStudents.Add(new Student(
                                dataFromDB.GetString(1),
                            dataFromDB.GetString(2),
                            dataFromDB.GetDateTime(3),
                            dataFromDB.GetString(4),
                            dataFromDB.GetInt32(5)));
                        }
                        return Ok(new { listOfStudents });
                    }
                    //else
                    //{
                    //    Console.WriteLine("no rows in table");
                    //}
                    //return listOfStudents;
                    connection.Close();
                    return Ok(new { listOfStudents });
                }

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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
        }
        static void SqlData(string ConnectionString)
        {

        }
    }
}
