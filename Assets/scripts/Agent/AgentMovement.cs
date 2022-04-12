using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;


    public List<int> moveDriections;

    private Rigidbody AgentRB;

    public List<MoveChecker> checkers;

    [SerializeField]
    private int moveDirection; // Kierunki: 0 - Forward | 1 - Backwards | 2 - Left, 3 - right

    // Start is called before the first frame update

    private void Awake()
    {
        AgentRB = gameObject.GetComponent<Rigidbody>();
    }
    void Start()
    {
        UpdateCheckers();
        moveDirection = DrawDirection();
    }

    // Update is called once per frame
    
    private void Update()
    {
    
    }
    void FixedUpdate()
    {
        AgentRB.MovePosition(transform.position + GetDirection() * speed * Time.deltaTime);
    }
    public int DrawDirection()
    {
        List<int> available = new List<int>();
        foreach (var checker in checkers)
        {
            if (!checker.Active)
            {
                available.Add(checker.direction);
            }
        }
        return available[Random.Range(0, available.Count)];
    }
    public void UpdateCheckers()
    {
        checkers.Clear();
        foreach (var checker in gameObject.GetComponentsInChildren<MoveChecker>())
        {
            checkers.Add(checker);
        }
    }
    public Vector3 GetDirection()
    {
        switch(this.moveDirection)
        {
            case 0:
                return transform.right;
            case 1:
                return -transform.right;
            case 2:
                return -transform.forward;
            case 3:
                return transform.forward;
        }
        return Vector3.zero;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall") || collision.transform.CompareTag("Agent"))
        {
    
            moveDirection = DrawDirection();
            Debug.Log(moveDirection);
        }
    }

}
