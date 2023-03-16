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
    [Required]
    public Grading? Question1 { get; set; }
    [Required]
    public Grading? Question2 { get; set; }
    [Required]
    public Grading? Question3 { get; set; }
    [Required]
    public Grading? Question4 { get; set; }
    [Required]
    public Grading? Question5 { get; set; }
    [Required]
    public Grading? Question6 { get; set; }
    [Required]
    public Grading? Question7 { get; set; }
    [Required]
    public Grading? Question8 { get; set; }
    //Link? Id?
    public string Guid { get; set; } = "";
    
    
}