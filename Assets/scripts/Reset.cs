using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reset : MonoBehaviour
{
    public TextMeshProUGUI title;
    public GameObject GPT;
    public GameObject avatar;
    public GameObject BoardButt;
    public GameObject AvatarButt;
    public GameObject BothButt;
    public GameObject ResetButt;
    public GameObject ExitButt;

    /*
     * Resets the entire program, permits user to try again under different parameters
     * 
     * @param: None
     * 
     * @return: None
     * 
     */
    public void reset()
    {
        title.text = "Waiting on User Input...";
        GPT.SetActive(false); //hide GPT Board
        avatar.SetActive(false); //hide Avatar
        BothButt.SetActive(true);
        BoardButt.SetActive(true); //show GPT Board button
        AvatarButt.SetActive(true); //show Avatar button
        ResetButt.SetActive(false); //hide reset button
        ExitButt.SetActive(false); //hide exit button
    }
}
