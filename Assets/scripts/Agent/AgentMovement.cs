using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{

    public int changeRoadTimer;
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
        StartCoroutine(WaitSecondsAndChangeDirection());
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
        if(available.Count > 0)
            return available[Random.Range(0, available.Count)];
        return -1;
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
            if (DrawDirection() != -1)
                moveDirection = DrawDirection();

        }
    }
    IEnumerator WaitSecondsAndChangeDirection()
    {

        yield return new WaitForSeconds(changeRoadTimer);
        moveDirection=DrawDirection();
        StartCoroutine( WaitSecondsAndChangeDirection());
    }
    

}
