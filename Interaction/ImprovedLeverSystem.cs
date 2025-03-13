using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public GameObject door;
    public bool inRange;
    public KeyCode interactKey;

    void Start()
    {
        inRange = false;
    }

    void Update()
    {
        if (inRange = true && Input.GetKeyDown(interactKey))
            door.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.tag == "Player")
            inRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.gameObject.tag == "Player")
            inRange = false;
    }
}
