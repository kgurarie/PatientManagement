using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public abstract class BaseModel
    {
        #region Constructors
        protected BaseModel()
        {
        }
        #endregion

        #region Properties
        [Required]
        [Key]
        public int Id { get; set; }

        
        #endregion
    }

   
}
