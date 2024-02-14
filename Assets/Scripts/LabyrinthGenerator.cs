// Inspiriert von [Q https://youtu.be/_aeYq5BmDMg?t=585]

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeCell mazeCellPrefab;

    [SerializeField]
    private int mazeWidth;

    [SerializeField]
    private int mazeDepth;

    [SerializeField]
    private Vector3 mazeStartPosition;

    [SerializeField]
    private GameObject mainPlain;

    private MazeCell[,] mazeGrid;

    void Start()
    {
        mazeGrid = new MazeCell[mazeWidth, mazeDepth];
        GameObject mazeSize = Instantiate(new GameObject("GrundrissLabyrinth"), Vector3.zero, Quaternion.identity);

        for (int x = 0; x < mazeWidth; x++)
        {
            for (int z = 0; z < mazeDepth; z++)
            {
                mazeGrid[x, z] = Instantiate(mazeCellPrefab, mazeStartPosition + new Vector3(x, 0, z), Quaternion.identity);
                mazeGrid[x, z].transform.parent = mazeSize.transform;
            }
        }
        
        GenerateMaze(null, mazeGrid[0, 0]);
        mazeSize.transform.SetParent(mainPlain.transform);
    }

    private void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        currentCell.Visit();
        ClearWalls(previousCell, currentCell);

        MazeCell nextCell;

        do
        {
            nextCell = GetNextUnvisitedCell(currentCell);

            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);
    }

    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    private IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        int x = (int)(currentCell.transform.position.x - mazeStartPosition.x);
        int z = (int)(currentCell.transform.position.z - mazeStartPosition.z);

        if (x + 1 < mazeWidth && x + 1 >= 0 && z >= 0 && z < mazeDepth)
        {
            var cellToRight = mazeGrid[x + 1, z];

            if (cellToRight.IsVisited == false)
            {
                yield return cellToRight;
            }
        }

        if (x - 1 >= 0 && x - 1 < mazeWidth && z >= 0 && z < mazeDepth)
        {
            var cellToLeft = mazeGrid[x - 1, z];

            if (cellToLeft.IsVisited == false)
            {
                yield return cellToLeft;
            }
        }

        if (z + 1 < mazeDepth && z + 1 >= 0 && x >= 0 && x < mazeWidth)
        {
            var cellToFront = mazeGrid[x, z + 1];

            if (cellToFront.IsVisited == false)
            {
                yield return cellToFront;
            }
        }

        if (z - 1 >= 0 && z - 1 < mazeDepth && x >= 0 && x < mazeWidth)
        {
            var cellToBack = mazeGrid[x, z - 1];

            if (cellToBack.IsVisited == false)
            {
                yield return cellToBack;
            }
        }
    }

    private void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if (previousCell == null)
        {
            return;
        }

        if (previousCell.transform.position.x < currentCell.transform.position.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }

        if (previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }

        if (previousCell.transform.position.z < currentCell.transform.position.z)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
            return;
        }

        if (previousCell.transform.position.z > currentCell.transform.position.z)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
            return;
        }
    }

}
