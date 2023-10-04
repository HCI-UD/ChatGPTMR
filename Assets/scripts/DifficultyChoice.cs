using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyChoice : MonoBehaviour
{
    public Canvas canvas;

    /*
     * Chooses the difficulty option, only attached to the Easy Button
     * 
     * @param: none
     * 
     * @return: none
     * 
     */
    public void choose()
    {
        canvas.GetComponent<QuestionsController>().Easy = true;
    }
}
