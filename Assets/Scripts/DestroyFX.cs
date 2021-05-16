using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem partDeath = GetComponent<ParticleSystem>();
        partDeath.Play();
        Destroy(gameObject, partDeath.main.duration);
    }
}
