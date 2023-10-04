using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Tracking : MonoBehaviour
{
    public string question;
    private float startTime;
    public string option;
    public bool correct;
    public string method;
    public int numInteractions;
    public List<string> GPTQuestions;
    public List<string> GPTResponses;


    public bool track;

    public string participantNum = "NULL";
    private string fileName;



    /*
     * On start, it will create a csv file titled 'participant_(participantNum).csv' if tracking is set to true. Placed in MRChatGPT/Participants/
     * 
     * @param: None
     * 
     * @return: None
     * 
     */
    private void Start()
    {
        if (track)
        {
            fileName = $"Participants/participant_{participantNum}.csv";
            using (StreamWriter writer = File.AppendText(fileName))
            {

                string Header = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", "Question", "Difficulty", "Time Spent", "Option Chose", "Correct?", "GPT Medium", "Number of Interactions", "GPT Question(s) (separated by ; '-' = comma)", "GPT Response(s)");
                writer.WriteLine(Header);
            }
        }
    }

    /*
     * Tracks starting time
     * 
     * @param: None
     * 
     * @return: None
     * 
     */
    public void StartTime()
    {
        startTime = Time.time;
    }

    /*
     * Writes all the stats into the csv file
     * 
     * @param: None
     * 
     * @return: None
     * 
     */
    public void WriteLine()
    {
        if (track)
        {
            string GPTQs = "";
            string GPTRs = "";
            for (int i = 0; i < GPTQuestions.Count; i++)
            {
                Debug.Log(GPTQuestions[i]);
                
                GPTQs += $"{GPTQuestions[i].Replace(",", "-")};";
                GPTRs += $"{GPTResponses[i].Replace(",", "-")};";
            }
            float Totaltime = Time.time - startTime;
            Debug.Log(GPTRs);
            using (StreamWriter writer = File.AppendText(fileName))
            {
                string stats = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", question, Totaltime, option, correct, method, numInteractions, GPTQs, GPTRs); 
                //Since question is formatted at "questionNum, Difficulty" (i.e., Q1, Easy) it takes up two excel spots
                writer.WriteLine(stats);
            }
        }
        GPTQuestions.Clear();
        GPTResponses.Clear();
    }
    
}
