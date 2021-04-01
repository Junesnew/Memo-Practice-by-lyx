using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    public Vector3 angle;
    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = position;
        float a = Mathf.Atan2(angle.y, angle.x);
        this.transform.rotation = Quaternion.Euler(0f, 0f, a);
        angle = angle / Mathf.Sqrt(angle.x * angle.x + angle.y * angle.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += angle * speed * Time.deltaTime;
    }
}
