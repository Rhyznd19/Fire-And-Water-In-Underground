using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;

    // Use this for initialization
    void Start()
	{
        //merubah velocity bullet
		rb.velocity = transform.right * speed;
	}

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //mengambil component dari script enemyhealt
        EnemyHealt enemy = hitInfo.GetComponent<EnemyHealt>();
        //jika darah musuh tidak 0 maka diia akan menerima damage
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
