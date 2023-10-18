using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChooseMicrophone : MonoBehaviour
{
    public TextMeshProUGUI question;
    public TextMeshProUGUI mic;
    public MicrophoneLeft Left;
    public MicrophoneRight Right;
    public MicrophoneSelect Select;


    public int bolded = 0;

    private void Start()
    {
        int offset = 0;
        List<TMP_Text> options = new List<TMP_Text>();

        foreach (string m in Microphone.devices)
        {
            offset += 1;
            TextMeshProUGUI microphone = Instantiate(mic, transform);
            options.Add(microphone);

            microphone.text = m;

            // Get the position of the TextMeshProUGUI object
            RectTransform pos = microphone.GetComponent<RectTransform>();
            float lineoffset = Mathf.Ceil(m.Length / 26);
            //shift position down 40 units (fits in more microphones)
            pos.anchoredPosition = new Vector2(pos.anchoredPosition.x, pos.anchoredPosition.y - offset*30 + (lineoffset-offset)*30);
        };

        options[bolded].fontStyle = FontStyles.Bold;
        Left.options = options;
        Right.options = options;
        Select.options = options;
    }
}
