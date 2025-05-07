using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public Vector3 AngularVelocity;
    void Update()
    {
        transform.Rotate(AngularVelocity*Time.deltaTime);
    }
}
