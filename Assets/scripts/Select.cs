using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Select : MonoBehaviour
{
    public Canvas canvas;
    private bool easy;
    public bool first;
    public Tracking tracker;
    public TextMeshProUGUI option1;
    public TextMeshProUGUI option2;
    public TextMeshProUGUI option3;
    public TextMeshProUGUI option4;
    private TMP_Text[] options;



    /*
     * Handles when a user 'selects' their answer
     * Also moves to the next question
     * 
     * @param: None
     * 
     * @return: None
     * 
     */
    public void SelectQ()
    {
        options = new TMP_Text[] { option1, option2, option3, option4 };
        var canvasComp = canvas.GetComponent<QuestionsController>();
        easy = canvasComp.Easy;
        checkAnswer(); //Checks to see if the user is correct

        //if Easy (easy questions) and !first (the first question), then this is Q1
        if(easy && !first) //Q1
        {
            Debug.Log($"User selected: {options[canvasComp.bolded - 1].text}");
            canvasComp.Q2(); //Calls second question
            first = true;
        }

        //if !easy (hard questions) and !first (the first question), then this is Q3
        else if (!easy && !first)
        {
            Debug.Log($"User selected: {options[canvasComp.bolded - 1].text}");
            canvasComp.Q4(); //Calls fourth question
            first = true;
        }

        //If first(on the second question) then close out the questionnaire
        else
        {
            Debug.Log($"User selected: {options[canvasComp.bolded - 1].text}");
            options[canvasComp.bolded-1].fontStyle = FontStyles.Normal; //normalize choices again
            canvasComp.Finish();
        }
    }


    /*
     * Checks to see if the inputed answer was correct, and logs them in the tracker, could be improved
     * 
     * @param: None
     * 
     * @return: None
     * 
     */
    private void checkAnswer()
    {
        options = new TMP_Text[] { option1, option2, option3, option4 };
        var canvasComp = canvas.GetComponent<QuestionsController>();

        if (easy && !first) //Q1
        {
            tracker.question = "Q1, Easy";
            tracker.option = options[canvasComp.bolded - 1].text; //Gets current (bolded) choice
            if (string.Equals(options[canvasComp.bolded - 1].text, "(c) left ventricle")) //correct answer
            {
                tracker.correct = true;
            }
            tracker.WriteLine(); //Logs in tracker
            tracker.correct = false;
        }

        else if (!easy && !first) //Q3
        {
            tracker.question = "Q3, Hard"; //Gets current (bolded) choice
            tracker.option = options[canvasComp.bolded - 1].text;
            if (string.Equals(options[canvasComp.bolded - 1].text, "(a) gallbladder")) //correct answer
            {
                tracker.correct = true;
            }
            tracker.WriteLine(); //Logs in tracker
            tracker.correct = false;
        }

        else if (easy && first) //Q2
        {
            tracker.question = "Q2, Easy";
            tracker.option = options[canvasComp.bolded - 1].text; //Gets current (bolded) choice
            if (string.Equals(options[canvasComp.bolded - 1].text, "(b) left ventricle of the heart")) //correct answer
            {
                tracker.correct = true;
            }
            tracker.WriteLine(); //Logs in tracker
            tracker.correct = false;
        }

        else //Q4
        {
            tracker.question = "Q4, Hard";
            tracker.option = options[canvasComp.bolded - 1].text; //Gets current (bolded) choice
            if (string.Equals(options[canvasComp.bolded - 1].text, "(d) peripheral nerves")) //correct answer
            {
                tracker.correct = true;
            }
            tracker.WriteLine(); //Logs in tracker
            tracker.correct = false;
        }
    }
}
