using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Page
    {
        [Key]
        public int PageID { get; set; }
        public int GroupID { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Title { get; set; }
        [Display(Name = "توضیح کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [Display(Name = "بازدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Views { get; set; }
        public bool Slider { get; set; }
        [Display(Name = "عکس")]
        public string Image { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd }")]
        public DateTime CreateDate { get; set; }

        public virtual List<PageComment> PageComments { get; set; }

        public virtual PageGroup PageGroup { get; set; }
        public Page()
        {

        }
    }
}
