using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public LeverController lever;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
         if(lever.isOpen)
        {
            gameObject.SetActive(false);
        }
    }
}
