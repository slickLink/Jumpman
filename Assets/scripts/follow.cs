
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform target;

    public float smoothVar = 0.125f;

    public Vector3 offset;

    private float previous_xCor;

    private void Start()
    {
        previous_xCor = transform.position.x;
    }

    private void LateUpdate()
    {
        
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothVar * Time.deltaTime);
        if(smoothedPosition.x < previous_xCor)
        {
            smoothedPosition.x = previous_xCor;
            transform.position = smoothedPosition;
            previous_xCor = transform.position.x;
        }
        else
        {
            transform.position = smoothedPosition;
            previous_xCor = transform.position.x;
            transform.LookAt(target);
        }
        

        
    }
}
