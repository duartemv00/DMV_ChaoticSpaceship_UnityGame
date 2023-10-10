using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D bullet) { 
        Debug.Log("Algo se ha golpeado");
        if (bullet.gameObject.tag == "Bullet") {
            GameManager.GMinstance.enemiesKilled += 1;
            Debug.Log("Enemy hit");
        }
    }
}
