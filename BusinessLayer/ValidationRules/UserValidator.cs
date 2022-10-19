using EntityLayer.Concrete;
using EntityLayer.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator: AbstractValidator<UserVM>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Alanı Boş Geçilemez");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez");

            RuleFor(x => x.PasswordAgain).NotEmpty().WithMessage("Şifre Boş Geçilemez");

            RuleFor(x => x.Password).MinimumLength(5).WithMessage("Şifre 5 karakterden az olamaz");

            RuleFor(x => x.UserName).MinimumLength(5).WithMessage("Kullanıcı Adı 5 Karakterden az olamaz");


        }
        

    }
}
