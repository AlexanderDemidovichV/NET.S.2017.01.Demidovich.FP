namespace ORM.Entities
{
    public class Profile
    {
        public int Id { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        public virtual User User { get; set; }
    }
}
