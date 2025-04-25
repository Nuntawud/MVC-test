using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSQL.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "ป้อนชื่อนักเรียน")]
        [DisplayName("ชื่อนักเรียน")]
        public string? Name { get; set; }
        [DisplayName("คะแนนสอบ")]
        [Range(0,100,ErrorMessage="ใส่คะแนนตั้งแต่ 0-100")]
        public int Score { get; set; }
    }
}