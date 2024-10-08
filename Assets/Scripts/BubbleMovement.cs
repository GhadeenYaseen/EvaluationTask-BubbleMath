using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed, amp;
    public Transform self;

    private void Start() 
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        self = gameObject.transform;
        speed = UnityEngine.Random.Range(1f,3.5f);
    }

    private void FixedUpdate() 
    {
        rb.velocity = transform.up * speed ;
    }

    private void Update() {
      self.position = new Vector3(move(), transform.position.y, transform.position.z);  
    }

    public float move()
    {
        return transform.position.x - Mathf.Sin(Time.time * speed) * amp * Time.deltaTime;
    }
}
