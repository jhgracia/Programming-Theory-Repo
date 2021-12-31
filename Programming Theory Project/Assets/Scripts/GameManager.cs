using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Properties used by the targets to validate they're moving inside the playing area;
    // by reading the values from here there's no need for every target to have its own set of
    // private variables, reducing the use of memory

    // ENCAPSULATION
    public float XBoundary { get; private set; }
    public float YMinBoundary { get; private set; }
    public float YMaxBoundary { get; private set; }
    public float ZBoundary { get; private set; }
    // ENCAPSULATION
    //................................................

    public GameObject[] targetPrefabs;

    // ENCAPSULATION
    public bool IsGameActive { get; private set; }

    private float timeDelay = 1.0F;
    private float timeRepeat = 1.5f;
    private int maxTargets = 10;
    // ENCAPSULATION

    void Start()
    {
        XBoundary = 15.0f;
        YMinBoundary = 1.0f;
        YMaxBoundary = 8.0f;
        ZBoundary = 10.0f;

        IsGameActive = true;
        InvokeRepeating("SpawnTarget", timeDelay, timeRepeat); // ABSTRACTION
    }

    void SpawnTarget()
    {
        if (IsGameActive && GameObject.FindGameObjectsWithTag("Target").Length < maxTargets)
        {
            int index = Random.Range(0, targetPrefabs.Length);

            //                                    ABSTRACTION
            Instantiate(targetPrefabs[index], RandomSpawnPosition(), targetPrefabs[index].transform.rotation);
        }
    }

    Vector3 RandomSpawnPosition()
    {
        float x = Random.Range(-XBoundary, XBoundary);
        float y = Random.Range(YMinBoundary, YMaxBoundary);
        float z = Random.Range(-ZBoundary, ZBoundary);

        return new Vector3(x, y, z);
    }

    public void GameOver()
    {
        IsGameActive = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
