using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public enum Axis{x, y}
    public Axis check = Axis.y;
    public float range;
    public float speed;
    private Vector3 StartPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float radius = Mathf.PingPong(Time.time*speed, range*2)-range;
        Vector3 NewPosition = StartPosition;
        if (check==Axis.y)
        {
            NewPosition.y += radius;
        }
        else
        {
            NewPosition.x += radius;
        }
        transform.position = NewPosition;
    }
}
