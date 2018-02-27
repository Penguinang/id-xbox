using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTip : MonoBehaviour {

    public GameObject Texttip;
    public void TextClickHandler(){
        Texttip.SetActive(true);
        Invoke("recover",3);
    }

    private void recover(){
        Texttip.SetActive(false);
    }
}
