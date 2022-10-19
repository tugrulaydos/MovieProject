using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ArtistValidator:AbstractValidator<Artist>
    {
        public ArtistValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Full Name kısmını boş geçemessiniz.");
        }
    }
}
