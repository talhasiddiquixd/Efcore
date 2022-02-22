using static SampleApi.Models.Trail;

namespace SampleApi.Mapper
{
    public class TrailRequestDTO
    {
        

        public string? Name { get; set; }

        public double Distance { get; set; }

        public DifficultyType Difficulty { get; set; }

        public int NationalParkId { get; set; }

    }
}
