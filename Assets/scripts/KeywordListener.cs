using System.Collections;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class KeywordListener : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    public bool shouldListen = true;
    public GameObject recordButton;
    public GameObject selectButton;
    public GameObject leftButton;
    public GameObject rightButton;

    // Start is called before the first frame update
    void Start()
    {
        keywords.Add("wake", () =>
        {
            if (shouldListen && (recordButton!=null))
            {
                Debug.Log("wake");
                recordButton.GetComponent<ButtonConfigHelper>().OnClick.Invoke();
                shouldListen = false;
            }
        });
        keywords.Add("choose", () =>
        {
            if (shouldListen && selectButton != null)
            {
                Debug.Log("select");
                selectButton.GetComponent<ButtonConfigHelper>().OnClick.Invoke();
            }
        });
        keywords.Add("left", () => {
            if (shouldListen && leftButton != null)
            {
                Debug.Log("left");
                leftButton.GetComponent<ButtonConfigHelper>().OnClick.Invoke();
            }

        });
        keywords.Add("right", () => {
            if (shouldListen && rightButton != null)
            {
                Debug.Log("right");
                rightButton.GetComponent<ButtonConfigHelper>().OnClick.Invoke();
            }

        });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += onKeywordRecognized;
        keywordRecognizer.Start();
    }

    void onKeywordRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if(keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
