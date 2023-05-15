namespace Engineering_ASPNET.Models;

public class QuestionColorViewModel
{
    private string QuestionOnePrimairy { get; set; }
    private string QuestionOneSecundairy { get; set; }
    private string QuestionTwoPrimairy { get; set; }
    private string QuestionTwoSecundairy { get; set; }
    private string QuestionThreePrimairy { get; set; }
    private string QuestionThreeSecundairy { get; set; }
    private string QuestionFourPrimairy { get; set; }
    private string QuestionFourSecundairy { get; set; }
    private string QuestionFivePrimairy { get; set; }
    private string QuestionFiveSecundairy { get; set; }
    private string QuestionSixPrimairy { get; set; }
    private string QuestionSixSecundairy { get; set; }
    private string QuestionSevenPrimairy { get; set; }
    private string QuestionSevenSecundairy { get; set; }
    private string QuestionEightPrimairy { get; set; }
    private string QuestionEightSecundairy { get; set; }

    public QuestionColorViewModel(string questionOnePrimairy, string questionOneSecundairy, string questionTwoPrimairy,
        string questionTwoSecundairy, string questionThreePrimairy, string questionThreeSecundairy,
        string questionFourPrimairy, string questionFourSecundairy, string questionFivePrimairy,
        string questionFiveSecundairy, string questionSixPrimairy, string questionSixSecundairy,
        string questionSevenPrimairy, string questionSevenSecundairy, string questionEightPrimairy,
        string questionEightSecundairy)
    {
        this.QuestionOnePrimairy = questionOnePrimairy;
        this.QuestionOneSecundairy = questionOneSecundairy;
        this.QuestionTwoPrimairy = questionTwoPrimairy;
        this.QuestionTwoSecundairy = questionTwoSecundairy;
        this.QuestionThreePrimairy = questionThreePrimairy;
        this.QuestionThreeSecundairy = questionThreeSecundairy;
        this.QuestionFourPrimairy = questionFourPrimairy;
        this.QuestionFourSecundairy = questionFourSecundairy;
        this.QuestionFivePrimairy = questionFivePrimairy;
        this.QuestionFiveSecundairy = questionFiveSecundairy;
        this.QuestionSixPrimairy = questionSixPrimairy;
        this.QuestionSixSecundairy = questionSixSecundairy;
        this.QuestionSevenPrimairy = questionSevenPrimairy;
        this.QuestionSevenSecundairy = questionSevenSecundairy;
        this.QuestionEightPrimairy = questionEightPrimairy;
        this.QuestionEightSecundairy = questionEightSecundairy;
    }
}