using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooting : MonoBehaviour
{
    public float rayDistance = 10f;
    public LayerMask hitLayers;
    public LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
    
        if (Input.GetMouseButtonDown(0))
            ShootRay();
    }

    void ShootRay()
    {
        Vector2 rayOrigin = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rayDirection = (mousePosition - rayOrigin).normalized;

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance, hitLayers);

        lineRenderer.SetPosition(0, rayOrigin);
        lineRenderer.SetPosition(1, hit.collider != null ? hit.point : rayOrigin + rayDirection *  rayDistance);

        if (hit.collider != null)
            Debug.Log("Hit: " + hit.collider.name);

        StartCoroutine(DisableLineRenderer());
    }

    IEnumerator DisableLineRenderer()
    {
        yield return new WaitForSeconds(0.1f);
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);
    }
    
        private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void LookAtMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x > transform.position.x && !facingRight)
            Flip();
        else if (mousePosition.x < transform.position.x && facingRight)
            Flip();
    }
}
