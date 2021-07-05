using CRUD_Operations.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Operations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static List<Student> myStudents = new List<Student>()
        {
            new Student(){Id=1,Name="Aman",Roll=100 },
            new Student(){Id=2,Name="BAman",Roll=101 },
            new Student(){Id=3,Name="SAman",Roll=102 },
            new Student(){Id=4,Name="RAman",Roll=103 },
            new Student(){Id=5,Name="PAman",Roll=104 },
        };

        [HttpGet]
        public IActionResult Gets()
        {
            if (myStudents.Count == 0)
            {
                return NotFound("No list found");
            }
            return Ok(myStudents);
        }

        [HttpGet("GetStudent")]
        public IActionResult Get(int id)
        {
            var currStu = myStudents.SingleOrDefault(x => x.Id == id);
            if (currStu == null) {
                return NotFound("No list found");
            }

            return Ok(currStu);
        }

        [HttpPost("")]
        public IActionResult AddNewStudent(Student currStu)
        {
            myStudents.Add(currStu);
            if (myStudents.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(myStudents);
        }

        [HttpPatch("")]
        public IActionResult ChangeStudentRoll([FromBody]Student stu)
        {
            var currStu = myStudents.SingleOrDefault(x => x.Id == stu.Id);
            if (currStu==null)
            {
                return NotFound("No matching item Found");
            }
            for (int i = 0; i < myStudents.Count; i++) {
                if (myStudents[i].Id == stu.Id)
                {
                    myStudents[i].Roll = stu.Roll;
                    break;
                }
            }
            
            return Ok(myStudents);
        }

        [HttpDelete("")]
        public IActionResult DeleteStudent(int id) {
            var currStu = myStudents.SingleOrDefault(x => x.Id == id);
            if (currStu == null)
            {
                return NotFound("No matching item Found");
            }
            myStudents.Remove(currStu);
            return Ok(myStudents);
        }

        [HttpPut("")]
        public IActionResult ChangeStudent([FromBody]Student stu,int id)
        {
            var currStu = myStudents.SingleOrDefault(x => x.Id == id);
            if (currStu == null)
            {
                return NotFound("No matching item Found");
            }
            for (int i = 0; i < myStudents.Count; i++) {
                if (myStudents[i].Id == id)
                {
                    myStudents[i] = stu;
                    break;
                }
            }
            return Ok(myStudents);
        }
    }
}
