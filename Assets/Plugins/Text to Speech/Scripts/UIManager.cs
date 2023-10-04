using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CognitiveServicesTTS;
using System;
using System.Threading.Tasks;
using TMPro;

public class UIManager : MonoBehaviour {

    public SpeechManager speech;
    public TextMeshProUGUI input;


    /*
     * Calls, creates, and plays audioclip of TTS
     * 
     * @param: None
     * 
     * @return: None
     * 
     */
    public async void SpeechPlayback()
    {
        if (speech.isReady)
        {
            string msg = input.text; //GPT response
            speech.voiceName = VoiceName.enUSJessaNeural; //Can change voice
            speech.VoicePitch = 0;
            await Task.Run(() => speech.SpeakWithSDKPlugin(msg));
            
        }
        else
        {
            Debug.Log("SpeechManager is not ready. Wait until authentication has completed.");
        }
    }

}
