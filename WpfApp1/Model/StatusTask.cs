using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1
{
    public class StatusTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Генерация значения ID
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }
    }
}