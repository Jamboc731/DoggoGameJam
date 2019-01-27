using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefinitelyNotGlitchyCameraScript : MonoBehaviour {
    public GameObject target;
    public float rotateSpeed = 5;
    private Vector3 offset;
    private float offsetDist = 5.0f;

    void Start ()
    { 

        setNewOffset(offsetDist);
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            setNewOffset(++offsetDist);
        } else if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            setNewOffset(--offsetDist);
        }

        
       

    }

    void LateUpdate()
    {
        float mouse_x = Input.GetAxis("Mouse X") * rotateSpeed;
        offset = Quaternion.AngleAxis(mouse_x, Vector3.up) * offset;
        float dist = Vector3.Distance(target.transform.position, transform.position);
        dist = 0.5f;
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, dist);
        transform.LookAt(target.transform.position);

        ////transform.RotateAround(target.transform.position, Vector3.up, mouse_x * Time.deltaTime);

        
    }


    private void setNewOffset(float d) {
        d = Mathf.Clamp(d, 1.0f, 10.0f);
        offset =  new Vector3(target.transform.position.x, target.transform.position.y + d/2, target.transform.position.z + d);
    }
}
