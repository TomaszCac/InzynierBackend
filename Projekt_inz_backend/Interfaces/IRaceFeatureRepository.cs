using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IRaceFeatureRepository
    {
        public ICollection<RaceFeature> GetRaceFeatures();
        public RaceFeature GetRaceFeature(int id);
    }
}
