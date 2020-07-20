using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody enemyRb;
    private GameObject player;
   
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
                
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized; // Uzaklıktan bağımsız aynı hız-ivme de gitmesi için normalize edilmesi gerekir.
        //Enemy player'ı takip edecek.
        enemyRb.AddForce(lookDirection * speed); // VectorPlayer - VectorEnemy = Distance(mesafe),direction(yön)
        OutOfBound();
    }

    private void OutOfBound()
    {
        if(transform.position.y < -10)
            Destroy(this.gameObject);
        
    }

      
    
}
