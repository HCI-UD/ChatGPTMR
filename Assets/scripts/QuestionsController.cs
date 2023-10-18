using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionsController : MonoBehaviour
{
    public bool Easy = false;
    
    public TextMeshProUGUI question;
    public TextMeshProUGUI option1;
    public TextMeshProUGUI option2;
    public TextMeshProUGUI option3;
    public TextMeshProUGUI option4;

    public GameObject ResetButt;
    public GameObject LeftButt;
    public GameObject RightButt;
    public GameObject RecordButt;
    public GameObject SelectButt;
    public GameObject ExitButt;

    public Tracking tracker;
    
    public int bolded;
    


    /*
     * Every question has its own function, with all having essentially the same functionality, could be improved
     * 
     * param(s): None
     * 
     * return(s): None
     * 
     */
    public void Q1()
    {
        //Begins tracking the time for spreadsheet
        tracker.StartTime();
        tracker.numInteractions = 0;

        //first choice is bolded
        bolded = 1;
        question.fontSize = 40;


        question.text = "A 50-year-old male presents with difficulty breathing and chest pain. Imaging reveals an occlusion of the left anterior descending(LAD) coronary artery. Which of the following areas of the heart is most likely affected by the occlusion?";
        option1.text = "(a) left atrium";
        option1.fontStyle = FontStyles.Bold;
        option2.text = "(b) right atrium";
        option3.text = "(c) left ventricle";
        option4.text = "(d) right ventricle";
    }
    public void Q2()
    {
        tracker.StartTime();
        tracker.numInteractions = 0;

        question.fontSize = 51;


        question.text = "A patient presents with a stabbing pain in their left chest, radiating to their left arm. Which of the following anatomical structures is most likely affected?";
        option1.text = "(a) left lung";
        option2.text = "(b) left ventricle of the heart";
        option3.text = "(c) spleen";
        option4.text = "(d) left kidney";
        
    }
    public void Q3()
    {
        tracker.StartTime();
        tracker.numInteractions = 0;

        bolded = 1;
        question.fontSize = 27;


        question.text = "A patient presents with a sharp pain in the right upper quadrant of their abdomen, which radiates to the right shoulder. They report feeling nauseous and have a low-grade fever. Other symptoms may include nausea, vomiting, and fever. The liver is located in the upper right side of the abdomen and produces bile, which is stored in the gallbladder. The pancreas is located behind the stomach and produces digestive enzymes and hormones, while the stomach is located in the upper left side of the abdomen and is responsible for digesting food. Which of the following structures is most likely affected?";
        option1.text = "(a) gallbladder";
        option1.fontStyle = FontStyles.Bold;
        option2.text = "(b) liver";
        option3.text = "(c) pancreas";
        option4.text = "(d) stomach";
    }
    public void Q4()
    {
        tracker.StartTime();
        tracker.numInteractions = 0;


        question.fontSize = 35;


        question.text = "A patient presents with weakness and tingling in their hands and feet, along with difficulty maintaining balance. On physical examination, they have decreased reflexes and muscle weakness, tingling, and numbness in the hands and feet, as well as difficulty maintaining balance. Which of the following structures is most likely affected?";
        option1.text = "(a) brainstem";
        option2.text = "(b) frontal lobe";
        option3.text = "(c) spinal cord";
        option4.text = "(d) peripheral nerves";
        
    }
    /*
     * When the program is through all necessary questions, it must reset the board/deactivate all buttons
     * 
     * @param: None
     * 
     * @return: None
     * 
     */
    public void Finish()
    {
        question.fontSize = 69;
        question.text = "Thank you for your participation.";
        option1.text = "";
        option2.text = "";
        option3.text = "";
        option4.text = "";

        ResetButt.SetActive(true); //show reset
        ExitButt.SetActive(true); //show exit
        LeftButt.SetActive(false); //hide left
        RightButt.SetActive(false); //hide right
        SelectButt.SetActive(false); //hide select
        RecordButt.SetActive(false); //hide record
        

        //make first = false for next set of questions (first tells us if its the first question or not)
        SelectButt.GetComponent<Select>().first = false;
        Easy = false;
    }
}
