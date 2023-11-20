namespace Projekt_inz_backend.Dto
{
    public class RaceDto
    {
        public int? raceId { get; set; }
        public string raceName { get; set; }
        public string[] raceTableHeader { get; set; }
        public string[,] raceTableData { get; set; }
        public int? inheritedRaceID { get; set; }
        public string raceAbilityScoreIncrease { get; set; }
        public string raceAge { get; set; }
        public string raceAlignment { get; set; }
        public string raceSize { get; set; }
        public string raceSpeed { get; set; }
        public string raceLanguages { get; set; }
        public string raceDescription { get; set; }
    }
}
