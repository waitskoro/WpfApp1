using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Генерация значения ID
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string? numberPhone { get; set; }
        public List<Task>? Tasks { get; set; }
    }
}