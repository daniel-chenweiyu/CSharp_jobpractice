using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PracticeWork.Models
{
    [MetadataType(typeof(DetialMetadata))]
    public partial class Detail
    {
        public class DetialMetadata
        {
            [Required]
            public int Id { get; set; }
            [Display(Name = "片名")]
            [Required]
            public string Title { get; set; }
            [Display(Name = "上映日期")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Required]
            public System.DateTime ReleasDate { get; set; }
            [Display(Name = "類型")]
            [Required]
            public string Genre { get; set; }
            [Display(Name = "票價")]
            [Required]
            public decimal Price { get; set; }
            [Display(Name = "是否可預訂")]
            [Required]
            public string Reservation { get; set; }
            [Display(Name = "上映電影院")]
            [Required]
            public string Theater { get; set; }
        }
    }
}