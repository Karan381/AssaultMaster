using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemydedVFX;
    [SerializeField] Transform parent;
    [SerializeField] int EnemyScore;

    Scoreboard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<Scoreboard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        KillEnemy();
        ProcessHit();

    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(enemydedVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        scoreBoard.IncreaseScore(EnemyScore);
    }
}
