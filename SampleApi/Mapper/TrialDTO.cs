using SampleApi.Models;
using static SampleApi.Models.Trail;

namespace SampleApi.Mapper
{
    public class TrialDTO
    {
        public int Id { get; set; }
       
        public string? Name { get; set; }

        public double Distance { get; set; }
        
        public DifficultyType Difficulty { get; set; }
       
        public int NationalParkId { get; set; }
       
        public NationalPark? NationalPark { get; set; }
    }
}
