using System.Collections.Generic;
using UnityEngine;

public class LabyrinthGenerator : MonoBehaviour
{
    public GameObject treePrefab; // Assign the tree prefab in the inspector
    public GameObject playerObject; // Assign the player object in the inspector
    public SpriteRenderer doorRenderer; // Assign the door sprite renderer in the inspector
    public int width = 10;
    public int height = 10;

    void Start()
    {
        GenerateLabyrinth();
    }

    void GenerateLabyrinth()
    {
        // Create a 2D array to store the labyrinth data
        bool[,] labyrinth = new bool[width, height];

        // Initialize all cells as walls
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                labyrinth[x, y] = true;
            }
        }

        // Create a recursive backtracking algorithm to carve passages
        CarvePassages(labyrinth, width, height);

        // Place trees in empty spaces
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (labyrinth[x, y] == false)
                {
                    // Instantiate the tree prefab at the current position
                    Instantiate(treePrefab, new Vector3(x, y, 0), Quaternion.identity);
                }
            }
        }

        // Place player at a random empty cell
        PlacePlayer(labyrinth);

        // Place door at a random empty cell far from the player
        PlaceDoor(labyrinth);
    }

    void CarvePassages(bool[,] labyrinth, int width, int height)
    {
        while (true)
        {
            // Choose a random empty cell
            int randomX = Random.Range(0, width);
            int randomY = Random.Range(0, height);

            if (labyrinth[randomX, randomY] == false)
            {
                // Get available neighbors
                List<int[]> neighbors = GetAvailableNeighbors(labyrinth, randomX, randomY);

                // Choose a random neighbor
                int[] randomNeighbor = neighbors[Random.Range(0, neighbors.Count)];
                int neighborX = randomNeighbor[0];
                int neighborY = randomNeighbor[1];

                // Remove the wall between the cells
                RemoveWall(labyrinth, randomX, randomY, neighborX, neighborY);
            }
        }
    }

    List<int[]> GetAvailableNeighbors(bool[,] labyrinth, int x, int y)
    {
        List<int[]> neighbors = new List<int[]>();

        // Check possible neighbors (north, south, east, west)
        if (y > 0 && labyrinth[x, y - 1] == false)
        {
            neighbors.Add(new int[] { x, y - 1 });
        }

        if (y < height - 1 && labyrinth[x, y + 1] == false)
        {
            neighbors.Add(new int[] { x, y + 1 });
        }

        if (x > 0 && labyrinth[x - 1, y] == false)
        {
            neighbors.Add(new int[] { x - 1, y });
        }

        if (x < width - 1 && labyrinth[x + 1, y] == false)
        {
            neighbors.Add(new int[] { x + 1, y });
        }

        return neighbors;
    }

    void RemoveWall(bool[,] labyrinth, int x1, int y1, int x2, int y2)
    {
        // Determine the direction of the wall to remove
        int dx = x2 - x1;
        int dy = y2 - y1;

        // Calculate the midpoint of the wall (clamped to labyrinth bounds)
        int midX = Mathf.Clamp(x1 + x2, 0, width - 1) / 2;
        int midY = Mathf.Clamp(y1 + y2, 0, height - 1) / 2;

        // Only remove the wall if it's currently a wall (not already empty)
        if (labyrinth[midX, midY - 1] == true || labyrinth[midX, midY] == true)
        {
            labyrinth[midX, midY - 1] = false;
            labyrinth[midX, midY] = false;
        }
    }

    void PlacePlayer(bool[,] labyrinth)
    {
        // Find a random empty cell to place the player
        while (true)
        {
            int randomX = Random.Range(1, width - 1); // Avoid placing player on walls
            int randomY = Random.Range(1, height - 1); // Avoid placing player on walls

            if (labyrinth[randomX, randomY] == false)
            {
                // Set the player's position in the labyrinth array
                labyrinth[randomX, randomY] = true; // Mark the cell as occupied

                // Set the player's GameObject position
                playerObject.transform.position = new Vector3(randomX, randomY, 0f);

                // Break out of the loop once the player has been placed
                break;
            }
        }
    }

    void PlaceDoor(bool[,] labyrinth)
    {
        // Find a random empty cell far from the player to place the door
        while (true)
        {
            int randomX = Random.Range(1, width - 1);
            int randomY = Random.Range(1, height - 1);

            if (labyrinth[randomX, randomY] == false)
            {
                // Calculate the distance between the player and the potential door location
                int distanceX = (int)Mathf.Abs(playerObject.transform.position.x - randomX);
                int distanceY = (int)Mathf.Abs(playerObject.transform.position.y - randomY);

                // Ensure the door is placed at a minimum distance from the player
                const int minDistance = 5; // Adjust as needed
                if (distanceX >= minDistance && distanceY >= minDistance)
                {
                    // Set the door's position in the labyrinth array
                    labyrinth[randomX, randomY] = true; // Mark the cell as occupied

                    // Set the door's SpriteRenderer position
                    doorRenderer.transform.position = new Vector3(randomX, randomY, 0f);

                    // Break out of the loop once the door has been placed
                    break;
                }
            }
        }
    }


}

