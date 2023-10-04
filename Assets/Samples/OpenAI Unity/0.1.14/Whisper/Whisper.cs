using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Microsoft.MixedReality.Toolkit.Utilities;
using System;

namespace OpenAI
{
    public class Whisper : MonoBehaviour
    {
        public TextMeshProUGUI input;
        public MakeRequest makereq;
        public TextMeshProUGUI safe;
        public GameObject TTS;
        public int microphone;

        private readonly string fileName = "output.wav";
        private readonly int duration = 5;
        
        private AudioClip clip;
        private bool isRecording;
        private float time;
        private OpenAIApi openai = new OpenAIApi();




        /*
         * Starts Recording and listening for user voice input
         * 
         * @param: None
         * 
         * @return: None
         *
         */
        public void StartRecording()
        {
            TTS.GetComponent<AudioSource>().Stop(); //Stops for interrupt
            input.text = "Listening...";
            isRecording = true;

#if !UNITY_WEBGL

            clip = Microphone.Start(Microphone.devices[microphone], false, duration, 44100);
            #endif
        }

        /*
         * Ends recording and begins GPT translation
         * 
         * @param: None
         * 
         * @return: None
         * 
         */
        private async void EndRecording()
        {
            input.text = "Transcripting...";
            #if !UNITY_WEBGL
            Microphone.End(null);
            #endif
            
            byte[] data = SaveWav.Save(fileName, clip);
            
            var req = new CreateAudioTranscriptionsRequest
            {
                FileData = new FileData() {Data = data, Name = "audio.wav"},
                Model = "whisper-1", //OpenAI STT
                Language = "en"
            };
            var res = await openai.CreateAudioTranscription(req);

            input.text = "User: "+ res.Text;
            Debug.Log($"User: {res.Text}");
            safe.text = res.Text;
            makereq.Request();
        }

        private void Update()
        {
            
            if (isRecording)
            {
                time += Time.deltaTime;
                
                if (time >= duration)
                {
                    time = 0;
                    isRecording = false;
                    EndRecording();
                }
            }
        }
    }
}
