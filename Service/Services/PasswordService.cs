using Service.Contracts;
using Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PasswordService : IPasswordService
    {
        public async Task<List<string>> RegisterPassword(string input)
        {
            var resultList = new List<string>();
            var obj = new Password(input);
            var validation = new PasswordValidation();
            var resultValidation = validation.Validate(obj).Errors;

            foreach (var item in resultValidation)
                resultList.Add(item.ErrorMessage);
            
            if (resultList.Count > 0)
                return resultList;

            resultList.Add(" Sua Senha cumpre todos os requisitos ! ");
            return resultList;

        }
    }
}
