using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori başlığı boş olamaz")
                .MaximumLength(50).WithMessage("Kategori başlığı 50 karakterden uzun olamaz")
                .MinimumLength(2).WithMessage("Kategori başlığı 2 karakterden uzun olmalıdır");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması boş olamaz");

        }
    }
}

