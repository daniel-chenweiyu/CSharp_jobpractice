using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PracticeWork.Models.ViewModels
{
    public class StudentViewModels
    {
        public IEnumerable<Student> Student { get; set; }
        public IEnumerable<Score> Score { get; set; }
        public IEnumerable<Class> Class { get; set; }

    }
}