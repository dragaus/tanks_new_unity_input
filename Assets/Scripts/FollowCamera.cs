using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 1, 0);
    public float speed = 100;
    public float rotSpeed = 100;
    public float height = 10;
    public float distance = 5;

    private void Awake()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!target) return;

        var lookPosition = target.position + offset;
        var relativePos = lookPosition - transform.position;

        var rot = Quaternion.LookRotation(relativePos);

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotSpeed * 0.1f);

        var targetPos = target.position + target.up * height - target.forward * distance;

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed * 0.1f);
    }
}