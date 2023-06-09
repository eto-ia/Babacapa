using UnityEngine;

public class Jump : MonoBehaviour
{
    public GameObject pause;
    public GameObject inv;
    public GameObject set;
    public GameObject warn;
    public GameObject note;
    public static bool checkPause = true;
    Rigidbody rigidbody1;
    public float jumpStrength = 2;
    public event System.Action Jumped;

    [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundCheck groundCheck;
    void Reset()
    {
        groundCheck = GetComponentInChildren<GroundCheck>();
    }
    void Awake()
    {
        rigidbody1 = GetComponent<Rigidbody>();
    }
    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump") && (!groundCheck || groundCheck.isGrounded) && !pause.activeSelf && !inv.activeSelf && !set.activeSelf && !warn.activeSelf && !note.activeSelf && !checkPause)
        {
            rigidbody1.AddForce(Vector3.up * 100 * jumpStrength);
            Jumped?.Invoke();
        }
    }
}
