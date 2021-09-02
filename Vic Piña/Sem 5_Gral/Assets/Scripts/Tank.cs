using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{
    Vector2 tankMvmntValues;
    float tankSpd = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(tankSpd * tankMvmntValues.y * Time.deltaTime * Vector3.forward);
    }

    public void Fire(InputAction.CallbackContext context)
    {

    }
    public void Move(InputAction.CallbackContext context)
    {
        tankMvmntValues = context.ReadValue<Vector2>();
    }
}
