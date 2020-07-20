using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float powerUpDuration = 15f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PowerupTimerCoroutine());
    }

    IEnumerator PowerupTimerCoroutine()
    {
        yield return new WaitForSeconds(powerUpDuration); // Powerup 10sn aktif olacak ve ardından yok olacak.
        Destroy(this.gameObject);
    }

    
}
