using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chip {
    public class ChipsManager : MonoBehaviour {

        private static ChipsManager instance;
        private List<Transform> chips;
        void Awake(){
            if(instance == null)
                instance = this;
            chips = new List<Transform>();
            for (int i = 0; i < transform.childCount; i++)
                chips.Add(transform.GetChild(i));
        }

        public static List<Transform> GetChips(){
            return instance.chips;
        }
    }
}