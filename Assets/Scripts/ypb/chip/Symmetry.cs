using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chip{
    public class Symmetry : MonoBehaviour{
        public static void Trace(GameObject chip){
            GameObject symmetryChip = new GameObject();
            symmetryChip.AddComponent<SpriteRenderer>();
            symmetryChip.GetComponent<SpriteRenderer>().sprite = chip.GetComponent<SpriteRenderer>().sprite;
            symmetryChip.AddComponent<Symmetry>();
            symmetryChip.GetComponent<Symmetry>().SetTraceChip(chip.transform);
        }

        public Transform TraceChip;
        public void SetTraceChip(Transform chip){
            TraceChip = chip;
            transform.position = new Vector3(-chip.position.x,chip.position.y,chip.position.z);
            transform.localScale = new Vector3(-1,1,1);
        }
        void Update(){
            transform.position = new Vector3(-TraceChip.position.x,TraceChip.position.y,TraceChip.position.z);
            transform.rotation = TraceChip.rotation;
        }
        
    }
    
}