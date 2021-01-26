using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Grid setup
    private GameGrid gameGrid;
    [SerializeField] int gameGridWidth = 5;
    [SerializeField] int gameGridHeight = 5;
    [SerializeField] float gridScale = 1.0f;
    [SerializeField] private GameObject tilePrefab;

    // Player setup
    [SerializeField] private GameObject player;

    // Game stats setup
    private int remainingMoves;

    // Start is called before the first frame update
    void Start()
    {
        gameGrid = gameObject.AddComponent<GameGrid>();
        gameGrid.BuildGameGrid(gameGridWidth, gameGridHeight, gridScale);
        gameGrid.DrawGameGrid(tilePrefab);

        remainingMoves = 20;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 newPosition = player.transform.position;

        //TODO: See if we can optimize this!
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            newPosition += gridScale * Vector3.forward;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            newPosition += gridScale * Vector3.back;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            newPosition += gridScale * Vector3.right;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            newPosition += gridScale * Vector3.left;
        }

        // Check if the grid has the target position
        if (gameGrid.tiles.ContainsKey(newPosition))
        {
            player.transform.position = newPosition;
        }
    }
}
