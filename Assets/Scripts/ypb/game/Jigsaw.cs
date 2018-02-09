using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jigsaw : MonoBehaviour {
    public GameObject Bkg;
    public GameObject Chips;

    public void EnterJigsaw(){
        Bkg.SetActive(false);
        gameObject.SetActive(true);
        List<GameObject> chips = CollectionBar.instance.GetChips();
        foreach(GameObject chip in chips){
            chip.AddComponent<Chip.Move>();
        }
        Chips.AddComponent<Chip.RotateController>();
    }
}
