using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using TourManager.Data.Core.Domain;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Mapping.ModelsToDto
{
    public static class EmailsMapper
    {
        
        public static Email ToEntity(this EmailModel emailModel, Email email)
        {
            if (emailModel != null)
            {
                email.ContactId = emailModel.ContactId;
                email.EmailAddress = emailModel.EmailAddress;
                email.VenueId = emailModel.VenueId;
                email.BandId = emailModel.BandId;
                return email;
            }

            return null;
        }
        
        
        public static Email ToEntity(this EmailModel emailModel)
        {
            if (emailModel != null)
            {
                return new Email
                {
                    Id =  emailModel.Id,
                    ContactId =  emailModel.ContactId,
                    EmailAddress =  emailModel.EmailAddress,
                    VenueId =  emailModel.VenueId,
                    BandId =  emailModel.BandId,
                };
            }

            return null;
        }
        
        public static EmailModel ToDto(this Email emailEntity)
        {
            if (emailEntity != null)
            {
                return new EmailModel
                {
                    Id =  emailEntity.Id,
                    ContactId =  emailEntity.ContactId,
                    EmailAddress =  emailEntity.EmailAddress,
                    VenueId =  emailEntity.VenueId,
                    BandId =  emailEntity.BandId,
                };
            }

            return null;
        }

        public static IEnumerable<Email> ToEntity(this IEnumerable<EmailModel> emailModel)
        {
            return emailModel.Select(x => x.ToEntity());
        }

        public static IEnumerable<Email> ToEntity(this IEnumerable<EmailModel> dtos, IEnumerable<Email> entities)
        {
            var joinedLists= (from m in dtos 
                                    join r in entities on m.Id equals r.Id into merged
                                    from r in merged.DefaultIfEmpty()
                                    select new { m , r });
            
            var update = joinedLists.Where(x => x.r != null).Select(x => x.m.ToEntity(x.r));
            var add = joinedLists.Where(x => x.r == null).Select(x => x.m.ToEntity());
            var rEmails= update.ToList();
             rEmails.AddRange(add);
             return rEmails;


        }

        public static IEnumerable<EmailModel> ToDto(this IEnumerable<Email> emailEntity)
        {
            return emailEntity.Select(x => x.ToDto());
        }
    }
}