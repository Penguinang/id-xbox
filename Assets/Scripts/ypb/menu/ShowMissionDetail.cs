using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMissionDetail : MonoBehaviour {

    public GameObject Detail;
    public Sprite BKG;

    public void ShowDetailHandler(){
        Transform details = Detail.transform.parent;
        for(int i = 0;i<details.childCount;i++){
            details.GetChild(i).gameObject.SetActive(false);
        }
        Detail.SetActive(true);
        transform.parent.GetComponent<Image>().sprite = BKG;
    }
}
