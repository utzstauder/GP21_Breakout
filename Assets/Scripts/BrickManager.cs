using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public int rows = 3;
    public int columns = 5;

    public float horizontalSpacing = 0.5f;
    public float verticalSpacing   = 0.25f;

    public Brick brickPrefab;

    private int destroyedBricks = 0;

    private void Start()
    {
        if (brickPrefab == null)
        {
            Debug.LogError("Please assign a valid brick prefab!");
        } else
        {
            // instantiate bricks
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    Brick newBrick = Instantiate(
                        brickPrefab,
                        transform.position + GetBrickLocalPosition(x, y),
                        Quaternion.identity);

                    newBrick.transform.SetParent(transform);
                    newBrick.SetBrickManager(this);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (brickPrefab == null) return;

        Gizmos.color = Color.green;
        Gizmos.matrix = transform.localToWorldMatrix;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                Gizmos.DrawWireCube(
                    GetBrickLocalPosition(x, y),
                    brickPrefab.transform.localScale);
            }
        }
    }

    private Vector3 GetBrickLocalPosition(int x, int y)
    {
        return new Vector3(
                        (brickPrefab.transform.localScale.x + horizontalSpacing) * x,
                        -(brickPrefab.transform.localScale.y + verticalSpacing) * y,
                        0);
    }

    public void OnBeforeBrickDestroy(Brick brick)
    {
        destroyedBricks++;
        Debug.Log($"{destroyedBricks}/{rows*columns} bricks destroyed.");

        if (destroyedBricks >= rows * columns)
        {
            Debug.Log("GAME WON!");
        }
    }
}
