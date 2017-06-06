namespace BLL.Interface.Entities
{
    public class ProfileEntity
    {
        public int Id { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
