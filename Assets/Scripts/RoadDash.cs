
using UnityEngine;

public class RoadDash : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y < -8f)
        {
            transform.position = new Vector3(
                transform.position.x,
                9f,
                transform.position.z
            );
        }
    }
}