using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MicrophoneLeft : MonoBehaviour
{
    public ChooseMicrophone controller;
    public List<TMP_Text> options;
    public void MoveLeft()
    {
        
        int curr = controller.GetComponent<ChooseMicrophone>().bolded;
        controller.GetComponent<ChooseMicrophone>().bolded -= 1;

        //Ensures we don't go negative and out of bounds
        if (controller.GetComponent<ChooseMicrophone>().bolded < 0) { controller.GetComponent<ChooseMicrophone>().bolded = options.Count - 1; }

        int index = controller.GetComponent<ChooseMicrophone>().bolded;

        options[index].fontStyle = FontStyles.Bold;

        options[curr].fontStyle = FontStyles.Normal;
    }
}
