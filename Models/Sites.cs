namespace DTP.Models
{
    public class Sites
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }

        public Sites()
        {
        }

        public Sites(int id, string name, string image, string link)
        {
            Id = id;
            Name = name;
            Image = image;
            Link = link;
        }
    }
}
