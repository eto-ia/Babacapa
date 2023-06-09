using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;
    Rigidbody rigidbody1;
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();
    public static bool checkPause = true;
    void Awake()
    {
        rigidbody1 = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!checkPause)
        {
            IsRunning = canRun && Input.GetKey(runningKey);
            float targetMovingSpeed = IsRunning ? runSpeed : speed;
            if (speedOverrides.Count > 0)
            {
                targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
            }
            Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);
            rigidbody1.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody1.velocity.y, targetVelocity.y);
        }
    }
}