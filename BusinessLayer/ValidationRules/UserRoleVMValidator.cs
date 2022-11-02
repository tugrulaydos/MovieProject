using EntityLayer.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserRoleVMValidator:AbstractValidator<RoleViewModel>
    {
        public UserRoleVMValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name Alani Boş Geçmeyiniz!!!");

        }
    }
}
