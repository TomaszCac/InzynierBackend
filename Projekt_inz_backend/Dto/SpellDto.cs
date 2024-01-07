namespace Projekt_inz_backend.Dto
{
    public class SpellDto
    {
        public int? spellId { get; set; }
        public string spellName { get; set; }
        public string spellSchool { get; set; }
        public string spellCasting { get; set; }
        public string spellRange { get; set; }
        public string spellDuration { get; set; }
        public string spellComponents { get; set; }
        public int spellLevel { get; set; }
        public string spellDesc { get; set; }
        public string spellAHL { get; set; }
        public string ownerName { get; set; }
        public int? upvotes { get; set; }
    }
}
