using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed;
    public float horizontalMove;
    public float verticalMove;
    public CharacterController player;
    public Vector3 playerInput;
    private Vector3 camFoward; //donde esta viendo la camera
    private Vector3 camRight;
    public Camera mainCamera;
    private Vector3 movePlayer; //to turn the player. 


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection(); 

        movePlayer = playerInput.x * camRight + playerInput.z * camFoward;


        player.transform.LookAt(player.transform.position + movePlayer);
        player.Move(new Vector3(horizontalMove, 0, verticalMove) * playerSpeed * Time.deltaTime);

    }
    //Get's the camera's direction
    //get the cameras direction and saves it  the global variblas camForward and camRight
    private void camDirection()
    {
        camFoward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camFoward.y = 0;
        camRight.y = 0; 

        camFoward = camFoward.normalized;
        camRight = camRight.normalized;

    }
}
