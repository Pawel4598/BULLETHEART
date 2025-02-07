using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;

    public void ActivateLever()
    {
        if(!isOpen)
        {
            isOpen = true;
            Debug.Log("Works");
            animator.SetBool("IsOpen", isOpen);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



