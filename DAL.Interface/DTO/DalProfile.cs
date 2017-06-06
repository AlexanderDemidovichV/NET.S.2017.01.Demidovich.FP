namespace DAL.Interface.DTO
{
    public class DalProfile: IEntity
    {
        public int Id { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
