using botWhatsapp.Common.TransferObjects;
using botWhatsapp.DataAccess.Abstractions.Entities;
using botWhatsapp.Entities;
using GT.Transversal.AutoMapper;

namespace GT.Customer
{
    /// <summary>Customer mapper profile (DTO -> Entity).</summary>
    /// <summary>Administrator mapper profile (DTO -> Entity).</summary>
    public class botWhatsappAppProfile : ProfileBase
    {
        /// <summary>Ctor.</summary>
        /// <summary>Parameterless constructor.</summary>
        public botWhatsappAppProfile()
        {
            this.MapMessage();
            this.MapOption();
            this.MapResponse();
            this.MapUser();
            this.MapOptionResponse();
        }
        public void MapMessage()
        {
            CreateMap<MessageSave, Message>().ReverseMap();
        }
        public void MapOption()
        {
            CreateMap<OptionSave, Option>().ReverseMap();
            CreateMap<OptionList, Option>().ReverseMap();
        }
        public void MapResponse()
        {
            CreateMap<ResponseSave, Response>().ReverseMap();
            CreateMap<ResponseList, Response>().ReverseMap();
        }

        public void MapUser()
        {
            CreateMap<UserSave, User>().ReverseMap();
            CreateMap<UserList, User>().ReverseMap();
        }
        public void MapOptionResponse()
        {
            CreateMap<OptionResponseList, OptionResponse>().ReverseMap();
            CreateMap<OptionResponseAdd, OptionResponse>().ReverseMap();
        }
    }
}
