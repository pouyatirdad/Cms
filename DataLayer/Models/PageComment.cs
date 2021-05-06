using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageComment
    {
        [Key]
        public int CommentID { get; set; }
        public int PageID { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Name { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string Comment { get; set; }
        [Display(Name = "ایمیل")]
        [MaxLength(500)]
        public string Email { get; set; }
        [Display(Name = "نمایش دادن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool Show { get; set; }
        [Display(Name = "تاریخ ارسال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime CreateDate { get; set; }

        public Page page { get; set; }
        public PageComment()
        {

        }
    }
}
