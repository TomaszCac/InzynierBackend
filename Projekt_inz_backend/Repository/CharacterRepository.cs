using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly DndDatabaseContext _context;

        public CharacterRepository(DndDatabaseContext context)
        {
            _context = context;
        }
        public bool CreateCharacter(int ownerId,(int? RaceId, int? DndClassId, Character character) items)
        {
            Race race = _context.Races.Where(b => b.raceId == items.RaceId).FirstOrDefault();
            DndClass dndClass = _context.dndClasses.Where(b => b.classId == items.DndClassId).FirstOrDefault();
            User user = _context.Users.Where(b => b.userID == ownerId).FirstOrDefault();
            items.character.race = race;
            items.character.DndClass = dndClass;
            items.character.owner = user;
            _context.characters.Add(items.character);
            return Save();
        }

        public bool DeleteCharacter((int? RaceId, int? DndClassId, Character character) items)
        {
            _context.characters.Remove(items.character);
            return Save();
        }

        public bool UpdateCharacter((int? RaceId, int? DndClassId, Character character) items)
        {
            Race race = _context.Races.Where(b => b.raceId == items.RaceId).FirstOrDefault();
            DndClass dndClass = _context.dndClasses.Where(b => b.classId == items.DndClassId).FirstOrDefault();
            items.character.race = race;
            items.character.DndClass = dndClass;
            _context.characters.Update(items.character);
            return Save();
        }

        public ICollection<(int?, int?, Character)> GetAllCharacters()
        {
            List<(int?, int?, Character)> collection = new();
            var characters = _context.characters.OrderBy(b => b.characterId).ToList();
            Race tempRace = null;
            DndClass tempDndClass = null;
            foreach (var character in characters)
            {

                tempRace = _context.characters.Where(b => b.characterId == character.characterId).Select(b => b.race).FirstOrDefault();
                tempDndClass = _context.characters.Where(b => b.characterId == character.characterId).Select(b => b.DndClass).FirstOrDefault();
                
                collection.Add((tempRace == null ? null : tempRace.raceId, tempDndClass == null ? null : tempDndClass.classId, character));
            }
            return collection;
        }

        public (int?, int?, Character) GetCharacter(int characterId)
        {
            var character = _context.characters.Where(b => b.characterId == characterId).FirstOrDefault();
            Race tempRace = _context.characters.Where(b => b.characterId == characterId).Select(b => b.race).FirstOrDefault();
            DndClass tempDndClass = _context.characters.Where(b => b.characterId == characterId).Select(b => b.DndClass).FirstOrDefault();
            return (tempRace?.raceId, tempDndClass?.classId, character);
        }

        public ICollection<(int?, int?, Character)> GetCharactersByOwner(int ownerid)
        {
            List<(int?, int?, Character)> collection = new();
            var characters = _context.characters.Where(b => b.owner.userID == ownerid).ToList();
            Race tempRace = null;
            DndClass tempDndClass = null;
            foreach (var character in characters)
            {
                tempRace = _context.characters.Where(b => b.characterId == character.characterId).Select(b => b.race).FirstOrDefault();
                tempDndClass = _context.characters.Where(b => b.characterId == character.characterId).Select(b => b.DndClass).FirstOrDefault();
                collection.Add((tempRace?.raceId, tempDndClass?.classId, character));
            }
            return collection;
        }
        public int GetOwnerId(int characterId)
        {
            return _context.characters.Where(b => b.characterId == characterId).Select(b => b.owner.userID).FirstOrDefault();
        }
        public int GetUserIdByName(string username)
        {
            return _context.Users.Where(b => b.username == username).Select(b => b.userID).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
