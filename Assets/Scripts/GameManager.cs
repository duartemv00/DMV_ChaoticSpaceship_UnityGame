using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI enemiesKilledText;
    public static GameManager GMinstance;
    public int enemiesKilled = 0;

    private void Awake(){
        if (GMinstance == null) {
            GMinstance = this;
        }
    }

    void Update(){
        enemiesKilledText.text = enemiesKilled.ToString();
    }
}
