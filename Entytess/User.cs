using System.ComponentModel.DataAnnotations;

namespace ex01
{
    public class User
    {

        public int UserId { get; set; }
        //[EmailAddress]
        public string UserName { get; set; }
        
        public string Password { get; set; }
        //[StringLength(10)]
        public string FirstName { get; set; }
        //[StringLength(10)]
        public string LastName { get; set; }


    }
}
