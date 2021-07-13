using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CRUD_Operations.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }

        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }


        
    }
}
