using botWhatsapp.Entities;
using GT.Transversal.Entities;

namespace botWhatsapp.DataAccess.Abstractions.Entities
{
    public class OptionResponse : IdentityBase<Int32>
    {
        public  Int32 OptionId { get; set; }
        public virtual Option Option { get; protected set; } = default!;
        public Int32 MessageId { get; set; }
        public virtual Message Message { get; protected set; } = default!;
    }
}
