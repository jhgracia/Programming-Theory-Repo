using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int m_Points;
    public int Points { get { return m_Points; } }

    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float rotationSpeed = 50.0f;

    private float vectorRange = 1.0f;

    private Vector3 rotationAngle;
    private Vector3 moveDirection;

    private UIManager uiManager;
    private GameManager gameManager;

    void Start()
    {
        // Initialize managers
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        // Initialize rotationAngle and moveDirection
        rotationAngle = GetRandomVector();
        moveDirection = GetRandomVector();
    }

    void Update()
    {
        if (gameManager.IsGameActive)
        {
            RotateMe();
            MoveMe();
            ValidateBoundaries();
        }
    }

    private void OnMouseDown()
    {
        if (gameManager.IsGameActive)
        {
            InitiateDestroySequence();
        }
    }

    protected virtual void InitiateDestroySequence()
    {
        // Override to add destroying behavior

        uiManager.UpdateScore(m_Points);
    }

    protected void DestroyTarget()
    {
        Destroy(gameObject);
    }


    Vector3 GetRandomVector()
    {
        // Generates a random Vector3 to be assigned to rotationAngle or moveDirection

        float x = Random.Range(-vectorRange, vectorRange);
        float y = Random.Range(-vectorRange, vectorRange);
        float z = Random.Range(-vectorRange, vectorRange);

        return new Vector3(x, y, z).normalized;
    }

    void RotateMe()
    {
        transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
    }

    void MoveMe()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    void ValidateBoundaries()
    {
        // Keeps the object inside the playing area by changing moveDirection as needed

        if(transform.position.x <= -gameManager.XBoundary && moveDirection.x < 0)
        {
            moveDirection.x *= -1;
        }
        else if (transform.position.x >= gameManager.XBoundary && moveDirection.x > 0)
        {
            moveDirection.x *= -1;
        }

        if (transform.position.y <= gameManager.YMinBoundary && moveDirection.y < 0)
        {
            moveDirection.y *= -1;
        }
        else if (transform.position.y >= gameManager.YMaxBoundary && moveDirection.y > 0)
        {
            moveDirection.y *= -1;
        }

        if (transform.position.z <= -gameManager.ZBoundary && moveDirection.z < 0)
        {
            moveDirection.z *= -1;
        }
        else if (transform.position.z >= gameManager.ZBoundary && moveDirection.z > 0)
        {
            moveDirection.z *= -1;
        }
    }
}
