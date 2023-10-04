using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Left : MonoBehaviour
{

    public Canvas canvas;
    public TextMeshProUGUI option1;
    public TextMeshProUGUI option2;
    public TextMeshProUGUI option3;
    public TextMeshProUGUI option4;
    private TMP_Text[] options;

    /* Moves left through the choices
     * 
     * @param: None
     * 
     * @return: None
     * 
     */
    public void MoveLeft()
    {
        
        int curr = canvas.GetComponent<QuestionsController>().bolded;
        canvas.GetComponent<QuestionsController>().bolded -= 1;

        //Ensures we don't go negative and out of bounds
        if (canvas.GetComponent<QuestionsController>().bolded < 1) { canvas.GetComponent<QuestionsController>().bolded = 4; }

        //Minus 1 since arrays start at 0, not 1, could be improved
        int index = canvas.GetComponent<QuestionsController>().bolded - 1;

        options = new TMP_Text[] { option1, option2, option3, option4 };
        options[index].fontStyle = FontStyles.Bold;

        //Essentially gets previous one
        options[curr-1].fontStyle = FontStyles.Normal;
    }
}
