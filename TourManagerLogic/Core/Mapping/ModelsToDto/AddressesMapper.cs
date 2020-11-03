using System.Collections.Generic;
using System.Linq;
using TourManager.Data.Core.Domain;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Mapping.ModelsToDto
{
    public static class AddressesMapper
    {
        
        public static Address ToEntity(this AddressModel dto, Address address)
        {
            if (dto != null)
            {
                address.Country =  dto.Country;
                address.City =  dto.City;
                address.Street =  dto.Street;
                address.HouseNameOrNumber =  dto.HouseNameOrNumber;
                address.PostalZip =  dto.PostalZip;
                address.ExtranInfo =  dto.ExtranInfo;
                address.ContactId =  dto.ContactId;
                address.VenueId =  dto.VenueId;

                return address;

            }

            return null;
        }
        public static Address ToEntity(this AddressModel dto)
        {
            if (dto != null)
            {
                return new Address
                {
                    Id =  dto.Id,
                    Country =  dto.Country,
                    City =  dto.City,
                    Street =  dto.Street,
                    HouseNameOrNumber =  dto.HouseNameOrNumber,
                    PostalZip =  dto.PostalZip,
                    ExtranInfo =  dto.ExtranInfo,
                    
                    ContactId =  dto.ContactId,
                    VenueId =  dto.VenueId,
                };
            }

            return null;
        }
        
        public static AddressModel ToDto(this Address entity)
        {
            if (entity != null)
            {
                return new AddressModel
                {
                    Id =  entity.Id,
                    Country =  entity.Country,
                    City =  entity.City,
                    Street =  entity.Street,
                    HouseNameOrNumber =  entity.HouseNameOrNumber,
                    PostalZip =  entity.PostalZip,
                    ExtranInfo =  entity.ExtranInfo,
                    
                    ContactId =  entity.ContactId,
                    VenueId =  entity.VenueId,
                };
            }

            return null;
        }

        public static IEnumerable<Address> ToEntity(this IEnumerable<AddressModel> dtos, IEnumerable<Address> entities)
        {
           return (from m in dtos 
                join r in entities on m.Id equals r.Id 
                select new { m, r }).ToList().Select(x=>x.m.ToEntity(x.r));
        }
        
        public static IEnumerable<Address> ToEntity(this IEnumerable<AddressModel> dtos)
        {
            return dtos.Select(x => x.ToEntity());
        }
        
        public static IEnumerable<AddressModel> ToDto(this IEnumerable<Address> entity)
        {
            return entity.Select(x => x.ToDto());
        }
    }
}