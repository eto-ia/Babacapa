using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door : MonoBehaviour
{
    private Animator _animator = null;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider collider)
    {
        _animator.SetBool("isopen", true);
    }
    void OnTriggerExit(Collider collider)
    {
        _animator.SetBool("isopen", false);
    }
}