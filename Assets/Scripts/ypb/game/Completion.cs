using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Chip;

public class Completion : MonoBehaviour {
    public float RotationFraction = 0.3f;
    void Start(){
        List<Transform> chips = Chip.ChipsManager.GetChips();
        foreach(Transform chip in chips){
            Move move =  chip.GetComponent<Chip.Move>();
            move.Subscribe(new Chip.Move.OnMoveHandler(ChangeBar));
        }
    }

    void ChangeBar(){
        float completion = getCompletion();
        GetComponent<Slider>().value = completion;
    }

    private float getCompletion(){
        List<Transform> chips = Chip.ChipsManager.GetChips();
        float completion = 0;
        foreach(Transform chip in chips){
            completion += chip.GetComponent<Relation>().GetRotaionCompletion() * RotationFraction;
            completion += chip.GetComponent<Relation>().GetDistanceCompletion() * (1 - RotationFraction);
        }
        completion /= chips.Count;
        return completion;
    }
}
