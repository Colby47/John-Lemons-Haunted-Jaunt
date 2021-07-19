using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{

    bool m_IsPlayerInRange;
    public Transform player;
    public GameEnding gameEnding;

    //if the player enters trigger, player is in range
    void OnTriggerEnter (Collider other){

        if (other.transform == player){
            m_IsPlayerInRange = true;
        }

    }

    //if player leaves trigger, player is NOT in range
    void OnTriggerExit (Collider other){

        if (other.transform == player){
            m_IsPlayerInRange = false;
        }

    }

    void Update (){
        
        //if player is in range, ray cast to see if ray collides with player
        if (m_IsPlayerInRange == true){

            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray (transform.position, direction);
            RaycastHit raycastHit;

            //if raycast hits something, go into if statement
            if(Physics.Raycast(ray, out raycastHit)){
                
                if(raycastHit.collider.transform == player){
                    gameEnding.CaughtPlayer();
                }

            }

        }

    }
}
