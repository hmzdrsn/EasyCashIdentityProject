using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Ad Alanı Boş Geçilemez");
            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("Soyad Alanı Boş Geçilemez");
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Kullanıcı Adı Alanı Boş Geçilemez");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email Alanı Boş Geçilemez");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Şifre Alanı Boş Geçilemez");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Şifre Tekrar Alanı Boş Geçilemez");
            RuleFor(x => x.Name)
                .MaximumLength(30)
                .WithMessage("Ad en fazla 30 karakter olabilir!");
            RuleFor(x => x.Name)
                .MinimumLength(2)
                .WithMessage("Ad en az 2 karakter olabilir!");
            RuleFor(x => x.ConfirmPassword)
                .Equal(y => y.Password)
                .WithMessage("Parola Eşleşmedi");
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Geçerli bir mail adresi giriniz");
        }
    }
}
