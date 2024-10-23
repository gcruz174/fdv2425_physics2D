using UnityEngine;

public class DynamicCrate : MonoBehaviour
{
    private void OnCollisionEnter2D()
    {
        Debug.Log("Collision detected in " + gameObject.name + ": Dynamic");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger detected in " + gameObject.name + ": Dynamic");
    }
}
