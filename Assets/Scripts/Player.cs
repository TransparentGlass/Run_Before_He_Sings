using UnityEngine;

public class Player
{
    public int characterHealth {get; private set;}

    void takeDamage()
    {
        --characterHealth;
        return;
    }
}
