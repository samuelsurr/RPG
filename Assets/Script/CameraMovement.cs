using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()//Update happens ever frame but
        // FixedUpdate happens when a physics system is set to tick (usually 30 times a sec vs the 60 times a sec)
        // LateUpdate alwasys comes last (updates last)
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);//takes what value you want to border for x values
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);//takes what value you want to border for y values

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);


        }
    }
}
