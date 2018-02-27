using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game {
    public class Game : MonoBehaviour {
        public static Game instance{get;private set;}
        public RectTransform CG;
        public GameObject Jigsaw;
        public GameObject ChipsBar;
        public GameObject Line;
        public GameObject TipIcon;
        public int Mission;
        void Awake(){
            if(instance == null)
                instance = this;
        }

        void Start(){
            TurnToJigsaw();
        }

        public void EndCG(){
            // CG.gameObject.SetActive(false);
            CG.localScale = new Vector3(0,0,0);
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

        public void EndGame(){
            RecordGame();
            SceneManager.LoadScene("missions");
            GameObject BGM1 = GameObject.Find("BGM1");
            BGM1.GetComponent<AudioSource>().mute = false;
        }

        private void RecordGame(){
            int cost = TipIcon.GetComponent<IconTip>().GetCost();
            PlayerPrefs.SetInt("m"+Mission.ToString(),cost);
        }
    }
}
