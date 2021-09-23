using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int amountOfDamage;
    public int shootingTankIndex;
    public GameObject shootingTank;
    public GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        //Determino si el objeto con el que colisina la bala tiene un componente Tank
        Tank tank = other.GetComponent<Tank>();


        if (tank != null) 
        { 
            if (tank.gameObject == shootingTank) return;
            tank.GetDamage(amountOfDamage, shootingTankIndex);
        }

        var explosionPrefab = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(explosionPrefab, 3);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
