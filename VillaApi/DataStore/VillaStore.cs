using VillaApi.Models.Dto;

namespace VillaApi.DataStore
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList= 
            new List<VillaDto> { 
                new VillaDto { Id= 1, Name = "Beach Side Villa"},
                new VillaDto { Id= 2, Name = "Pool Villa"}};
        public static IEnumerable<VillaDto> GetVillas()
        {
            return villaList;
        }

    }
}
