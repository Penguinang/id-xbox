using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relation : MonoBehaviour {
    private static float ExponentBottomParam = 0.5f;
    public Transform Up;
    public float UpDistance;
    public Transform Down;
    public float DownDistance;

    public float ZAngle;

    /// To get data when coding
    // void Start() {
    //     float up = 0, down = 0;
    //     string uname = "", dname = "";
    //     if (Up != null){
    //         up = Vector3.Distance(Up.position, transform.position);
    //         uname = Up.name;
    //     }
    //     if (Down != null){
    //         down = Vector3.Distance(Down.position, transform.position);
    //         dname = Down.name;
    //     }    
    //     Debug.Log(uname + up +" , " + dname + down);
    // }

    /// <summary>
    /// Get distance completion degree,between 0 and 1
    /// </summary>
    public float GetDistanceCompletion() {
        float up = 0, down = 0;
        if (Up != null)
            up = Vector3.Distance(Up.position, transform.position) - UpDistance;
        if (Down != null)
            down = Vector3.Distance(Down.position, transform.position) - DownDistance;
        if (Mathf.Abs(up) < 0.1)
            up = 0;
        if (Mathf.Abs(down) < 0.1)
            down = 0;

        return Mathf.Pow(ExponentBottomParam, up + down);
    }

    /// <summary>
    /// Get rotation completion degree,between 0 and 1
    /// </summary>
    public float GetRotaionCompletion() {
        float diff = transform.eulerAngles.y - ZAngle;
        return 1 - Mathf.Abs(diff) / 180;
    }
}
