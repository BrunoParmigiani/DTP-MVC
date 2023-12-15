namespace DTP.Models.ViewModels
{
    public class RDMsViewModel
    {
        public ICollection<ParentRDM> ParentRDMs { get; set; }
        public ICollection<ChildrenRDM> ChildrenRDMs { get; set; }
    }
}
