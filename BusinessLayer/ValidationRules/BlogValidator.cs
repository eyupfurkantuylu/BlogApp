using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{

    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Blog başlığı 3 karakterden az olamaz.")
                .MaximumLength(150).WithMessage("Blog başlığı 150 karakterden uzun olamaz.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş bırakılamaz.")
                .MinimumLength(160).WithMessage("Blog içeriği 160 karakterden az olamaz.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog kapak görseli boş bırakılamaz");
        }
    }
}