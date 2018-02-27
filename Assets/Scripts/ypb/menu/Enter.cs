using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enter : MonoBehaviour {
    public RectTransform StartPanel;
    public RectTransform CGPanel;
    public RectTransform[] CGs;
    public float FrameTime = 3;

    void Update(){
        if(Input.GetMouseButtonUp(0)){
            ClickHandler();
        }
    }

    private void ClickHandler(){
        /// obsolete
        // bool firstGame = PlayerPrefs.GetInt("InitGame",1) == 1;
        // if(firstGame){
        //     StartCoroutine(PlayCG());
        //     StartPanel.gameObject.SetActive(false);
        // }
        // else{
        //     EnterMissions();
        // }
        // PlayerPrefs.SetInt("InitGame",0);
        StartCoroutine(PlayCG());

    }


    private IEnumerator PlayCG(){
        // CGPanel.gameObject.SetActive(true);
        // int i = 0;
        // while(i<CGs.Length){
        //     if(i>0)
        //         CGs[i-1].gameObject.SetActive(false);
        //     CGs[i].gameObject.SetActive(true);
        //     i++;
        //     yield return new WaitForSeconds(FrameTime);
        // }
        Material ma = StartPanel.GetComponent<Image>().material;
        ma.SetColor("_FinalColor",Color.white);
        float restTime = FrameTime;
        while(restTime>0){
            ma.SetFloat("_WhitenRatio",1-restTime/FrameTime);
            restTime -= Time.deltaTime;
            yield return null;
        }
        EnterMissions();
    }

    private void EnterMissions(){
        SceneManager.LoadScene("missions");
    }
    public void Skip(){
        StopCoroutine(PlayCG());
        EnterMissions();
    }
}
