using System.ComponentModel.DataAnnotations;

namespace botWhatsapp.Common.TransferObjects
{
    public class MessageSave 
    {
        #region Attributes
        public String Type { get; set; }
        public String Reponse { get; set; }
        public Boolean State { get; set; }
        #endregion
        #region Relations
        public Int32 ResponseId { get; set; }
        #endregion

    }
}
