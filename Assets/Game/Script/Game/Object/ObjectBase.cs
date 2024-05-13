using Sirenix.OdinInspector;
using System.Collections;
using System.ComponentModel;
using UnityEngine;

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
    [SerializeField] protected Vector2 currSpeed;
    [SerializeField] protected Vector2 orginSpeed = new Vector2(6, 0);

    float _maxSpeed = 1, _minSpeed = 0.1f;
    private void Reset()
    {
        _health = GetComponent<HealthBase>();
        _Dead = GetComponent<Dead>();
    }
    public virtual void Start()
    {
        _myAnim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _myBody = GetComponent<Rigidbody2D>();
        _myColli = GetComponent<Collider2D>();
    }
    public virtual void Born(Object data = null)
    {
        currSpeed = orginSpeed;
        _isDead = false;
        _health.Init();
    }

    public abstract void Move();
    public abstract IEnumerator EffectDie();
    public virtual void Died()
    {
        StartCoroutine(EffectDie());
    }
    public virtual void DiedImmediate()
    {
        gameObject.SetActive(false);
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
        currSpeed *= values;
        currSpeed.x = Mathf.Clamp(currSpeed.x, _minSpeed, _maxSpeed);
    }
    public void SetSpeed(Vector2 values)
    {
        currSpeed = values;
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
public enum ObjEFFECT
{
    NONE,
    BURNING,
    FREEZE,
    SHOKING,
    POISON,
    EXPLOSION
}