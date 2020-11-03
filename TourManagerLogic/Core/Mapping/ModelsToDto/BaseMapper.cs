using System.Collections.Generic;
using System.Linq;
using TourManager.Data.Core.Domain;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Mapping.ModelsToDto
{
    public class BaseMapper
    {
        public static IEnumerable<TEntity> ToEntity(IEnumerable<BaseModel> dtos, IEnumerable<TEntity> entities)
        {
            return (IEnumerable<TEntity>)(from m in dtos
                join r in entities on m.Id equals r.Id
                select new {m, r}).ToList(); //.Select(x=>x.m.ToEntity(x.r));
        }
    }
}