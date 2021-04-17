using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDBContext context;
        public EFTextFieldsRepository(AppDBContext context) => this.context = context;
        public IQueryable<TextField> GetTextFields() => context.TextFields;
        public TextField GetTextFieldById(Guid id) => context.TextFields.FirstOrDefault(x => x.Id == id);
        public TextField GetTextFieldByCodeWord(string codeWord) => context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        public void SafeTextField(TextField entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteTextField(Guid id)
        {
            context.TextFields.Remove(new TextField() { Id = id });
            context.SaveChanges();
        }
    }
}
