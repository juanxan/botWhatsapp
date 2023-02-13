using GT.Transversal.Entities;
using System.ComponentModel.DataAnnotations;

namespace botWhatsapp.Entities
{
    public class User  : IdentityBase<Int32>
    {
        #region Attributes
        [Required, MaxLength(13)]
        public String Phone { get; set; } = default!;
        public String Name { get; set; }
        public Boolean State { get; set; }
        #endregion
        #region Relations
        public virtual ISet<Conversation> Conversations { get; set; } = new HashSet<Conversation>();
        #endregion
    }
}
