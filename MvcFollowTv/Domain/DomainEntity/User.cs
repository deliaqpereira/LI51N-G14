using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Domain.DomainEntity
{
    public class User
    {
        public static string[] Roles = { "Admin", "User", "Hold" };
        public string[] Role { get; set; }


        [Required]
        [Display(Name = "nickname")]
        [RegularExpression(@"(\S)+", ErrorMessage = "White space is not allowed")]
        public string Nickname { get; set; }

        [Display(Name = "Imagem")]
        public String Image { get; set; }

        [Display(Name = "Activated")]
        public Boolean activated;


        private readonly string activateCode = RandomString(20);
        public Boolean activate(string Codeactivate)
        {
            if (activateCode == Codeactivate)
            {
                activated = true;
                return true;
            }
            return false;
        }

        public string getActivatedCode()
        {
            return activateCode;
        }


        [Required]
        [StringLength(25, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)\b", ErrorMessage = "Email not Valid")]
        [Display(Name = "Email address")]
        public String Email { get; set; }


        private static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString().ToLower();
        }
    }
}
