using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCont : MonoBehaviour
{
    private Rigidbody2D rBody;
    [SerializeField] private float speed = 10.0f;
    // Start is called before the first frame update
    [SerializeField] private GameObject bullet;
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        rBody.velocity = new Vector2(horiz * speed, vert * speed);


        
        Vector3 mouse_pos = Input.mousePosition;
         //The distance between the camera and object
        mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);
        Vector3 direction = new Vector2(mouse_pos.x - transform.position.x, mouse_pos.y - transform.position.y);
        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
        transform.up = direction;


        if (Input.GetMouseButtonDown(0)) {
            float distance = direction.magnitude;
            Vector2 way = direction / distance;

            GameObject b = Instantiate(bullet) as GameObject;
            b.transform.position = transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
            b.GetComponent<Rigidbody2D>().velocity= way * speed;

            

        }
    }
}
