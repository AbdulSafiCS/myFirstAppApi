using Microsoft.EntityFrameworkCore;

namespace myFirstAppApi.DTO
{
    public class CountryPopulation
    {
        public int Id { get; set; }


        [Unicode(false)]
        public string Name { get; set; } = null!;

        public int Population { get; set; }
    }
}
