using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int healthCounter = 3;

    public void TakeDMG(int amount)
    {
        if (healthCounter >= 1)
            healthCounter -= amount;
        else
            Debug.LogError("E mort baaa");
    }
}
