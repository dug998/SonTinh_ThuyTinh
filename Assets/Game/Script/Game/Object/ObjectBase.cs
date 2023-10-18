using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(HealthBase))]
public abstract class ObjectBase : MonoBehaviour
{
    [Header(" ___ Component ___"), Space(30)]
    protected Rigidbody2D _myBody;
    protected Animator _myAnim;
    protected SpriteRenderer _sprite;
    [SerializeField] protected HealthBase _health;
    [Header(" ___ Properties ____"), Space(30)]
    [SerializeField] protected float speed;
    [SerializeField] protected float move;

    float _maxSpeed = 1, _minSpeed = 0.1f;
    float _maxMove = 1, _minMove = 0.1f;
    public virtual void Start()
    {
        _myAnim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _myBody = GetComponent<Rigidbody2D>();
    }
    public virtual void Born()
    {
        _health.SetMaxHealth();
    }
    public abstract void Move();
    public abstract void Die();
    public virtual void UpdateHealth(int values)
    {
        if (values < 0)
        {
            _health.TakeDame(values);
        }
    }
    public virtual void ChangeSpeed(float values)
    {
        speed *= values;
        speed = Mathf.Clamp(speed, _minSpeed, _maxSpeed);
    }
    public virtual void ChangeMove(float values)
    {
        move *= values;
        move = Mathf.Clamp(speed, _minMove, _maxMove);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ObjTag.deadZone))
        {
            Die();
        }
    }
}
