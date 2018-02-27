using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// using UnityEditor;

using Chip;

public class Relation : MonoBehaviour {
    // private static float ExponentBottomParam = 0.5f;
    // public Transform Up;
    // public float UpDistance;
    // public Transform Down;
    // public float DownDistance;

    // public float ZAngle;

    public Transform[] Referneces;
    public Vector3[] RelativePositions;
    public Vector3[] RelativeRotations;
    public Material LightMaterial;
    private float DistancePrecision = 0.1f;
    private float AnglePrecision = 1f;

    void Start(){
        Move move = GetComponent<Move>();
        move.Subscribe(new Move.OnMoveHandler(OnMove));
    }

    private void OnMove(GameObject obj){
        var chips = ChipsManager.GetChips();
        foreach(Transform chip in chips){
            chip.GetComponent<Relation>().CheckReferences();
        }
    }
    public void CheckReferences(){
        bool lighting = false;
        for(int i = 0;i<Referneces.Length;i++){
            bool correction = Vector3.Distance(Referneces[i].position,transform.position + RelativePositions[i]) < 0.1;
            correction &= Vector3.Distance(Referneces[i].eulerAngles, transform.eulerAngles + RelativeRotations[i]) < 1;
            lighting |= correction;
        }
        
        GetComponent<SpriteRenderer>().material.SetFloat("_Light",lighting == true ? 1 : 0);
    }

    public bool GetCombination(){
        bool combined = true;
        for(int i = 0;i<Referneces.Length;i++){
            bool correction = Vector3.Distance(Referneces[i].position,transform.position + RelativePositions[i]) < 0.1;
            correction &= Vector3.Distance(Referneces[i].eulerAngles, transform.eulerAngles + RelativeRotations[i]) < 1;
            combined &= correction;
        }
        return combined;
    }

    // [MenuItem("GameObject/PrintRelation")]
    public static void PrintRelation(){
        GameObject chips = GameObject.Find("Chips");
        for(int i = 0;i < chips.transform.childCount;i++){
            Transform chip = chips.transform.GetChild(i);
            var re = chip.GetComponent<Relation>();
            for(int j = 0;j<re.Referneces.Length;j++){
                re.RelativePositions[j] = re.Referneces[j].position - re.transform.position;
                re.RelativeRotations[j] = re.Referneces[j].eulerAngles - re.transform.eulerAngles;
            }
        }
    }
    

    // public bool GetCompletion(){
    //     if(References == null || References.Length == 0){
    //         return true;
    //     }
        
    //     float distance = Vector3.Distance(Reference.position,transform.position);
    //     if(distance <= DistancePrecision){
    //         transform.position = Reference.position;
    //         distance = 0;
    //     }
    //     float angle = Vector3.Angle(Reference.eulerAngles,transform.eulerAngles);
    //     if(angle <= AnglePrecision){
    //         transform.eulerAngles = Reference.eulerAngles;
    //         angle = 0;
    //     }

    //     if((angle == 0)&&(distance == 0)) Debug.Log("Real Completion");
    //     return (angle == 0)&&(distance == 0);
    // }

    // /// <summary>
    // /// Get distance completion degree,between 0 and 1
    // /// </summary>
    // public float GetDistanceCompletion() {
    //     float up = 0, down = 0;
    //     if (Up != null)
    //         up = Vector3.Distance(Up.position, transform.position) - UpDistance;
    //     if (Down != null)
    //         down = Vector3.Distance(Down.position, transform.position) - DownDistance;
    //     if (Mathf.Abs(up) < 0.1)
    //         up = 0;
    //     if (Mathf.Abs(down) < 0.1)
    //         down = 0;

    //     return Mathf.Pow(ExponentBottomParam, up + down);
    // }

    // /// <summary>
    // /// Get rotation completion degree,between 0 and 1
    // /// </summary>
    // public float GetRotaionCompletion() {
    //     float diff = transform.eulerAngles.y - ZAngle;
    //     return 1 - Mathf.Abs(diff) / 180;
    // }
}
