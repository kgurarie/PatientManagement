using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Patient : BaseModel
    {
        public Patient() : base() { }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string StreetAddress { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Suburb { get; set; }
        [Required]
        public int PostCode { get; set; }
        [Required]
        [ForeignKey("State")]
        public int StateId { get; set; }
        public State State { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Phone { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Gender { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string EmergencyContactName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string EmergencyContactPhone { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string UpdatedBy { get; set; }
        public IList<PatientAdmission> PatientAdmissions{ get; set; }


    }
}
