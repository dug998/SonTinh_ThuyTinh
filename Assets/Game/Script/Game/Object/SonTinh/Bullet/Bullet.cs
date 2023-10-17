using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D myBody;
    [SerializeField] int dame;
    public GameObject ballHit;

    // Use this for initialization
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ObjTag.thuyTinh))
        {
            Monster monsterHealth = collision.gameObject.GetComponent<Monster>();
            monsterHealth.UpdateHealth(-dame);
            Instantiate(ballHit, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            ballHit.transform.localScale = Vector2.one * 0.5f;
            Destroy(gameObject);
        }

    }
}
