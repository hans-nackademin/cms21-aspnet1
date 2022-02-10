using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace _00_WebApi.WithAuthenication.Models.Entitites
{
    public class UserEntity
    {
        public UserEntity(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        [Key]
        public int Id { get; set; }
        
        [Required, Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required, Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required, Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required, Column(TypeName = "varbinary(max)")]
        public byte[] SecurityChecksum { get; private set; }

        [Required, Column(TypeName = "varbinary(max)")]
        public byte[] SecurityStamp { get; private set; }


        public void CreateSecurePassword(string password)
        {
            using var hmac = new HMACSHA512();
            SecurityStamp = hmac.Key;
            SecurityChecksum = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));           
        }

        public bool CompareSecurePassword(string password)
        {
            using (var hmac = new HMACSHA512(SecurityStamp))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < hash.Length; i++)
                    if (hash[i] != SecurityChecksum[i])
                        return false;
            }

            return true;
        }
    }
}
