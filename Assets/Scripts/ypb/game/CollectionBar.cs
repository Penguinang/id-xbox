using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chip;

public class CollectionBar : MonoBehaviour {
    public static CollectionBar instance{get;private set;}
    public float CollectionInterval = 1.5f;
    private List<GameObject> chips;
    private int collectNumber = 0;

    public Transform top;
    public int ChipsSum;
    void Start(){
        if(instance == null)
            instance = this;
        chips = new List<GameObject>();
    }

    /// <summary>
    /// Collect a chip
    /// </summary>
    public static void Collect(GameObject chip){
        Collect collect = chip.GetComponent<Collect>();
        if(collect != null)
            collect.MoveTo(instance.NextPosition());
        instance.chips.Add(chip);
    }

    public static void CollectComplete(){
        instance.collectNumber ++;
        if(instance.collectNumber >= instance.ChipsSum)
            Game.Game.instance.TurnToJigsaw();
    }

    public void FreeChips(){
        for(int i = 0;i<chips.Count;i++){
            chips[i].GetComponent<Collect>().unpack();
            float height = Screen.height,width = Screen.width;
            Vector3 sPosition = Camera.main.WorldToScreenPoint(transform.position);
            float newX = width * 0.75f;
            float newY = height * (i+1) / (chips.Count+1);

            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(newX, newY, sPosition.z));
            chips[i].GetComponent<Rigidbody2D>().MovePosition(position);
            Symmetry.Trace(chips[i]);
        }
    }

    public List<GameObject> GetChips(){
        return chips;
    }

    private Vector2 NextPosition(){
        Vector2 ret = top.position;
        ret += new Vector2(CollectionInterval, 0f) * chips.Count;
        return ret;
    }
}
