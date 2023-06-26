using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateMachine : MonoBehaviour
{
    public Unit Player;
    public GameObject Enemys;
    void Update()
    {
        if (Player != null)
        {
            print(Player.HP);
            if (Player.HP < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if(Enemys.GetComponentInChildren<Unit>() == null) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
        }
    }
}
