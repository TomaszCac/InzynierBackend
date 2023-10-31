using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface ICustomRaceFeatureRepository
    {
        public ICollection<CustomRaceFeature> GetCustomRaceFeatures();
        public ICollection<CustomRaceFeature> GetCustomRaceFeature(int raceId);
        public bool Save();
        public bool CreateCustomRaceFeature(int raceId, CustomRaceFeature customRaceFeature);
        public bool UpdateCustomRaceFeature(CustomRaceFeature customRaceFeature);
        public bool DeleteCustomRaceFeature(CustomRaceFeature customRaceFeature);
    }
}
