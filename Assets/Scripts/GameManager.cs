using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Grid setup
    private GameGrid gameGrid;

    // Player setup
    [SerializeField] private GameObject player;

    // Game stats setup
    [SerializeField] private int remainingMoves = 20;

    // Start is called before the first frame update
    void Start()
    {
        gameGrid = GameObject.FindObjectOfType<GameGrid>();
        gameGrid.BuildGameGrid();
        gameGrid.DrawGameGrid();

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 targetPosition = player.transform.position;

        //TODO: See if we can optimize this!
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            targetPosition += gameGrid.scalar * Vector3.forward;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            targetPosition += gameGrid.scalar * Vector3.back;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            targetPosition += gameGrid.scalar * Vector3.right;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            targetPosition += gameGrid.scalar * Vector3.left;
        }
        else
        {
            return;
        }

        // Move the player if conditions are met
        if (remainingMoves > 0 && gameGrid.tiles.ContainsKey(targetPosition))
        {
            remainingMoves--;
            player.transform.position = targetPosition;
        }
    }
}
