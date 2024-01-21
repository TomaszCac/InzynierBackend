using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface ICharacterRepository
    {
        public ICollection<(int?, int?, Character)> GetAllCharacters();
        public (int?, int?, Character) GetCharacter(int characterId);
        public ICollection<(int?, int?, Character)> GetCharactersByOwner(int ownerid);
        public bool Save();
        public bool UpdateCharacter((int? RaceId, int? DndClassId, Character character) items);
        public bool CreateCharacter(int ownerId,(int? RaceId, int? DndClassId, Character character) items);
        public bool DeleteCharacter((int? RaceId, int? DndClassId, Character character) items);
        public int GetOwnerId(int characterId);
        public int GetUserIdByName(string username);


    }
}
