namespace SampleApi.Mapper
{
    public class NationalParkDTO
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? State { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? Established { get; set; }
    }
}
