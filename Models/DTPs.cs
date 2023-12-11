using System.ComponentModel.DataAnnotations;

namespace DTP.Models
{
    public class DTPs
    {
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string DM { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Analyst { get; set; }
        public string? Leader { get; set; }
        public string? Demandant { get; set; }

        public DTPs()
        {
        }

        public DTPs(int id, string number, string dm, string name)
        {
            Id = id;
            Number = number;
            DM = dm;
            Name = name;
        }

        public string GetProjectPageLink()
        {
            return $"https://dataprevrj.sharepoint.com/sites/DIPD/SitePages/DTP.{Number}.aspx";
        }

        public string GetFullName()
        {
            return $"DM.{DM} - {Name}";
        }
    }
}