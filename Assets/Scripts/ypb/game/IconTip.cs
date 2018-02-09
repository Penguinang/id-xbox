using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconTip : MonoBehaviour {
    public Text Number;
    private int cost = 0;

    public void PromptHandler(){
        CostTip();
        ShowPicture();
    }

    private void ShowPicture(){

    }
    private void CostTip(){
        cost ++;
        Number.text = cost.ToString();
    }
}
