using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1
{
    public class Task : BaseViewModel
    {
        public StatusTask Status;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Генерация значения ID
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int userIDCreated { get; set; }
        public int? userIDAccepted { get; set; }
        [Required]
        public int StatusTaskId { get; set; }

        [Required]
        public virtual StatusTask? StatusTask
        {
            get { return Status; }
            set { Status = value; OnPropertyChanged(); }
        }
        public virtual User? User { get; set; }
    }
}