using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Grid : MonoBehaviour
{
    [SerializeField]
    private float _cellSize = 1f;
    
    [SerializeField]
    private int _cellCount = 10;
    
    [SerializeField]
    private bool _showGrid = true;

    public Vector3 Snap(Vector3 position)
    {
        // Arrondir notre position
        // décaler en fonction de la taille des cellules
        Vector3 newPosition = new Vector3(
            Mathf.Floor((position.x / _cellSize) * _cellSize),
            Mathf.Floor((position.y / _cellSize) * _cellSize),
            Mathf.Floor((position.z / _cellSize) * _cellSize)
        );
        return newPosition;
    }

    private void OnDrawGizmos()
    {
        Vector3 position = transform.position;
        for (int y = 0; y < _cellCount; y++)
        {
            for (int x = 0; x < _cellCount; x++)
            {
                Gizmos.DrawLine(
                    position + new Vector3(0, 0, y * _cellSize),
                    position + new Vector3(x * _cellSize, 0, y * _cellSize)
                );

                Gizmos.DrawLine(
                    position + new Vector3(x * _cellSize, 0, 0), 
                    position + new Vector3(x * _cellSize, 0, y * _cellSize)
                );
            }
        }
    }
}
