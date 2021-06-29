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
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Post = new HashSet<Post>();
        }

        public int Id_user { get; set; }
        [Required(ErrorMessage = "Put the data in the field")]
        [Display(Name = "User name")]
        public string User_name { get; set; }
        [Required(ErrorMessage = "Put the data in the field")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string User_email { get; set; }
        [Required(ErrorMessage = "Put the data in the field")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string User_password { get; set; }
        [Required(ErrorMessage = "Put the data in the field")]
        [Display(Name = "Enter your password again")]
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("User_password", ErrorMessage = "Passwords are not equal")]
        public string User_repassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Post { get; set; }
    }
}
