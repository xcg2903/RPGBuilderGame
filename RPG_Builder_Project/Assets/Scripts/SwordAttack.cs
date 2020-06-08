using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float damage = 50f;
    public bool attack = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    } 
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" && attack == true)
        {
            Debug.Log("Hit!");
        }
        else
        {
            Debug.Log("Missed.");
        }
    }
}
