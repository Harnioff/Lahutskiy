using UnityEngine;

public class TargetScale : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bird>())
        {
            Hit();
            collision.gameObject.transform.localScale *= 2;
        }
    }

    public void Hit()
    {
        _renderer.material.color = Random.ColorHSV();
    }
}