using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookstore.Models
{
    public class AuthorModels
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="lastname")]
        [MaxLength(40,ErrorMessage ="up to 40 characters only")]
        [Required (ErrorMessage = "required")]
        public string lastname { get; set; }
        [Display(Name = "firstname")]
        [Required(ErrorMessage = "required")]
        [MaxLength(20, ErrorMessage = "up to 20 characters only")]
        public string  firstname { get; set; }
        [MaxLength(12, ErrorMessage = "up to 12 characters only")]
        [Display(Name = "phone")]
        [Required(ErrorMessage = "required")]
        public string  phone { get; set; }
     
        [Display(Name = "address")]
        [MaxLength(20, ErrorMessage = "up to 20 characters only")]
        [DataType(DataType.MultilineText)]
        public string address { get; set; }
        [Display(Name = "city")]
        [MaxLength(20, ErrorMessage = "up to 20 characters only")]
        public string city { get; set; }
        [Display(Name = "state")]
        [MaxLength(2, ErrorMessage = "up to 2 characters only")]
        public string state { get; set; }
        [Display(Name = "zip")]
        [MaxLength(5, ErrorMessage = "up to 5 characters only")]

        public string zip { get; set; }

    }
}