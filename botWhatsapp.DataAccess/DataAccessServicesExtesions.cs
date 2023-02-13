

using botWhatsapp.Common.Enums;
using botWhatsapp.DataAccess.Abstractions.Interface;
using botWhatsapp.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace botWhatsapp.DataAccess
{
    public static class DataAccessServicesExtesions
    {
        public static IServiceCollection AddBotWhatsappDataAccess(this IServiceCollection services)
           => services.AddScoped<IMessageRepository, MessageRepository>()
                      .AddScoped<IOptionRepository, OptionRepository>()
                      .AddScoped<IResponseRepository, ResponseRepository>()
                      .AddScoped<IUserRepository, UserRepository>();
    }
}
