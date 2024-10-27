using System.ComponentModel.DataAnnotations;

namespace Mohaymen_Cmd.Model
{
    internal class User
    {
        public required int ID { get; set; }
        [MaxLength(63)]
        public required string UserName { get; set; }
        [MaxLength(63)]
        public required string Password { get; set; }
        public required bool Status { get; set; }
        public required DateTime CreationDate { get; set; }
        public required DateTime ModificationDate { get; set; }
    }
}
