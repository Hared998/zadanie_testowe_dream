using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Directions
{
    vertical,
    horizontal
};
public class Corner
{
    public Vector3 position = Vector3.zero;
    public Directions direction;
    public float radius;

    public Corner (Vector3 position, Directions direction, float radius)
    {
        this.direction = direction;
        this.position = position;
        this.radius = radius;
    }

}

public class MapManager : MonoBehaviour
{


    //Zmienne obs³guj¹ce mape

    private List<GameObject> walls;

    private List<Corner> corners;

    private SpawnAgents spawnAgents;

    void Start()
    {
        spawnAgents = gameObject.GetComponent<SpawnAgents>();

        corners = new List<Corner>();

        SetWallsAroundBoard();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CreateWall(Vector3 startPosition, float radius, Directions direction)    {

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = startPosition;
        cube.transform.SetParent(transform);

        Vector3 tmpWidth = Vector3.one;

        if(Directions.horizontal == direction)
        {
            tmpWidth.z = radius;
        }
        else
            tmpWidth.x = radius;
        cube.transform.localScale = tmpWidth;
        
    }
    public void SetWallsAroundBoard()
    {
        MeshCollider boardMesh = gameObject.GetComponent<MeshCollider>();
        float HorizontalWidth = boardMesh.bounds.size.z;
        float VerticalWidth = boardMesh.bounds.size.x;
        GetCorners(HorizontalWidth, VerticalWidth);
        foreach (var CornerPosition in corners)
        {
            Debug.Log(CornerPosition.direction);
            CreateWall(CornerPosition.position, CornerPosition.radius, CornerPosition.direction);
        }   

    }
    public void GetCorners(float Horizontal, float Vertical)
    {
        Corner corner = new Corner(transform.position + new Vector3(Vertical / 2 , 0, 0), Directions.horizontal, Horizontal);
        corners.Add(corner);
        corner = new Corner(transform.position - new Vector3(Vertical / 2, 0, 0), Directions.horizontal, Horizontal);
        corners.Add(corner);
        corner = new Corner(transform.position + new Vector3(0, 0, Horizontal / 2), Directions.vertical, Vertical);
        corners.Add(corner);
        corner = new Corner(transform.position - new Vector3(0, 0, Horizontal / 2), Directions.vertical, Vertical);
        corners.Add(corner);

    }
}
