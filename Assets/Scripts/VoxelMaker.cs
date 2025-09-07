using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFactory;
    public int voxelPoolSize = 20;
    public static List<GameObject> voxelPool = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < voxelPoolSize; i++)
        {
            GameObject voxel = Instantiate(voxelFactory);
            voxel.SetActive(false);
            voxelPool.Add(voxel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (voxelPool.Count > 0)
                {
                    GameObject voxel = voxelPool[0];
                    voxel.SetActive(true);
                    voxel.transform.position = hitInfo.point;
                    voxelPool.RemoveAt(0);
                }
            }
        }
    }
}
