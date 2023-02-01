using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float speed;
    [SerializeField] private float growRate;

    void Start()
    {
        cam.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
        //cam.orthographicSize = 0.06f * totalMass + 2;
    }

    void Update()
    {
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.mouseScrollDelta.y > 0 && cam.orthographicSize >= 2.5)
        {
            cam.orthographicSize -= growRate;
        }
        if (Input.mouseScrollDelta.y < 0 && cam.orthographicSize <= 30)
        {
            cam.orthographicSize += growRate;
        }
        cam.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
    }
}
