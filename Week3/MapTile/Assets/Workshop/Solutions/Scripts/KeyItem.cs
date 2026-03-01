using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public enum KeyType
    {
        Key,
        Book,
        Log,
        Bag
    }

    public KeyType keyType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHP player = other.GetComponentInParent<PlayerHP>();

        if (player != null)
        {
            switch (keyType)
            {
                case KeyType.Bag:
                    player.hasBag = true;
                    break;

                case KeyType.Key:
                    player.hasKey = true;
                    break;

                case KeyType.Book:
                    player.hasBook = true;
                    break;

                case KeyType.Log:
                    player.hasLog = true;
                    break;
            }

            Debug.Log("Picked up: " + keyType);
            Destroy(gameObject);
        }
    }
}
