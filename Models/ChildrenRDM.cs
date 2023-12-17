using DTP.Models.Enums;

namespace DTP.Models
{
    public class ChildrenRDM : RDM
    {
        public ParentRDM? Parent { get; set; }

        public ChildrenRDM()
        {
        }

        public ChildrenRDM(int id, int? number, string user, string requester, RDMEnvironment environment, string category, RDMType type, string system, bool unavailable, DTPs ticket, string summary, string description, DateTime requiredTo, ParentRDM? parent)
            : base(id, number, user, requester, environment, category, type, system, unavailable, ticket, summary, description, requiredTo)
        {
            Parent = parent;
        }
    }
}
