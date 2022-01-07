using FluentValidation;
using Service.ViewModels;
using System.Linq;
using System.Text.RegularExpressions;


namespace Service
{
    public class PasswordValidation : AbstractValidator<Password>
    {
        public PasswordValidation()
        {
            RuleFor(x => x._password).NotNull().WithMessage("O password não pode ser nulo")
                .Length(1, 20).WithMessage("Ops, sua senha deve ter no minimo 1 e no máximo 20 caracteres")
                .Must(RequireDigitValidation).WithMessage(" Ops, sua senha deve ter pelo menos 1 número")
                .Must(RequiredLowerCaseValidation).WithMessage("Ops, sua senha deve ter pelo menos 1 caracter minúsculo")
                .Must(RequireUppercaseValidation).WithMessage("Ops, sua senha deve ter pelo menos 1 caracter maiúsculo")
                .Must(RequireNonAlphanumericValidation).WithMessage(" Ops, digite pelo menos 1 caracter especial (@ ! & * ...)")
                .Must(RequireDuplicateValidation).WithMessage(" Ops, caracter repetido");
        }

        private bool RequireDigitValidation(string password)
        {
            if (password.Any(x => char.IsDigit(x)))
                return true;
            
            return false;
        }

        private bool RequiredLowerCaseValidation(string password)
        {
            if (password.Any(x => char.IsLower(x)))
                return true;
            
            return false;
        }

        private bool RequireUppercaseValidation(string password)
        {
            if (password.Any(x => char.IsUpper(x)))
                return true;
            
            return false;
        }

        private bool RequireNonAlphanumericValidation(string password)
        {

            if (Regex.IsMatch(password, "(?=.*[!@#$%^&*()-+])"))
                return true;

            return false;
        }

        private bool RequireDuplicateValidation(string password)
        {
            bool duplicatecharacter = false;

            if (password != string.Empty)
            {
                for (int currentletterindex = 0; currentletterindex < password.Length; currentletterindex++)
                {
                    if (currentletterindex < password.Length - 1)
                    {
                        var currentletter = password.Substring(currentletterindex, 1);

                        if (password.IndexOf(currentletter, currentletterindex + 1) > -1)
                        {
                            duplicatecharacter = true;
                            break;
                        }
                    }
                }
            }

            return !duplicatecharacter;
        }
    }
}
