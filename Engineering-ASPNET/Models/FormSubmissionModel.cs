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

    public List<int> Answers { get; set; }
    public List<Question> questions { get; set; } 

    //Link? Id?
    public string Guid { get; set; } = "";

}