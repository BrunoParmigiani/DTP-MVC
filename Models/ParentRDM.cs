using DTP.Models;
using DTP.Models.Enums;

namespace DTP.Models
{
    public class ParentRDM : RDM
    {
        public List<ChildrenRDM> Children { get; set; } = new List<ChildrenRDM>();

        public ParentRDM()
        {
        }

        public ParentRDM(int id, int? number, string user, string requester, RDMEnvironment environment, string category, RDMType type, string system, bool unavailable, DTPs ticket, string summary, string description, DateTime requiredTo)
            : base(id, number, user, requester, environment, category, type, system, unavailable, ticket, summary, description, requiredTo)
        {
        }

        public void AddChild(ChildrenRDM child)
        {
            Children.Add(child);
        }

        public void RemoveChild(ChildrenRDM child)
        {
            Children.Remove(child);
        }
    }
}
