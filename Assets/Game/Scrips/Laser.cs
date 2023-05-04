using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PoitionLaserAndDestroy();
        
    }

    private void PoitionLaserAndDestroy()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > 5.52)
        {
            Destroy(this.gameObject);
            //DestroyLaser();

        }

    }

}