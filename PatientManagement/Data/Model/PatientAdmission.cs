using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class PatientAdmission : BaseModel
    {
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string AdmissionReason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string UpdatedBy { get; set; }
    }
}
