namespace DTP.Models.ViewModels
{
    public class ChildFormViewModel
    {
        public int DTPId { get; set; }
        public int ParentId { get; set; }
        public ChildrenRDM Child { get; set; }
        public int Environments { get; set; } = 9;
        public int RDMTypes { get; set; } = 3;
    }
}
