namespace Projekt_inz_backend.Dto
{
    public class RaceDto
    {
        public int? raceID { get; set; }
        public string raceName { get; set; }
        public string[,] tableData { get; set; }
        public int? inheritedRaceID { get; set; }
    }
}
