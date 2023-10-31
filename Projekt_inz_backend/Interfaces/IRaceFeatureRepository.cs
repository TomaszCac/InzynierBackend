using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IRaceFeatureRepository
    {
        public ICollection<RaceFeature> GetRaceFeatures();
        public RaceFeature GetRaceFeature(int raceId);
        public bool CreateRaceFeature(int raceId, RaceFeature raceFeature);
        public bool DeleteRaceFeature(RaceFeature raceFeature);
        public bool UpdateRaceFeature(RaceFeature raceFeature);
        public bool Save();
    }
}
