using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Target
{
    protected override void InitiateDestroySequence()
    {
        base.InitiateDestroySequence();
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        Color initialColor = GetComponent<MeshRenderer>().material.color;
        Color newColor;
        float changeTime = 0.0f;

        while (changeTime < 1.0f)
        {
            newColor = Color.Lerp(initialColor, Color.blue, changeTime);
            GetComponent<MeshRenderer>().material.color = newColor;

            changeTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        DestroyTarget();
    }
}
