using OpenAI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MicrophoneSelect : MonoBehaviour
{
    public List<TMP_Text> options;
    public ChooseMicrophone controller;
    public Whisper STT;
    public MicrophoneLeft Left;
    public MicrophoneRight Right;
    public MicrophoneSelect Select;
    public GameObject board;
    public GameObject avatar;
    public GameObject both;
    public TextMeshProUGUI question;

    public void select()
    {
        int option = controller.GetComponent<ChooseMicrophone>().bolded;
        STT.microphone = option;
        Left.gameObject.SetActive(false);
        Right.gameObject.SetActive(false);
        Select.gameObject.SetActive(false);
        board.SetActive(true);
        avatar.SetActive(true);
        both.SetActive(true);
        foreach (TextMeshProUGUI mic in options)
        {
            Destroy(mic);
        }
        question.text = "Waiting for user...";
    }
    
}
