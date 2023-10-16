using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    //
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // push back the enemy
            collision.transform.GetComponent<AIMovement>().EnemyCanMove(false);
        }

        Destroy(gameObject);
    }

    private void OnEnable()
    {
        Destroy(this.gameObject, 2f);
    }
}