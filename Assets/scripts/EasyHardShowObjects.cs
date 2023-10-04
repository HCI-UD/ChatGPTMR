using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyHardShowObjects : MonoBehaviour
{

    public GameObject easy;
    public GameObject hard;
    public GameObject record;
    public GameObject select;
    public GameObject left;
    public GameObject right;
    public GameObject canvas;
    

    /*
     * Used to hide the easy and hard buttons, while activating the record, select, left, right buttons
     * 
     * @param: None
     * 
     * @return: None
     * 
     */
    public void hideObjects()
    {
        easy.SetActive(false); //hide easy
        hard.SetActive(false); //hide hard
        record.SetActive(true); //show record
        select.SetActive(true); //show select
        left.SetActive(true); //show left
        right.SetActive(true); //show right


        //If easy == true, shows easy questions
        if (canvas.GetComponent<QuestionsController>().Easy)
        {
            canvas.GetComponent<QuestionsController>().Q1();
        }
        else
        {
            canvas.GetComponent<QuestionsController>().Q3();
        }
    }
}
