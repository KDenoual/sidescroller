using UnityEngine;

public class PV : MonoBehaviour
{
    public Sprite zeroPv;
    public Sprite unPv;
    public Sprite deuxPv;
    public Sprite troixPv;
    public playerHP pHP;

    public void Update()
    {
        
        if (pHP.hp == 3)
        {
            GetComponent<SpriteRenderer>().sprite = troixPv;
        }
        else if (pHP.hp == 2)
        {
            GetComponent<SpriteRenderer>().sprite = deuxPv;
        }
        else if (pHP.hp == 1)
        {
            GetComponent<SpriteRenderer>().sprite = unPv;
        }
        else if (pHP.hp == 0)
        {
            GetComponent<SpriteRenderer>().sprite = zeroPv;
        }
    }


}
