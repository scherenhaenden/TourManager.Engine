using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TourManager.Data.Core.Domain;
using TourManager.Data.Persistence;
using TourManagerLogic.Core.Mapping.ModelsToDto;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Api
{
    public class EmailApi
    {
        private readonly IUnityOfWork _unityOfWork;

        public EmailApi(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public void Add(EmailModel values)
        {   
            _unityOfWork.Emails.Add(values.ToEntity());
            _unityOfWork.Complete();
        }
        
        public List<EmailModel> Find(Expression<Func<Email, bool>> predicate)
        {
            var entity = _unityOfWork.Emails.Find(predicate);
            if (entity == null)
            {
                return null;
            }

            return entity.ToDto().ToList();
        }
        
        public EmailModel SelectBy(int id)
        {
            var entity = _unityOfWork.Emails.GetById(id);
            if (entity == null)
            {
                return null;
            }

            return entity.ToDto();
        }
        
        
        public void Update(EmailModel values)
        {
            var current= _unityOfWork.Emails.GetById(values.Id);
            current = values.ToEntity(current);
            _unityOfWork.Emails.Update(current);
            _unityOfWork.Complete();
        }
        
        
        public void Remove(EmailModel emailModel)
        {
            var current= _unityOfWork.Emails.GetById(emailModel.Id);
            current = emailModel.ToEntity(current);
             _unityOfWork.Emails.Remove(current);
            _unityOfWork.Complete();
        }
    }
}