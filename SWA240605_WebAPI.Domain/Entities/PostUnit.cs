namespace SWA240605_WebAPI.Domain.Entities
{
    public class PostUnit
    {
        public string? Code { get; set; } 
        public string? Title { get; set; } 
        public int StartingApplicationNo { get; set; }
        public int CurrentApplicationNo { get; set; }
        public int EndApplicationNo { get; set; }
        public string? PostCode { get; set; } 
        public int OrderIndex { get; set; }
        public int Vacancy { get; set; }
        //
        //Child entity
        //
        public Applicant? Applicants { get; set; }
        //
        //Parent entity
        //
        public Post? Posts { get; set; }
    }
}
