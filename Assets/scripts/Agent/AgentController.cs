using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    [SerializeField] 
    private int health;
    private SpawnAgents spawnAgent;
    private AgentInfo agentInfo;

    // Start is called before the first frame update

    public void Awake()
    {
        agentInfo = GameObject.Find("AgentInfo").GetComponent<AgentInfo>();
    }
    public int GetHealth()
    {
        return this.health;
    }

    public void SetSpawnAgent(SpawnAgents spawnAgent)
    {
        this.spawnAgent = spawnAgent;
    }
    public void isDead()
    {
        if (health <= 0)
        {
            spawnAgent.DestroyAgent();
            agentInfo.disableAgent();
            Destroy(gameObject);
        }
    }
    public void GiveDamage()
    {
        this.health--;
        isDead();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Agent"))
        {
      
            collision.gameObject.GetComponent<AgentController>().GiveDamage();
            agentInfo.UpdateInfo(health, gameObject.name);
        }
    }

}
