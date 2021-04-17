using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    public interface ITextFieldsRepository
    {
        IQueryable<TextField> GetTextFields();
        TextField GetTextFieldById(Guid Id);
        TextField GetTextFieldByCodeWord(string codeWord);
        public void SafeTextField(TextField entity);
        void DeleteTextField(Guid Id);
    }
}
