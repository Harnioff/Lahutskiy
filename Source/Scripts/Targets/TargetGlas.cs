using UnityEngine;

public class Glass : MonoBehaviour
{
    public void Hit()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bird>())
        {
            Hit();
        }
    }
}