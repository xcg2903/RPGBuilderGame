using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
    // Start is called before the first frame update
    //int[,,] blockmatrix;
    [SerializeField]private Camera playerCam;
    [SerializeField] Vector3 point;
    [SerializeField] private Vector3 buildPos;

    [SerializeField] private LayerMask buildSurface;
    [SerializeField] private bool canPlace;

    private GameObject placerBlock;
    [SerializeField] private GameObject placerBlockPrefab;
    [SerializeField] private GameObject blockPrefab;

    void Start()
    {
        //blockmatrix = new int[10, 10, 10]; //Might need matrix later
        canPlace = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit buildPosHit;

        if (Physics.Raycast(playerCam.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), out buildPosHit, buildSurface))
        {
            print("hit");
            point = buildPosHit.point;
            buildPos = new Vector3(Mathf.Round(point.x), Mathf.Round(point.y), Mathf.Round(point.z));
            canPlace = true;
        }
        else
        {
            Destroy(placerBlock);
            canPlace = false;
            print("no");
        }

        if(canPlace && placerBlock == null)
        {
            placerBlock = Instantiate(placerBlockPrefab, buildPos, Quaternion.identity);
        }

        if(canPlace && placerBlock != null)
        {
            placerBlock.transform.position = buildPos;
        }

        if(canPlace && Input.GetMouseButtonDown(0))
        {
            Instantiate(blockPrefab, buildPos, Quaternion.identity);
        }
    }
}
