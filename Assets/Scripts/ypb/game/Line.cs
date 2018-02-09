using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
    public Vector3 Top;
    public Vector3 Bottom;
    public float Interval;
    public float LineFraction;
    public GameObject LinePrefab;
    void Start(){
        float position = Top.y - Interval;
        while(position > Bottom.y) {
            addLine(
                new Vector3(Top.x,position + Interval,Top.z),
                new Vector3(Top.x,position + Interval * LineFraction,Top.z)
            );
            position -= Interval;
        }
        addLine(
            new Vector3(Top.x,position + Interval,Top.z),
            new Vector3(Top.x,Bottom.y,Top.z)
        );
    }

    private void addLine(Vector3 Start,Vector3 End) {
        GameObject line = Instantiate(LinePrefab);
        line.transform.SetParent(transform);
        line.transform.localPosition = new Vector3();
        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.SetPositions(new Vector3[]{Start, End});
    }
}
