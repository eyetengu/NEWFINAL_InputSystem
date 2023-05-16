using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticalPlayerPlayer : MonoBehaviour
{
    public float speedVar = 1;
    public GameObject projectile;
    public float canFire = -1;
    [SerializeField]
    private float fireDelay = 0.5f;
    private int ammoCount = 3;

    public void MoveTheDarnPlayer(Vector2 direction)
    {
        transform.Translate(direction * Time.deltaTime * speedVar);
    }

    public void FireOnMyCommand()
    {
        if (Time.time > canFire && ammoCount >0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            canFire = Time.time + fireDelay;
            ammoCount--;
        }

    }
}
