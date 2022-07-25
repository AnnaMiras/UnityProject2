using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float MoveSpeed = 4;
    [SerializeField] public float RunSpeed = 8;
    [SerializeField] public float JumpPower = 5;
    [SerializeField] public float Mouse_x = 100;
    [SerializeField] public float Mouse_y = 150;
    [SerializeField] public Transform cam = null;
    [SerializeField] public float max_angle = 70;
    [SerializeField] public float min_angle = -60;

    private Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    bool jumpCommand = false;

    float anlge = 0;
    // Update is called once per frame
    void Update()
    {
        jumpCommand |= Input.GetButtonDown("Jump");
        var mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.rotation *= Quaternion.Euler(0, mouseInput.x * Mouse_x * Time.deltaTime, 0);
        anlge = Mathf.Clamp(anlge - mouseInput.y * Mouse_y * Time.deltaTime, -max_angle, -min_angle);
        cam.localRotation = Quaternion.Euler(anlge, 0, 0);
    }

    private void FixedUpdate()
    {
        var motionInput = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        motionInput.x += rbody.velocity.x;
        motionInput.z += rbody.velocity.z;
        var speed = Input.GetButton("Fire3") ? RunSpeed : MoveSpeed;
        motionInput.y = rbody.velocity.y;
        if (jumpCommand)
        {
            jumpCommand = false;
            motionInput.y = JumpPower;
        }
        rbody.velocity = motionInput;
    }
}