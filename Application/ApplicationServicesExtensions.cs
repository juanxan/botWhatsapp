using AutoMapper;
using botWhatsapp.Application.Abstractions.Interface;
using botWhatsapp.Application.Business;
using botWhatsapp.Common.Enums;
using botWhatsapp.DataAccess.Abstractions.Interface;
using GT.Transversal.Objects;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace botWhatsapp.Application
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddBotWhatsappApplication(this IServiceCollection services, BusinessInitializer<BotWhatsappError> initializer)
            => services.AddSingleton(initializer)
            .AddScoped<IMessagesBusiness>(m => new MessagesBusiness(
                initializer,
                m.GetRequiredService<ILogger<MessagesBusiness>>(),
                m.GetRequiredService<IMessageRepository>(),
                m.GetRequiredService<IMapper>()
                ))
            .AddScoped<IOptionBusiness>(m => new OptionBusiness(
                initializer,
                m.GetRequiredService<ILogger<OptionBusiness>>(),
                m.GetRequiredService<IOptionRepository>(),
                m.GetRequiredService<IMapper>()
                ))
            .AddScoped<IResponseBusiness>(m => new ResponseBusiness(
                initializer,
                m.GetRequiredService<ILogger<ResponseBusiness>>(),
                m.GetRequiredService<IResponseRepository>(),
                m.GetRequiredService<IMapper>()
                ))
            .AddScoped<IUserBusiness>(m => new UserBusiness(
                initializer,
                m.GetRequiredService<ILogger<UserBusiness>>(),
                m.GetRequiredService<IUserRepository>(),
                m.GetRequiredService<IMapper>()
                ))
            .AddScoped<IOptionResponseBusiness>(m => new OptionResponseBusiness(
                initializer,
                m.GetRequiredService<ILogger<OptionResponseBusiness>>(),
                m.GetRequiredService<IOptionResponseRepository>(),
                m.GetRequiredService<IMapper>()
                ));
    }
}
