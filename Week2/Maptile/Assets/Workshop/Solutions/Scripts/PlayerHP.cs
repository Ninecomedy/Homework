using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP = 100;

    
    public bool hasBag = false;
    public bool hasBook = false;
    public bool hasKey = false;
    public bool hasLog = false;

    void Start()
    {
        currentHP = maxHP;
    }

    public void AddHP(int value)
    {
        currentHP += value;

        if (currentHP > maxHP)
            currentHP = maxHP;
    }
}
