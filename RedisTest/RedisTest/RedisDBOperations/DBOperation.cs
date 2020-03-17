using Newtonsoft.Json;
using RedisWPF_CRUD.Model;
using StackExchange.Redis;
using System;
using System.Collections.Generic;


namespace RedisWPF_CRUD.RedisDBOperations
{
    public class DBOperation
    {
        private void InsertBulkStudent()
        {
            var numberOfRecords = 10;

            var cache = RedisConnector.GetRedisInstance();

            for (int i = 1; i <= numberOfRecords; i++)
            {
                cache.StringSet(
                        "Student" + i
                        , JsonConvert.SerializeObject(
                                new Student()
                                {
                                    StudentID = i
                                                ,
                                    StudentName = "Student" + i
                                                ,
                                    Gender = i % 2 == 0 ? "Male" : "Female"
                                                ,
                                    DOB = DateTime.Now.AddYears(i).ToString()
                                }
                                ));
            }
        }

        /// 

        /// Fetch the students
        /// 
        /// 
        public List<Student> GetStudentRecords()
        {
            //Insert Student Records
            InsertBulkStudent();

            var studentList = new List<Student>();
            var cache = RedisConnector.GetRedisInstance();
            var numberOfRecords = 10;

            for (int i = 1; i <= numberOfRecords; i++)
            {
                var r = cache.StringGet("Student" + i).ToString();
                studentList.Add(JsonConvert.DeserializeObject<Student>(r));
            }
            return studentList;
        }
    }
}

