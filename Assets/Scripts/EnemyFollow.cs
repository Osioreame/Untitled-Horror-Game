using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player = null;
    private NavMeshAgent enemy = null;
    bool isGameOver = false;
    public float transitionDelay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemy = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.transform.position);
    }

 

    private void OnCollisionEnter(Collision collision)
    {
        //Play death sound
        Debug.Log("Game Over");
        Invoke("EndGame", transitionDelay); 
    }

    void EndGame()
    {
        if (isGameOver == false)
        {
            isGameOver = true;
            SceneManager.LoadScene(1);
        }
        
    }

    public void SlowEnemy()
    {
        enemy.GetComponent<NavMeshAgent>().speed = 0.1f;
    }


}
