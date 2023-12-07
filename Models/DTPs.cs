namespace DTP.Models
{
    public class DTPs
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string DM { get; set; }
        public string Name { get; set; }

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
    }
}