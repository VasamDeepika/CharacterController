using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int moveSpeed;
    public CharacterController characterController;
    Vector3 moveInput;
    public Transform cameraTrans;
    public bool invertX, invertY;
    public float mouseSensitivity;
    Vector2 mouseInput;
    public float gravity;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //moveInput.x = Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
        //moveInput.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        Vector3 horizontalMove = transform.right * Input.GetAxis("Horizontal");
        Vector3 verticalMove = transform.forward * Input.GetAxis("Vertical");
        moveInput = horizontalMove + verticalMove;
        moveInput = moveInput * moveSpeed * Time.deltaTime;

        moveInput.y += Physics.gravity.y * gravity * Time.deltaTime;


        characterController.Move(moveInput);

        //camera rotation using mouse input
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSensitivity;

        if (invertX)
        {
            mouseInput.x = -mouseInput.x;

        }
        if (invertY)
        {
            mouseInput.y = -mouseInput.y;

        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        cameraTrans.rotation = Quaternion.Euler(cameraTrans.rotation.eulerAngles + new Vector3(mouseInput.y, 0f, 0f));
    }

}
