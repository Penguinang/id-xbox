using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataLoader : MonoBehaviour {
    public RectTransform[] Missions;
    void Awake(){
        for(int i = 0;i<Missions.Length;i++){
            int cost = PlayerPrefs.GetInt("m"+(i+1).ToString(),-1);
            if(cost == -1)
                break;
            
            Missions[i].GetComponent<Button>().interactable = true;
            Missions[i].GetChild(1).GetComponent<Text>().text = cost.ToString();
        }
    }
}
