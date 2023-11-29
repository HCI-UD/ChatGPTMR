using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowObject : MonoBehaviour
{

    public GameObject _object;
    public GameObject AvatarObj;
    public GameObject BoardObj;
    public GameObject GPTBoardButt;
    public GameObject AvatarBoardButt;
    public GameObject BothButt;
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
        if(gameObject == GPTBoardButt)
        {
            BoardObj.SetActive(true);
            tracker.method = "Board";
        }
        else if(gameObject == AvatarBoardButt)
        {
            AvatarObj.SetActive(true);
            tracker.method = "Avatar";
        }
        else
        {
            AvatarObj.SetActive(true);
            BoardObj.SetActive(true);
            tracker.method = "Avatar + Board";
        }
        /*_object.SetActive(true); //show object (GPT canvas or Avatar)
        tracker.method = _object.name; //Assigns object name to 'tracker.method' for tracking*/
        GPTBoardButt.SetActive(false); //
        AvatarBoardButt.SetActive(false);
        BothButt.SetActive(false);
        boardQ.text = "Waiting on user input";
        boardR.text = "";
        easy.SetActive(true);
        hard.SetActive(true);
    }

}
