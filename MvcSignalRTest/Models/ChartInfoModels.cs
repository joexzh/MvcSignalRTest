using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcSignalRTest.Models
{
    public class ChartInfoModels
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(300), MinLength(1)]
        public string ChatString { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

    }
}