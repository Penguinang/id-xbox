using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconTip : MonoBehaviour {
    public Text Number;
    public GameObject Tip;
    private int cost = 0;

    public void PromptHandler(){
        CostTip();
        ShowPicture();
    }

    private void ShowPicture(){
        Tip.SetActive(true);
        Invoke("HidePicture",3);
    }
    private void HidePicture(){
        Tip.SetActive(false);
    }
    private void CostTip(){
        cost ++;
        Number.text = cost.ToString();
    }
}
