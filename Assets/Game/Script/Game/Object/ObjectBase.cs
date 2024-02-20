using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(HealthBase))]
[RequireComponent(typeof(Dead))]
public abstract class ObjectBase : MonoBehaviour
{
    [Header(" ___ Component ___"), Space(30)]

    protected Rigidbody2D _myBody;
    protected Collider2D _myColli;
    protected Animator _myAnim;
    protected SpriteRenderer _sprite;
    [SerializeField] protected HealthBase _health;
    [SerializeField] protected Dead _Dead;

    [Header(" ___ Properties ____"), Space(30)]

    [SerializeField] protected bool _isDead;
    [SerializeField] protected float speed;

    float _maxSpeed = 1, _minSpeed = 0.1f;
    public virtual void Start()
    {
        _myAnim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _myBody = GetComponent<Rigidbody2D>();
        _myColli = GetComponent<Collider2D>();
    }
    public virtual void Born()
    {
        _isDead = false;
        _health.SetMaxHealth();
    }
    public abstract void Move();
    public abstract IEnumerator Die();
    public virtual void Died()
    {
        StartCoroutine(Die());
    }
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

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ObjTag.deadZone))
        {
            Died();
        }
    }
    public HealthBase GetHealthBase()
    {
        return _health;
    }
}
