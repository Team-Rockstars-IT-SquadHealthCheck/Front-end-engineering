using Engineering_ASPNET.DAL;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Engineering_ASPNET.Models;

public enum Grading
{
    Good,
    Ok,
    Bad
}
public class FormSubmissionModel
{

    public List<int> Answers { get; set; } = new List<int>();
    public List<Question> questions { get; set; } = new List<Question>();


    [Required]
    public int? Question1 { get; set; }
    [Required]
    public int? Question2 { get; set; }
    [Required]
    public int? Question3 { get; set; }
    [Required]
    public int? Question4 { get; set; }
    [Required]
    public int? Question5 { get; set; }
    [Required]
    public int? Question6 { get; set; }
    [Required]
    public int? Question7 { get; set; }
    [Required]
    public int? Question8 { get; set; }
    //Link? Id?
    public string Guid { get; set; } = "";

}