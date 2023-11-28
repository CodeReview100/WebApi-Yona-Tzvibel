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
        //IUserServies _userServies; (lowercase) 

        //IUserServies userServies
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
                //Use Unauthorized() , (or NoContent())
                //The 401 (Unauthorized) status code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.
                //404 is indicating that the requested address (URL) is not found or does not exist.

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
        //function should return Task<ActionResult<User>>!
        {
            //newUser=  _UserServies.CreateNewUser(user);- save the answer in a variable!
            try
            { 
                
                _UserServies.CreateNewUser(user);
                //return  CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);newUser!!!
                //Check if newUser==null return BadRequest()
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
            }
            catch(Exception e) { throw (e); }//Why you catch the exception and throw it??? 
            //suggestion for shorter and nicer code- == null ? BadRequest() : CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);


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
            //function should return Task<ActionResult<User>>!
            //updatedUser=  await _UserServies.Put(id, userToUpdate);
            await _UserServies.Put(id, userToUpdate);
            //Check if updatedUser == null return noContent() else OK(upsatedUser) 

        }

    }
}
