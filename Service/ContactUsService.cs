using BackendApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Services
{
    public class ContactUsService : IContactUsService
    {
        private readonly DataBaseContext _context;

        public ContactUsService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ContactRequest> CreateAsync(ContactRequest contactMail)
        {
            if (contactMail == null) throw new ArgumentNullException(nameof(contactMail));

            var data = new ContactModel
            {
                Email = contactMail.Email,
                FullName = contactMail.FullName,
                Message = contactMail.Message,
                Subject = contactMail.Subject
            };

            await _context.ContactsUs.AddAsync(data);
            await _context.SaveChangesAsync();

            return new ContactRequest
            {
                Email = data.Email,
                FullName = data.FullName,
                Subject = data.Subject,
                Message = data.Message
            };
        }

        public async Task<ContactModel?> DeleteByIdAsync(Guid id)
        {
            var data = await _context.ContactsUs.FindAsync(id);
            if (data == null) return null;

            _context.ContactsUs.Remove(data);
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<List<ContactModel>> GetAllAsync()
        {
            return await _context.ContactsUs.ToListAsync();
        }

        public async Task<ContactModel?> GetByIdAsync(Guid id)
        {
            return await _context.ContactsUs.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ContactModel?> UpdateAsync(Guid id, ContactModel updatedContact)
        {
            if (updatedContact == null) throw new ArgumentNullException(nameof(updatedContact));

            var existingContact = await _context.ContactsUs.FindAsync(id);
            if (existingContact == null) return null;

            existingContact.Email = updatedContact.Email;
            existingContact.FullName = updatedContact.FullName;
            existingContact.Message = updatedContact.Message;
            existingContact.Subject = updatedContact.Subject;

            _context.ContactsUs.Update(existingContact);
            await _context.SaveChangesAsync();

            return existingContact;
        }
    }

    public interface IContactUsService
    {
        Task<List<ContactModel>> GetAllAsync();
        Task<ContactModel?> GetByIdAsync(Guid id);
        Task<ContactModel?> DeleteByIdAsync(Guid id);
        Task<ContactRequest> CreateAsync(ContactRequest contactMail);
        Task<ContactModel?> UpdateAsync(Guid id, ContactModel updatedContact);
    }


}
