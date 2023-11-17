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

    // Start is called before the first frame update
    void Start()
    {
        keywords.Add("wake", () =>
        {
            if (shouldListen && (recordButton!=null))
            {
                Debug.Log("here");
                recordButton.GetComponent<ButtonConfigHelper>().OnClick.Invoke();
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
