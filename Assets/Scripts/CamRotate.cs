using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    Vector3 angle;
    public float sensitivity = 200;
    // Start is called before the first frame update
    void Start()
    {
        angle = Camera.main.transform.eulerAngles;
        angle.x *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");

        angle.x += x * sensitivity * Time.deltaTime;
        angle.y += y * sensitivity * Time.deltaTime;

        angle.x = Mathf.Clamp(angle.x, -90, 90);

        transform.eulerAngles = new Vector3(-angle.x, angle.y, transform.eulerAngles.z);
    }
}
