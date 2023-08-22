using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Ad soyad alanı boş olamaz.");
            RuleFor(x => x.AuthorMail).NotEmpty().WithMessage("Email alanı boş olamaz.")
                                      .EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz.");
            RuleFor(x => x.AuthorPassword).NotEmpty().WithMessage("Şifre alanı boş olamaz.")
                    .MinimumLength(6).WithMessage("Şifreniz 6 karakterden uzun olmalıdır.")
                    .Matches(@"[A-Z]+").WithMessage("Şifrenizde büyük karakter yok. Şifreniz en az bir büyük harf, bir küçük harf, rakam ve özel karakterden oluşmalı.")
                    .Matches(@"[a-z]+").WithMessage("Şifrenizde küçük karakter yok. Şifreniz en az bir büyük harf, bir küçük harf, rakam ve özel karakterden oluşmalı.")
                    .Matches(@"[0-9]+").WithMessage("Şifrenizde rakam yok. Şifreniz en az bir büyük harf, bir küçük harf, rakam ve özel karakterden oluşmalı.")
                    .Matches(@"[\!\?\*\.\@]+").WithMessage("Şifrenizde (!? *.@) karakterlerden biri yok. Şifreniz en az bir büyük harf, bir küçük harf, rakam ve özel karakterden oluşmalı.");
            RuleFor(x => x.AuthorName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriş yapın.");
            RuleFor(x => x.AuthorName).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter giriş yapın.");



        }
    }
}