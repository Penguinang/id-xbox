using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class Game : MonoBehaviour {
        public static Game instance{get;private set;}
        public GameObject Jigsaw;
        public GameObject ChipsBar;
        public GameObject Line;
        void Start(){
            if(instance == null)
                instance = this;
        }

        /// <summary>
        /// Controll game turn to Jigsaw interface
        /// </summary>
        public void TurnToJigsaw(){
            Jigsaw jigsaw = Jigsaw.GetComponent<Jigsaw>();
            jigsaw.EnterJigsaw();
            ChipsBar.GetComponent<CollectionBar>().FreeChips();
            Line.SetActive(true);
        }
    }
}
