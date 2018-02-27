using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jigsaw : MonoBehaviour {
    public GameObject Chips;

    public void EnterJigsaw(){
        gameObject.SetActive(true);
        Chips.AddComponent<Chip.RotateController>();
    }
}
