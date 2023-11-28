using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private void Awake()
    {
        instance = this;
    }
    
    public float moveSpeed;

    public Animator anim;

    public float pickupRange = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = PlayerStatController.instance.moveSpeed[0].value;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        //Debug.Log(moveInput);

        moveInput.Normalize();

        //Debug.Log(moveInput);

        transform.position += moveInput * moveSpeed * Time.deltaTime;

        if(moveInput != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        } else 
        {
            anim.SetBool("isMoving", false);
        }
    }
}
