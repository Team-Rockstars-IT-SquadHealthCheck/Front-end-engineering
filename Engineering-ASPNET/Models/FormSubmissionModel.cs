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
    
    public List<string> questionTextColors { get; set; }
    public List<string> questionBackgroundColors { get; set; }


    //Link? Id?
    public string Guid { get; set; } = "";
    
    public string QuestionOnePrimairy { get; set; }
    public string QuestionOneSecundairy { get; set; }
    public string QuestionTwoPrimairy { get; set; }
    public string QuestionTwoSecundairy { get; set; }
    public string QuestionThreePrimairy { get; set; }
    public string QuestionThreeSecundairy { get; set; }
    public string QuestionFourPrimairy { get; set; }
    public string QuestionFourSecundairy { get; set; }
    public string QuestionFivePrimairy { get; set; }
    public string QuestionFiveSecundairy { get; set; }
    public string QuestionSixPrimairy { get; set; }
    public string QuestionSixSecundairy { get; set; }
    public string QuestionSevenPrimairy { get; set; }
    public string QuestionSevenSecundairy { get; set; }
    public string QuestionEightPrimairy { get; set; }
    public string QuestionEightSecundairy { get; set; }

}