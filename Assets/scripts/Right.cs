using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Right : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI option1;
    public TextMeshProUGUI option2;
    public TextMeshProUGUI option3;
    public TextMeshProUGUI option4;
    private TMP_Text[] options;



    /* Moves right through the choices
     * 
     * @param: None
     * 
     * @return: None
     * 
     */
    public void MoveRight()
    {
        //moves right
        canvas.GetComponent<QuestionsController>().bolded += 1;

        //ensures we dont go over and outside array
        if (canvas.GetComponent<QuestionsController>().bolded > 4) { canvas.GetComponent<QuestionsController>().bolded = 1; }

        options = new TMP_Text[] { option1, option2, option3, option4 };

        //minus 1 since arrays start at 0
        int index = canvas.GetComponent<QuestionsController>().bolded - 1;


        options[index].fontStyle = FontStyles.Bold;
        //gets previous one
        options[(index + 3) % 4].fontStyle = FontStyles.Normal;
        
    }
}
