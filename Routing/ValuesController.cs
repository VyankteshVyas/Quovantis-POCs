using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoletoWebApi.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // routing is basically mapping the incoming request to particular action method
        [Route("api/getAll")]
        [Route("getAll")]
        [Route("[action]/[controller]")]
        public string GetAll()
        {
            return "Hello from Get";
        }

        [Route("api/getAllAuthors")]
        [Route("[controller]/[action]")]
        public string GetAllAuthors()
        {
            return "Hello from Authors";
        }

        [Route("books/{id}")]
        public string getById(int id)
        {
            return "Id provided is " + id;
        }

        [Route("books/{id1}/author/{id2}")]
        public string getById2(int id1, int id2) {
            return "Id provided is " + id1 + "another id is "+id2;
        }

        //https://localhost:44320/search?name=nvak&id=7
        [Route("search")]
        public string searchBooks(int id, int authorId, string name, int rating, int price) {

            return "hello from search ";
        }
    }
}
