using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChecker : MonoBehaviour
{
    public bool Active;
    public int direction;
    void Awake()
    {
        Active = false;
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Wall") || other.transform.CompareTag("Agent"))
        {

            Active = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Wall") || other.transform.CompareTag("Agent"))
        {
            Debug.Log("Wychodze" + direction);
            Active = false;
        }
    }
}
