using System.Collections.Generic;
using System.Linq;
using TourManager.Data.Core.Domain;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Mapping.ModelsToDto
{   
    //TODO:  try to create a basemapper for all the dtos and entities
    public static class BaseMapper   
    {
        public static IEnumerable<object> JoinLists(IEnumerable<BaseModel> dtos, IEnumerable<TEntity> entities)
        {
            var joinedLists= (from m in dtos 
                join r in entities on m.Id equals r.Id into merged
                from r in merged.DefaultIfEmpty()
                select new { m , r });//.Select(x=>x.m.ToEntity(x.r) {m,r});
            return joinedLists;
        }
    }
}