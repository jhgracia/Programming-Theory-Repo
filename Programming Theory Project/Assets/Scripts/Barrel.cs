using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : Target
{
    protected override void InitiateDestroySequence()
    {
        // POLYMORPHISM
        base.InitiateDestroySequence();
        StartCoroutine(Shrink());
    }

    IEnumerator Shrink()
    {
        float shrinkTime = 0.0f;
        Vector3 initialScale = transform.localScale;

        while (shrinkTime < 1.0f)
        {
            transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, shrinkTime);
            shrinkTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        // ABSTRACTION
        DestroyTarget();
    }
}
