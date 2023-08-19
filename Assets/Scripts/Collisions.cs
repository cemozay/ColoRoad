using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public GameObject[] Broke;

    public GameObject ObjPlayer;

    public MeshRenderer Player;
    
    public Material[] Color;

    private void Start()
    {
        //Player Keep String

        ObjPlayer.tag = GameManager.playerTag;

        //Player Keep Colors

        Player.material = Color[GameManager.playerColor];
    }
    private void OnTriggerEnter(Collider other)
    {
        //Hitting Blocks

        if (ObjPlayer.tag != other.tag)
        {
            GameManager.gameOver = true;
        }

        if (ObjPlayer.tag == other.tag)
        {
            //Braking

            if (other.tag == "Red")
            {
                Instantiate(Broke[0], transform.position, transform.rotation);
                Destroy(other.gameObject);
            }
            else if (other.tag == "Green")
            {
                Instantiate(Broke[1], transform.position, transform.rotation);
                Destroy(other.gameObject);
            }
            else if (other.tag == "Blue")
            {
                Instantiate(Broke[2], transform.position, transform.rotation);
                Destroy(other.gameObject);
            }

            GameManager.numberOfPassedBlocks++;

            if (GameManager.numberOfPassedBlocks % 2 == 0)
            {
                FindObjectOfType<PlayerMovement>().forwardSpeed += 150;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Level Up

        if (collision.collider.tag == "EndBlock")
        {
            GameManager.levelCompleted = true;
            Player.material.color = collision.collider.GetComponent<MeshRenderer>().material.color;

            if (collision.collider.name == "LastRed")
            {
                PlayerPrefs.SetInt("playerColor", 0);
                PlayerPrefs.SetString("playerTag", "Red");
            }
            else if (collision.collider.name == "LastGreen")
            {
                PlayerPrefs.SetInt("playerColor", 1);
                PlayerPrefs.SetString("playerTag", "Green");
            }
            else if (collision.collider.name == "LastBlue")
            {
                PlayerPrefs.SetInt("playerColor", 2);
                PlayerPrefs.SetString("playerTag", "Blue");
            }
        }
    }
}
