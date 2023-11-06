namespace Projekt_inz_backend.Dto
{
    public class DndClassDto
    {
        public int? classID { get; set; }
        public string className { get; set; }
        public string[] tableHeader { get; set; }
        public string[,] tableData { get; set; }
        public int? inheritedClassID { get; set; }
    }
}
