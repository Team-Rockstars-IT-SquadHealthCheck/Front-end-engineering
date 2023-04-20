namespace Engineering_ASPNET.Models
{
    public class SurveyModel
    {
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public int Answer { get; set; }
        public string Comment { get; set; } = "";
    }
}
