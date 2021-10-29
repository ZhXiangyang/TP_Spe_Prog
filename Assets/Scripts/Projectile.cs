using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 8.0f;
    private Vector3 _direction;

    private void Update()
    {
        transform.position += _direction * speed * Time.deltaTime;
    }

    public void Initialize(Vector3 direction)
    {
        _direction = direction;
    }
}