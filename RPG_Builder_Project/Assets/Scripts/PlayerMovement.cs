using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float gravity = 9.8f;
    private float height = 0f;

    // Combat fields
    public float health = 200f;
    public float clickCooldown = 0f;
    private GameObject player;
    private GameObject sword;
    SwordAttack script;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Test Player");
        sword = player.transform.GetChild(0).gameObject;
        script = sword.GetComponent<SwordAttack>();

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (controller.isGrounded)
        {
            height = 0f;
        } else
        {
            height -= gravity * Time.deltaTime;
        }
        
        Vector3 direction = new Vector3(horizontal, height, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
        }

        // Combat triggers
        if (Input.GetKeyDown(KeyCode.Mouse0) && clickCooldown <= 0)
        {
            script.attack = true;
            clickCooldown = .5f;
            Debug.Log("Sword!");
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && clickCooldown == 0)
        {

        }
        else if(clickCooldown > 0)
        {
            clickCooldown -= Time.deltaTime;
        }
        
        // Sword Deactivation
        if(script.attack == true && clickCooldown < 1)
        {
            script.attack = false;
        }
    }
}
