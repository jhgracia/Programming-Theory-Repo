using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPoints : MonoBehaviour
{
    public TextMesh pointsText;
    private Target parentScript;

    void Start()
    {
        // Display the Points this target gives

        parentScript = GetComponentInParent<Target>();
        if (parentScript != null)
        {
            pointsText.text = parentScript.Points.ToString();
        }
    }

    private void LateUpdate()
    {
        // Keep the text above the target and facing the camera regardless of target's rotation

        transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
    }
}
