using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string playerTag = "Player";
    public float destroyDelay = 0.1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Collect();
        }
    }

    void Collect()
    {
       

        Destroy(gameObject, destroyDelay);
    }
}
