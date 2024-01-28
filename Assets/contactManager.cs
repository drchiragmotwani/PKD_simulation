using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contactManager : MonoBehaviour
{
    public int pokeForce = 100;
    public GameObject marker, markerPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForceAtPosition(ray.direction * pokeForce, hit.point);
                    Debug.Log("HIT POINT" + hit.point);

                    marker = Instantiate(markerPoint, hit.point, Quaternion.identity);

                    marker.transform.parent = hit.rigidbody.transform;
                    Destroy(marker, 2f);
                }
            }
        }
    }
}
