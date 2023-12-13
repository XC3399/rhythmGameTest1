using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class gridManager : MonoBehaviour
{
    public GameObject floor;
    public Vector3 startLocation = new Vector3(0, 0, 0);
    public int scale = 1;
    
    public int row = 5;
    public int column = 6;

    public GameObject[,] gridUnits;

    private void Awake()
    {
        gridUnits = new GameObject[row, column];
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                Debug.Log(row);
                Debug.Log(column);
                GameObject obj = Instantiate(floor,
                    new Vector3(startLocation.x + scale * i, startLocation.y, startLocation.z + scale * j), Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);

                gridUnits[i, j] = obj;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
