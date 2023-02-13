using botWhatsapp.Common.Enums;
using GT.Transversal.Objects;

namespace botWhatsapp
{
    /// <summary>Set of application utilities.</summary>
    public static class ApplicationUtilities
    {
        /// <summary>Creates a <see cref="BusinessInitializer{BotWhatsappError}"/> instance.</summary>
        /// <param name="applicationCode">Application code.</param>
        /// <returns>A new <see cref="BusinessInitializer{BotWhatsappError}"/> instance.</returns>
        public static BusinessInitializer<BotWhatsappError> GetInitializer(Byte applicationCode)
        => new()
        {
            ApplicationCode = applicationCode,
            InvalidEnumerationInput = BotWhatsappError.NullParameter,
            InvalidEnumerationOutput = BotWhatsappError.NullParameter,
            InvalidInput = BotWhatsappError.NullParameter,
            InvalidOutput = BotWhatsappError.NullParameter,
            UnknownException = BotWhatsappError.NullParameter
        };
    }
}
