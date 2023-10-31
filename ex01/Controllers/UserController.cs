using ex01;
using Microsoft.AspNetCore.Mvc;
using repository;
using servies;
using System.Diagnostics;
using System.Text.Json;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly string filePath = "./new.txt";

        IUserServies _UserServies;

        public UserController(IUserServies UserServies)
        {
            _UserServies = UserServies;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<User>> Get([FromQuery] string userName = "", [FromQuery] string password = "")
        {
            User user = await _UserServies.getUserByUserNameAndPassword(userName, password);
            if (user == null)
                return NotFound();
            return Ok(user);
            //try
            //{
            //    return await Ok(_userController.getUserByEmailAndPassword(userName, password));
            //}
            //catch (Exception e)
            //{
            //    return BadRequest();
            //}
        }


        // POST api/<UserController>
        [HttpPost]
        public async Task<CreatedAtActionResult> Post([FromBody] User user)
        {
            
            try { 
                
                _UserServies.CreateNewUser(user);
            return  CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
            }
            catch(Exception e) { throw (e); }


        }
        [HttpPost("check")]
        public async Task<int> Check([FromBody] string password)
        {
            
            if (password != "")
            {
               
                return await _UserServies.check(password);
            }
            return -1;

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
          await  _UserServies.Put(id, userToUpdate);


        }
        
    }
}
