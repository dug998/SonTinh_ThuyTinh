
using System.Collections;
using UnityEngine;

public abstract class ObjectThuyTinh : ObjectBase
{
    [Header(" ___ Object Counterattack ___"), Space(30)]
    [SerializeField] protected GameObject _bulletPref;
    [SerializeField] protected Transform _locationAppears;
    protected bool _isHitting = false, _stand = false;
    [SerializeField] protected float _nextHitting;


    protected ObjEFFECT _objEFFECT;
    [Space]

    [Header("Freeze Option")]
    [HideInInspector] public bool canBeFreeze = true;
    //public float timeFreeze = 5;
    [HideInInspector] public GameObject dieFrozenFX;

    public override void Born(Object data = null)
    {
        base.Born();
        StartCoroutine(Attack());
    }
    public void FixedUpdate()
    {
        Move();
    }
    public override void Move()
    {
        if (_isDead)
        {
            _myBody.velocity = new Vector2(0, _myBody.velocity.y);
            _myAnim.SetBool("walk", false);
            return;
        }
        if (_stand)
        {
            _myBody.velocity = Vector2.zero;
            _myAnim.SetBool("walk", false);
        }
        else
        {
            _myBody.velocity = new Vector2(-currSpeed.x, currSpeed.y);
            _myAnim.SetBool("walk", true);
        }
    }
    public abstract IEnumerator Attack();
    public abstract void SpawnButtlet();
    public override void AffectedByWeather(bool isRain)
    {
        base.AffectedByWeather(isRain);
        if (isRain)
        {
            currSpeed = orginSpeed * 1.1f;
        }
        else
        {
            currSpeed = orginSpeed * 0.9f;
        }
    }
    public override void Died()
    {
        _isDead = true;
        _stand = true;
        base.Died();
    }
    public override IEnumerator EffectDie()
    {
        _myColli.enabled = false;
        SpawnThuyTinh.Instance?.RemoveMonster(this);

        _Dead.PixelGravityDie(1);
        yield return new WaitForSeconds(1.2f);
        gameObject.SetActive(false);
    }
    public override void DiedImmediate()
    {
        _myColli.enabled = false;
        SpawnThuyTinh.Instance?.RemoveMonster(this);
        base.DiedImmediate();
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ObjTag.sonTinh) && collision.isTrigger == true)
        {
            _isHitting = true;
            _stand = true;
        }
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.CompareTag(ObjTag.sonTinh) && collision.isTrigger == true)
        {
            _isHitting = true;
            _stand = true;
        }

    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ObjTag.sonTinh))
        {
            _isHitting = false;
            _stand = false;
        }
    }
    #region  Freeze
    public virtual void Freeze(float time)
    {
        if (_objEFFECT == ObjEFFECT.FREEZE)
            return;

        if (_objEFFECT == ObjEFFECT.BURNING)
        {

        }
        if (_objEFFECT == ObjEFFECT.SHOKING)
        {

        }

        if (canBeFreeze)
        {
            _objEFFECT = ObjEFFECT.FREEZE;
            StartCoroutine(UnFreezeCo(time));
        }
    }
    IEnumerator UnFreezeCo(float time)
    {

        _sprite.color = new Color(0.504717f, 0.6808742f, 1, 1);
        currSpeed = currSpeed * .5f;
        yield return new WaitForSeconds(time);
        _sprite.color = new Color(1, 1, 1, 1);
        currSpeed = orginSpeed;
        _objEFFECT = ObjEFFECT.NONE;
    }
    #endregion
}
