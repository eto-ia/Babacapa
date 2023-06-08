using UnityEngine;

public class Jump : MonoBehaviour
{
    public GameObject pause;
    public GameObject inv;
    public GameObject set;
    public GameObject warn;
    public GameObject note;
    Rigidbody rigidbody1;
    public float jumpStrength = 2;
    public event System.Action Jumped;
 

    [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundCheck groundCheck;


    void Reset()
    {
        // Try to get groundCheck.
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Awake()
    {
        // Get rigidbody.
        rigidbody1 = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        // Jump when the Jump button is pressed and we are on the ground.
        if (Input.GetButtonDown("Jump") && (!groundCheck || groundCheck.isGrounded) && !pause.activeSelf && !inv.activeSelf && !set.activeSelf && !warn.activeSelf && !note.activeSelf)
        {
            rigidbody1.AddForce(Vector3.up * 100 * jumpStrength);
            Jumped?.Invoke();
        }
    }
}
