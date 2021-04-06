using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayer : MonoBehaviour
{
    public float speed;
    public float powerJump;
    public LayerMask objects;
    [SerializeField] float gravity;
    public Lamp lamp;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Movement(Vector3 dir)
    {
        dir.y = 0;
        Vector3 newPos = this.transform.position;
        rb.MovePosition(newPos + dir.normalized * speed * Time.deltaTime);

    }
    public void Jump(Vector3 dir)
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce((Vector3.up + dir).normalized * powerJump, ForceMode.Force);
        Debug.Log("jumpp");
    }
    public void Gravity()
    {
        rb.AddForce(Vector3.down * gravity, ForceMode.VelocityChange);
    }
    public void Rotate(float x)
    {
        Vector3 rotateCameraVector3 = transform.rotation.eulerAngles;

        rotateCameraVector3.y += x;

        //rb.MoveRotation(Quaternion.Euler(rotateCameraVector3));
    }
    public void SwitchLamp()
    {
        if (lamp.hasLight)
        {
            lamp.GiveLight();
        }
        else
        {
            lamp.GetLight();
        }
    }
    public void MoveLight()
    {
        var owo = Physics.OverlapSphere(lamp.transform.position, lamp.radius, objects);
        if (owo.Length > 0)
        {
            Debug.Log("jsdfjsdf");
            float d = 10000000;
            Collider c = owo[0];
            foreach (var l in owo)
            {
                if (Vector3.Distance(l.transform.position, lamp.transform.position) < d)
                {
                    d = Vector3.Distance(l.transform.position, lamp.transform.position);
                    c = l;
                }
            }
            if (c.GetComponent<LightObject>().hasLight)
            {
                Debug.Log(c.GetComponent<LightObject>());
                c.GetComponent<LightObject>().hasLight = false;
                lamp.GetLight();
                c.GetComponent<LightObject>().lightobject.SetActive(false);
            }
            else
            {
                c.GetComponent<LightObject>().hasLight = true;
                lamp.GiveLight();
                c.GetComponent<LightObject>().lightobject.SetActive(true);
            }

        }
    }
}
