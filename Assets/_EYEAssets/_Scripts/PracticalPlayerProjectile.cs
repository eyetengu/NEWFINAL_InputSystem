using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticalPlayerProjectile : MonoBehaviour
{
    public int projSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * projSpeed); 
        if(transform.position.y > 7)
                Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
    }
}
