//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Forum.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Topic
    {
        public int Id_topic { get; set; }
        [Required(ErrorMessage = "Put the data in the field")]
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Put the data in the field")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    

        public virtual Post Post { get; set; }
    }
}
