using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemydedVFX;
    [SerializeField] Transform parent;
    private void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(enemydedVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
