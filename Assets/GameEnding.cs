using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    //vraibles
    public float fadeDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public float displayImageDuration = 3f;
    bool m_IsPlayerAtExit = false;
    float m_Timer;

    //class method that detects when another collider enters trigger
    void OnTriggerEnter (Collider other){

        //if that other collider is the player, the player is at the exit
        if (other.gameObject == player){
            m_IsPlayerAtExit = true;
        }

    }

    void Update(){

        //if player is at exit, end the game
        if(m_IsPlayerAtExit == true){
            EndLevel();

        }
    }

    //timer increases, the alpha of the UI is set to the timer / the fade duration
    //once the timer goes over the fade duration + the image duration, the application quits
    void EndLevel (){

        m_Timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration){
            Application.Quit();
        }

    }

}
