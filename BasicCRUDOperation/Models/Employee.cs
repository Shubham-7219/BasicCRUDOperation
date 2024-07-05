using System.ComponentModel.DataAnnotations;

namespace BasicCRUDOperation.Models
{
    public class Employee
    {

        public int Id {  get; set; }
        public string Name { get; set; }=string.Empty;
        [Range(0,150,ErrorMessage ="age must be between 0 to 150")]
        public int age {  get; set; }
        public decimal salary {  get; set; }
        [Display(Name= "Hire Date")]
        public DateTime HireDate { get; set; }
    }
}
