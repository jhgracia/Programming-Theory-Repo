using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // ENCAPSULATION
    public static DataManager Instance { get; private set; }

    private string m_Name;
    private int m_Score;

    public string Name
    {
        get { return m_Name; }
        set
        {
            // Blank name is changed to "Unknown Player"
            if (value == "")
            {
                m_Name = "Unknown Player";
            }
            else
            {
                m_Name = value;
            }
        }
    }

    public int Score
    {
        get { return m_Score; }
        set
        {
            // Negative score is changed to 0
            if (value < 0)
            {
                m_Score = 0;
            }
            else
            {
                m_Score = value;
            }
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
