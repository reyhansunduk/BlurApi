using FluentValidation;
using BlurApi.Models;

namespace BlurApi.ValidationRules
{
    public class EnterpricesValidator : AbstractValidator<Enterprices>
    {
        public EnterpricesValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Şirket adı zorunludur.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir e-posta giriniz.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon zorunludur.")
                .Matches(@"^90\d{10}$").WithMessage("Telefon 90 ile başlamalı ve toplam 12 hane olmalıdır.");

            RuleFor(x => x.Balance)
                .PrecisionScale(18, 2, false)
                .WithMessage("Bakiye en fazla 2 ondalık basamak içermelidir.");

            RuleFor(x => x.TaxNumber)
                .InclusiveBetween(1_000_000_000, 9_999_999_999)
                .WithMessage("Vergi no 10 haneli olmalıdır.");

            RuleFor(x => x.TaxAddress)
                .NotNull().WithMessage("Vergi adresi zorunludur.");

            When(x => x.TaxAddress != null, () =>
            {
                RuleFor(x => x.TaxAddress!.Province)
                    .NotEmpty().WithMessage("İl zorunludur.");

                RuleFor(x => x.TaxAddress!.District)
                    .NotEmpty().WithMessage("İlçe zorunludur.");
            });
        }
    }
}
