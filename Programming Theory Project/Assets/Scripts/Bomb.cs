using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Target
{
    public ParticleSystem explosion;

    protected override void InitiateDestroySequence()
    {
        base.InitiateDestroySequence();
        Explode();
    }

    void Explode()
    {
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        DestroyTarget();
    }
}
