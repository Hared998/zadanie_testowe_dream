using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Zmienne potrzebne do generowania agentów
    
    public int minTimeForSpawn;
    public int maxTimerForSpawn;

    public int maxAgents;

    [SerializeField]
    private GameObject agent;

    //Zmienne obs³guj¹ce mape

    [SerializeField]
    private GameObject board;

    private List<GameObject> walls;

    enum Postions
    {
        vertical,
        horizontal
    };

    void Start()
    {
        SetWallsAroundBoard();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CreateWall(Vector3 startPosition, float radius, Postions direction)    {

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = startPosition;
        walls.Add(cube);
        Vector3 tmpWidth = Vector3.one;

        if(Postions.horizontal == direction)
        {
            tmpWidth.z = radius;
        }
        else
            tmpWidth.x = radius;
        cube.transform.localScale = tmpWidth;
    }
    public void SetWallsAroundBoard()
    {
        MeshCollider boardMesh = board.GetComponent<MeshCollider>();
        float HorzionstalWidth = boardMesh.bounds.size.z;
        float VerticalWidth = boardMesh.bounds.size.x;

        Vector3 CornerPosition = board.transform.position + new Vector3(VerticalWidth / 2,0,0);
        CreateWall(CornerPosition, HorzionstalWidth, Postions.horizontal);
        CornerPosition = board.transform.position - new Vector3(VerticalWidth / 2, 0, 0);
        CreateWall(CornerPosition, HorzionstalWidth, Postions.horizontal);
        CornerPosition = board.transform.position + new Vector3(0, 0, HorzionstalWidth / 2);
        CreateWall(CornerPosition, VerticalWidth, Postions.vertical);
        CornerPosition = board.transform.position - new Vector3(0, 0, HorzionstalWidth / 2);
        CreateWall(CornerPosition, VerticalWidth, Postions.vertical);
    }

}
