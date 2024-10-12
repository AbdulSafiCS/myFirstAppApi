using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace myFirstAppApi.DTO
{
    public class CityDTO
    {
        
        public int Id { get; set; }

       
        [Unicode(false)]
        public string Name { get; set; } = null!;

        
        public decimal Lat { get; set; }

       
        public decimal Lng { get; set; }

        public int Population { get; set; }
        public required string CountryName { get; set; }
    }
}
