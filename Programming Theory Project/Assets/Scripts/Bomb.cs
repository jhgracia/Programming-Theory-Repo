using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Target
{
    public ParticleSystem explosion;

    protected override void InitiateDestroySequence()
    {
        // POLYMORPHISM
        base.InitiateDestroySequence();
        Explode();
    }

    void Explode()
    {
        Instantiate(explosion, transform.position, explosion.transform.rotation);

        // ABSTRACTION
        DestroyTarget();
    }
}
