using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconTip : MonoBehaviour {
    public Text Number;
    public GameObject Tip;
    private int rest = 3;
    public Sprite[] sprites;

    public void PromptHandler(){
        CostTip();
        ShowPicture();
    }

    public int GetCost(){
        return rest;
    }

    private void ShowPicture(){
        Tip.SetActive(true);
        Invoke("HidePicture",3);
    }
    private void HidePicture(){
        Tip.SetActive(false);
    }
    private void CostTip(){
        rest --;
        if(rest < 0)
            rest = 0;
        GetComponent<Image>().sprite = sprites[rest];
    }
}
