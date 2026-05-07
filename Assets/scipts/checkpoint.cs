using UnityEngine;
 
public class checkPoint : MonoBehaviour
{
       public Transform currentCheckpoint;
       public GameObject player;
 
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<playerHP>();
        if (player != null)
        {
            player.checkpoint = transform;
        }
    }
}