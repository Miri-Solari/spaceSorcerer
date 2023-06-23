using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;

public class Player_control : MonoBehaviour
{
    public ControlType controlType;
    public Joystick joystick;
    public float Speed;
    public enum ControlType { PC, Android}
    private Vector2 direct;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controlType == ControlType.PC)
        {
            direct.x = Input.GetAxisRaw("Horizontal");
            direct.y = Input.GetAxisRaw("Vertical");
        }
        
    }

    private void FixedUpdate()
    {
       
        rb.MovePosition(rb.position + direct * Time.deltaTime * Speed); 
    }
}
