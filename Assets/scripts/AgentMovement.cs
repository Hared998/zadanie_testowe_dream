using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;


    private Rigidbody AgentRB;
    private int moveDirection; // Kierunki: 0 - Forward | 1 - Backwards | 2 - Left, 3 - right

    // Start is called before the first frame update

    private void Awake()
    {
        AgentRB = gameObject.GetComponent<Rigidbody>();
    }
    void Start()
    {
        moveDirection = DrawDirection();
        Debug.Log("MD: "+moveDirection);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AgentRB.MovePosition(transform.position + GetDirection()  * speed * Time.deltaTime);
        
    }
    public int DrawDirection()
    {
        int _moveDirection = Random.Range(0, 3);
        if (this.moveDirection != _moveDirection)
            return _moveDirection;
        return DrawDirection();
    }
    public Vector3 GetDirection()
    {
        switch(this.moveDirection)
        {
            case 0:
                return transform.forward;
            case 1:
                return -transform.forward;
            case 2:
                return -transform.right;
            case 3:
                return transform.right;
        }
        return Vector3.zero;

    }



}
