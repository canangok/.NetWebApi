using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

using WebApi.Entities;
using WebApi.Services;


namespace WebApi.Controllers
{
    [EnableCors("*","*","*")]
    public class UsersController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        private readonly UserService _userService;

        public UsersController()
        {
            _userService = new UserService();
        }

        public IHttpActionResult Get()
        {
            // var list = new string[] {"Canan", "Beyza", "Hamza"};
            // var json=new Json(list);
            var list = _userService.GetUsers();
            return Ok(list);
        }

        // GET api/values/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var user = _userService.GetUser(id);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult Post([FromBody]User user)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(user.FullName))
                return BadRequest("Invalid data.");

            var list = _userService.AddUser(user);

            return Ok();
        }
        // POST api/values
        //public void Post([FromBody]string value)
        //{

        //}


        //[AllowAnonymous]
        //[HttpPost]
        //public IHttpActionResult Delete([FromBody]int id)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Invalid data.");

        //    bool result = _userService.RemoveUser(id);

        //    return Ok();
        //}
    }
}
