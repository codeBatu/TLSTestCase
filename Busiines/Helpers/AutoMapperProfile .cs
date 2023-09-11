using AutoMapper;
using Model.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTO.Account;

namespace Busiines.Helpers
{
 // Veriler Mapler 
        
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Users, UserDTO>();
            CreateMap<Document, DocumentDTO>();

            CreateMap<UserDTO, Users>();
            CreateMap<DocumentDTO, Document>();
            CreateMap<DocumentDTO, DocumentDTO>();
            CreateMap<UserDTO, Users>();
            CreateMap<Users, UserDTO>();

            CreateMap<Users, AuthenticateResponse>();

            CreateMap<Users, AuthenticateRequest>();

        }
        }
}
