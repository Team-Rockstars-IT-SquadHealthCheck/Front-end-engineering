using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
    [ValidateNever]
    public string Guid { get; set; } = "";

}