using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemydedVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int EnemyScore;
    [SerializeField] int enemyHitCount = 0;

    Scoreboard scoreBoard;
    GameObject parentGameObject;

    private void Start()
    {
        scoreBoard = FindObjectOfType<Scoreboard>();
        AddRigidBody();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        
    }

    private void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (enemyHitCount < 1)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
            GameObject vfx = Instantiate(enemydedVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
            Destroy(gameObject);
    }

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        scoreBoard.IncreaseScore(EnemyScore);
        enemyHitCount--;
    }
}
