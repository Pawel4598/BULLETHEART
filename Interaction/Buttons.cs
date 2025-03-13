using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject door;
    public float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(timer);

        door.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.tag == "Player") 
            door.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.gameObject.tag == "Player")
            StartCoroutine(CloseDoor());
    }
}
