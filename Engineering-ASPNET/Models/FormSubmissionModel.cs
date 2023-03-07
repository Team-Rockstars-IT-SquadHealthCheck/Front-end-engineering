namespace Engineering_ASPNET.Models;

public class FormSubmissionModel
{
    public enum Grading
    {
        Good,
        Ok,
        Bad
    }

    public Grading Question1 { get; set; }
    public Grading Question2 { get; set; }
    public Grading Question3 { get; set; }
    public Grading Question4 { get; set; }
    public Grading Question5 { get; set; }
    public Grading Question6 { get; set; }
    public Grading Question7 { get; set; }
    public Grading Question8 { get; set; }
    //Link? Id?
    public string Guid { get; set; } = "";
    
    
}