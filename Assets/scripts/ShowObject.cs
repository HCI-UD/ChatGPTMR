using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowObject : MonoBehaviour
{

    public GameObject _object;
    public GameObject GPTBoardButt;
    public GameObject AvatarBoardButt;
    public GameObject easy;
    public GameObject hard;
    public Tracking tracker;
    public TextMeshProUGUI boardQ;
    public TextMeshProUGUI boardR;


    /*
     * Shows the object that needs to be shown (GPT canvas or Avatar), and hides rest
     * 
     * @param: None
     * 
     * @return: None
     * 
     */
    public void show()
    {
        _object.SetActive(true); //show object (GPT canvas or Avatar)
        tracker.method = _object.name; //Assigns object name to 'tracker.method' for tracking
        GPTBoardButt.SetActive(false); //
        AvatarBoardButt.SetActive(false);
        boardQ.text = "Waiting on user input";
        boardR.text = "";
        easy.SetActive(true);
        hard.SetActive(true);
    }

}
