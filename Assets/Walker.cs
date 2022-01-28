using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.XR.Cardboard;

public class Walker : MonoBehaviour
{

    public float speed = 1f;
    Transform childCamera;
    Vector3 offset;
    [SerializeField] GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        childCamera = Camera.main.transform;
        offset = childCamera.localPosition;
        childCamera.SetParent(null);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0, childCamera.eulerAngles.y, 0);
        childCamera.position = transform.position + offset;
        Move();
    }

    private void Update()
    {
        if (Api.IsTriggerPressed)
        {
            Instantiate(bullet, (transform.position + transform.forward * 3f), Quaternion.identity);
        }
    }

    void Move()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
