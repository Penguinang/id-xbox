using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFade : MonoBehaviour {
    public Material Fade;
    public Color FinalColor;
    public float AnimationTime = 3;
    public Image[] UIImages;
    void OnRenderImage(RenderTexture src,RenderTexture dst){
        Fade.SetColor("_FinalColor",FinalColor);
        Graphics.Blit(src,dst,Fade);
    }

    public void FadeOut(){
        StartCoroutine(InternalFadeOut());
    }

    private IEnumerator InternalFadeOut(){
        float restTime = AnimationTime;
        while(restTime > 0){
            float ratio = restTime / AnimationTime;
            Fade.SetFloat("_WhitenRatio",1-ratio);
            foreach(Image image in UIImages){
                image.color = new Color(image.color.r,image.color.g,image.color.b,ratio);
            }
            restTime -= Time.deltaTime;
            yield return null;
        }

        Game.Game.instance.EndGame();
    }
}
