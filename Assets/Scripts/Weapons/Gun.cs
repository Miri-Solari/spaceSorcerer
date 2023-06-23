using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    public Base_Partical Particle;
    public Transform ShotPoint;
    public float StartReloadTime;
    private float ReloadTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ+offset);

        if(ReloadTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(Particle, ShotPoint.position, ShotPoint.rotation);
                ReloadTime = StartReloadTime;

            }
        }
        else
        {
            ReloadTime -= Time.deltaTime;
        }
    }
}
