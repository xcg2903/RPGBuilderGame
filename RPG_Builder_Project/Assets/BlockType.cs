using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockType : MonoBehaviour
{
    //Fields
    [SerializeField] Block[] allBlocks;
    [SerializeField] int currentblock = 0;

    #region BlockInfo

    [Header("Materials")]
    [SerializeField] Material grassMat;
    [SerializeField] Material sandMat;

    [Space(1)]

    [Header("Mesh")]
    [SerializeField] Mesh cubeMesh;
    [SerializeField] Mesh slantMesh;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Initialize Variables
        allBlocks = new Block[4];

        #region Block Setup
        allBlocks[0] = new Block(grassMat);
        allBlocks[1] = new Block(sandMat);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        //Assign Block
        this.gameObject.GetComponent<Renderer>().material = allBlocks[currentblock].blockMat;
    }
}

[SerializeField]
public class Block
{
    //Fields
    public Material blockMat;
    public Mesh blockMesh;

    public Block(Material blockMat, Mesh blockMesh)
    {
        this.blockMat = blockMat;
        this.blockMesh = blockMesh;
    }
}
