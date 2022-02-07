using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemydedVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int EnemyScore;
    [SerializeField] int enemyHitCount = 0;

    Scoreboard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<Scoreboard>();
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
            vfx.transform.parent = parent;
            Destroy(gameObject);
    }

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        scoreBoard.IncreaseScore(EnemyScore);
        enemyHitCount--;
    }
}
