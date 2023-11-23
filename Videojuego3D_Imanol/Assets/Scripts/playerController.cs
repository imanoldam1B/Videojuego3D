using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController playerController;
    public float gravityScale;
    public Camera playerCamera;

    private Vector3 moveDirection;
    private float yStore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yStore = moveDirection.y;

        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),0f, Input.GetAxisRaw("Vertical"));
        moveDirection = moveDirection * moveSpeed;
        
        moveDirection.y = yStore;   

        //Salto
        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }
        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

        playerController.Move(moveDirection * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0f, playerCamera.transform.eulerAngles.y, 0f);
        

    }
}
