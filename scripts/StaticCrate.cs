using UnityEngine;

public class StaticCrate : MonoBehaviour
{
    private void OnCollisionEnter2D()
    {
        Debug.Log("Collision detected in " + gameObject.name + ": Static");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger detected in " + gameObject.name + ": Static");
    }
}
