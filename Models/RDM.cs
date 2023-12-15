using DTP.Models.Enums;

namespace DTP.Models
{
    public class RDM
    {
        public int Id { get; set; }
        public int? Number { private get; set; }
        public string User { get; set; }
        public string Requester { get; set; }
        public RDMEnvironment Environment { get; set; }
        public string Category { get; set; }
        public RDMType Type { get; set; }
        public string System { get; set; }
        public bool Unavailable { get; set; }
        public string Ticket { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public DateTime RequiredTo { get; set; }
        public DateTime? OpenDate { get; set; }

        public RDM()
        {
        }

        public RDM(int id, int? number, string user, string requester, RDMEnvironment environment, string category, RDMType type, string system, bool unavailable, string ticket, string summary, string description, DateTime requiredTo)
        {
            Id = id;
            Number = number;
            User = user;
            Requester = requester;
            Environment = environment;
            Category = category;
            Type = type;
            System = system;
            Unavailable = unavailable;
            Ticket = ticket;
            Summary = summary;
            Description = description;
            RequiredTo = requiredTo;

            OpenDate = DateTime.Now;
        }

        public int GetNumber()
        {
            if (Number == null)
            {
                return Id;
            }

            return Number.Value;
        }
    }
}
