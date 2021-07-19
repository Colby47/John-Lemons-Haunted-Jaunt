using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    //vraibles
    public float fadeDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public float displayImageDuration = 3f;
    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;

    //class method that detects when another collider enters trigger
    void OnTriggerEnter (Collider other){

        //if that other collider is the player, the player is at the exit
        if (other.gameObject == player){
            m_IsPlayerAtExit = true;
        }

    }

    public void CaughtPlayer(){
        m_IsPlayerCaught = true;
    }

    void Update(){

        //if player is at exit, end the game
        if(m_IsPlayerAtExit == true){
            EndLevel(exitBackgroundImageCanvasGroup, false);

        }
        //if player is caught, end game
        else if(m_IsPlayerCaught == true){
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    //timer increases, the alpha of the UI is set to the timer / the fade duration
    //once the timer goes over the fade duration + the image duration, the application quits
    void EndLevel (CanvasGroup imageCanvasGroup, bool doRestart){

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration){
            //restart level if caught
            if(doRestart == true){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            //quit application if player made it to exit
            else{
                Application.Quit();
            }
        }
    }

}
