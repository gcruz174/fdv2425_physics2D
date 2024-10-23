using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float amplitude = 1f;
    [SerializeField] private float frequency = 1f;

    private float _startY;
    
    private void Start()
    {
        _startY = transform.position.y;
    }
    
    private void Update()
    {
        var offset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(transform.position.x, _startY + offset, transform.position.z);
    }
}
