﻿using UnityEngine;

public class PlayerDig : MonoBehaviour
{
    private PlayerState PS;

    private Collider2D currentGravestone;
    private bool onGrave;

    private void Start()
    {
        PS = GetComponent<PlayerState>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Gravestone")
        {
            onGrave = true;
            currentGravestone = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gravestone")
        {
            onGrave = false;
        }
    }

    private void Update()
    {
        if(onGrave)
        {
            if (Input.GetButtonDown("P" + PS.playerNumber + "Interact"))
            {
                currentGravestone.gameObject.GetComponent<Gravestone>().SpawnItem();
            }
        }
    }
}