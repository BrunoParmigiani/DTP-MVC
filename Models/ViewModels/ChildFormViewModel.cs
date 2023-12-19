namespace DTP.Models.ViewModels
{
    public class ChildFormViewModel
    {
        public int DTPId { get; set; }
        public int ParentId { get; set; }
        public ChildrenRDM Child { get; set; }
    }
}
