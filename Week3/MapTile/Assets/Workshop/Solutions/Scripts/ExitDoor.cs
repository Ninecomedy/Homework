using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHP player = other.GetComponentInParent<PlayerHP>();

        if (player != null)
        {
           
            if (player.hasBag && player.hasBook && player.hasKey && player.hasLog)
            {
                Debug.Log("WIN !!!");
            }
            else
            {
                Debug.Log("You don't have all items!");
            }
        }
    }
}
