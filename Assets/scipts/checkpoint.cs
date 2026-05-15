using UnityEngine;
using System.Collections.Generic;


public class checkPoint : MonoBehaviour
{
       public Transform currentCheckpoint;
       public GameObject player;
       public bool active;
    public Sprite sActive;
    public Sprite sInactive;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<playerHP>();
        if (player != null)
        {
            if (player.checkpoint != null)
            {
                player.checkpoint.gameObject.GetComponent<checkPoint>().ChangeSprite(false);
            }
                player.checkpoint = currentCheckpoint;
                currentCheckpoint.gameObject.GetComponent<checkPoint>().ChangeSprite(true);
        }
    }

    public void ChangeSprite(bool Bool)
    {
        if (Bool)
        {
            active = Bool;
            GetComponent<SpriteRenderer>().sprite = sActive;
        } else
        {
            active = Bool;
            GetComponent<SpriteRenderer>().sprite = sInactive;
        }
    }
}