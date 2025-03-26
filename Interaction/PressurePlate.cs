using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;
    public float timer = 5f;
    private Coroutine closeDoorCoroutine;

    private IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(timer);

        door.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            door.SetActive(false);
            if(closeDoorCoroutine != null)
            {
                StopCoroutine(closeDoorCoroutine);
                closeDoorCoroutine = null;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.gameObject.tag == "Player")
            closeDoorCoroutine = StartCoroutine(CloseDoor());
    }
}
