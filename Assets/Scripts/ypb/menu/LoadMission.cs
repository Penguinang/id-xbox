using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMission : MonoBehaviour {

    public string SceneName;
    public void LoadMissionHandler(){
        SceneManager.LoadScene(SceneName);
        GameObject BGM1 = GameObject.Find("BGM1");
        BGM1.GetComponent<AudioSource>().mute = true;
    }
}
