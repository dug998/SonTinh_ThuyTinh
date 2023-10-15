using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(HealthBase))]
public abstract class ObjectBase : MonoBehaviour
{
    [Header(" ___ Component ___"), Space(30)]
    protected Rigidbody2D _myBody;
    protected Animator _myAnim;
    protected SpriteRenderer _sprite;
    protected HealthBase _health;
    [Header(" ___ Properties ____"), Space(30)]
    public float speed;
    public float move;

    public virtual void Start()
    {
        _myAnim = GetComponent<Animator>();
        _health = GetComponent<HealthBase>();
        _sprite = GetComponent<SpriteRenderer>();
        _myBody = GetComponent<Rigidbody2D>();
    }
    public abstract void Born();
    public abstract void Move();
    public abstract void Die();
}
