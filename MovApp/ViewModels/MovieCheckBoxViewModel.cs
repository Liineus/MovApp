using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovApp.ViewModels
{
    public class MovieCheckBoxViewModel
    {
        [Key]
        public short CheckBoxId { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
    }
}