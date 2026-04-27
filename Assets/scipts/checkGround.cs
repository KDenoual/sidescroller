using UnityEngine;

public class checkGround : MonoBehaviour
{
    public PlayerMovementPlatformer myPlayerManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myPlayerManager.isGround = true;
        myPlayerManager.Jump = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        myPlayerManager.isGround = false;
        myPlayerManager.Jump = false;
    }
}
