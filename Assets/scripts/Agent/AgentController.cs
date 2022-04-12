using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    [SerializeField] 
    private int health;
    private SpawnAgents spawnAgent;

    // Start is called before the first frame update

    public void SetSpawnAgent(SpawnAgents spawnAgent)
    {
        this.spawnAgent = spawnAgent;
    }
    public void isDead()
    {
        if (Health <= 0)
        {
            spawnAgent.DestroyAgent();
            Destroy(gameObject);
        }
    }
    public void GiveDamage()
    {
        this.Health--;
        isDead();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Agent"))
        {
            collision.gameObject.GetComponent<AgentController>().GiveDamage();
        }
    }

}
