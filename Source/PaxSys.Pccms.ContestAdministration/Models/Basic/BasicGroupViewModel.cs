namespace PaxSys.Pccms.ContestAdministration.Models.Basic
{
    public class BasicGroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Locale { get; set; }

        public int GroupScore { get; set; }
    }
}