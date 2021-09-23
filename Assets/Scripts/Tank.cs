using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{
    Vector3 spawnPosition;
    Quaternion spawnRotation;
    Vector2 tankMovementSpeed;
    public float tankSpeed = 1f;
    public float tankRotSpeed = 10f;
    public float shootForce = 1000f;
    public int health;


    bool canBeDamage;

    int tankIndex;
    public GameObject shellPrefab;
    public Transform spawnShellPos;
    public GameObject destroyTank;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(tankSpeed * tankMovementSpeed.y * Time.deltaTime * Vector3.forward);
        transform.Rotate(tankRotSpeed * tankMovementSpeed.x * Time.deltaTime * Vector3.up);
    }

    public void ReturnToInitialPos()
    {
        transform.SetPositionAndRotation(spawnPosition, spawnRotation);
    }

    public void SetIndex(int index) 
    {
        tankIndex = index;
    }

    public void SetInitialPos(Vector3 position, Quaternion rotation)
    {
        spawnPosition = position;
        spawnRotation = rotation;
        ReturnToInitialPos();
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (!gameObject.activeInHierarchy) return;

        if (context.phase != InputActionPhase.Started) return;

        GameObject bullet = Instantiate(shellPrefab,
            spawnShellPos.position, spawnShellPos.rotation);
        //GameObject bullet = Instantiate(shellPrefab, spawnShellPos);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * shootForce);
        var bulletSc = bullet.GetComponent<Bullet>();
        bulletSc.shootingTank = this.gameObject;
        bulletSc.shootingTankIndex = tankIndex;
    }

    public void Move(InputAction.CallbackContext context)
    {
        tankMovementSpeed = context.ReadValue<Vector2>();
        //transform.Translate(10 * context.ReadValue<Vector2>().y * Time.deltaTime * Vector3.forward);
    }

    public void GetDamage(int amountOfDamage, int hitTankIndex)
    {
        health -= amountOfDamage;
        if (health <= 0) 
        {
            Instantiate(destroyTank, transform.position, transform.rotation);
            //Destroy(this.gameObject);
            GameManager.instance.UpdateKills(hitTankIndex);
            ReturnToInitialPos();
        }
    }
}
