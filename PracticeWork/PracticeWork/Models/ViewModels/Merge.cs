using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeWork.Models.ViewModels
{
    public class Merge
    {
        public IEnumerable<MovieType> MovieType { get; set; }
        public IEnumerable<MovieTheater> MovieTheater { get; set; }
    }
}