﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EntityLayer.ViewModels
{
    public class UserVM
    {
        //[Required(ErrorMessage = "Lütfen kullanıcı adını boş geçmeyiniz...")]
        //[StringLength(15, ErrorMessage = "Lütfen kullanıcı adını 4 ile 15 karakter arasında giriniz...", MinimumLength = 4)]
        //[Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }


        //[Required(ErrorMessage = "Lütfen emaili boş geçmeyiniz...")]
        //[EmailAddress(ErrorMessage = "Lütfen email formatında bir değer belirtiniz...")]
        //[Display(Name = "Email")]
        public string Email { get; set; }


        //[Required(ErrorMessage = "Lütfen şifreyi boş geçmeyiniz...")]
        [DataType(DataType.Password, ErrorMessage = "Lütfen şifreyi tüm kuralları göz önüne alarak giriniz...")]
        //[Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Lütfen şifreyi tüm kuralları göz önüne alarak giriniz...")]
        public string PasswordAgain { get; set; }

        //Eşleştirmeler otomatik yapılacak şifre proporty'si Hariç

    }
}
