using DTP.Models.Enums;

namespace DTP.Models.ViewModels
{
    public class ParentFormViewModel
    {
        public int DTPId { get; set; }
        public ParentRDM Parent { get; set; }
        public int Environments { get; set; } = 9;
        public int RDMTypes { get; set; } = 3;
    }
}
