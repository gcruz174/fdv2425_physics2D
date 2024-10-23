using UnityEngine;

public class ImpulseTrigger : MonoBehaviour
{
    [SerializeField] 
    private float force = 25f;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        var rb = other.GetComponent<Rigidbody2D>(); 
        if (rb == null) return;
        rb.AddForce(Vector2.right * force);
    }
}
