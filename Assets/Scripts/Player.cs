using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public Rigidbody playerRB;
    public float bounceForce = 6;

    private AudioManager audioManager;


    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce");
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);
        string materialname = collision.transform.GetComponent<MeshRenderer>().material.name;

        if (materialname == "safe (Instance)")
        {
            
        }
        else if (materialname == "unsafe (Instance)")
        {
            Debug.Log("game over");
            GamerManager.gameOver = true;
            audioManager.Play("game over");
        }
        else if (materialname == "LastRing (Instance)" && !GamerManager.levelCompleted)
        {
            Debug.Log("level completed");
            GamerManager.levelCompleted = true;
            audioManager.Play("win level");
        }
    }
}
