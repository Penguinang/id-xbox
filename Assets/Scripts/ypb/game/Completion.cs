using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Chip;

public class Completion : MonoBehaviour {
    public float RotationFraction = 0.3f;
    public Image CompletionProcess;
    public int ChipSum;
    private int CompletedCount = 0;
    void Start(){
        List<Transform> chips = Chip.ChipsManager.GetChips();
        foreach(Transform chip in chips){
            Move move =  chip.GetComponent<Chip.Move>();
            move.Subscribe(new Chip.Move.OnMoveHandler(ChangeBar));
        }
    }

    void ChangeBar(GameObject obj){
        bool completed = true;
        var chips = ChipsManager.GetChips();

        int combinedNumber = 0;
        foreach(Transform chip in chips){
            if(chip.GetComponent<Relation>().GetCombination())
                combinedNumber ++;

            completed &= chip.GetComponent<Relation>().GetCombination();
            float sizex = chip.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
            completed &= Mathf.Abs(chip.position.x - sizex / 2) < 0.1;
        }

        float completion = 0;
        if(completed)
            completion = 1;
        else if(combinedNumber == 0)
            completion = 0;
        else if(combinedNumber == 1)
            completion = 0.25f;
        else
            completion = 0.5f;

        CompletionProcess.fillAmount = completion;
        if(completed){
            // Game.Game.instance.EndGame();
            Camera.main.GetComponent<CameraFade>().FadeOut();
        }
    }

    // private float getCompletion(){
    //     List<Transform> chips = Chip.ChipsManager.GetChips();
    //     float completion = 0;
    //     foreach(Transform chip in chips){
    //         completion += chip.GetComponent<Relation>().GetRotaionCompletion() * RotationFraction;
    //         completion += chip.GetComponent<Relation>().GetDistanceCompletion() * (1 - RotationFraction);
    //     }
    //     completion /= chips.Count;
    //     return completion;
    // }
}
