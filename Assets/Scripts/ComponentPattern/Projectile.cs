using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed = 10f;
	
	void Update () {
        transform.Translate(transform.right * speed * Time.deltaTime);
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.layer);
       if(collision.gameObject.layer == 10)
        {
            Destroy(collision.gameObject);
            if (GameManager.S == null)
                GameManager.S = FindObjectOfType<GameManager>();
            GameManager.S.AddScore(10);
            GameManager.S.RemoveEnemy(collision.gameObject.GetComponent<Enemy>());
            if (GameManager.S.KilledAllEnemies())
                GameManager.S.NextLevel();
            Destroy(gameObject);
        }

    }
}
