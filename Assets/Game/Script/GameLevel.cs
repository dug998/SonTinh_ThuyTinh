using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    public Grounds _grounds;
    public FactoryCoin _factoryCoin;
    [SerializeField] SpawnThuyTinh _pawnThuyTinh;
    public Camera _camera;
    public LayerMask _layerMask;
    public ObjPickax _objPickax;
    public bool _canUsePickax;
    private void Awake()
    {
        _camera = Camera.main;
    }
    public void Init(DataLevel dataLevel)
    {
        _grounds.SpawnBlocks();
        _factoryCoin.SpawnCoins();
        StartCoroutine(_pawnThuyTinh.CreateArmyList(dataLevel));
    }
    Ray ray;
    RaycastHit2D hit;
    void Update()
    {
         ray = _camera.ScreenPointToRay(Input.mousePosition);
         hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, _layerMask);

        if (hit.collider != null && hit.collider.CompareTag("Gold"))
        {
            hit.collider.GetComponent<Coin>()?.TakeCoin(PopupGamePlay._posCoin);
        }
        if (_canUsePickax)
        {

            _objPickax.SetPos(_camera.ScreenToWorldPoint(Input.mousePosition));
            if (Input.GetMouseButtonUp(0))
            {
                CompleteUsePickax();
            }
        }

    }
    public void UsePickax()
    {
        if (_canUsePickax)
        {
            return;
        }
        Debug.Log("use");
        _canUsePickax = true;
        _objPickax.SetPos(_camera.ScreenToWorldPoint(Input.mousePosition));
        _objPickax.StartUse();
        _objPickax.gameObject.SetActive(true);

    }
    public void CompleteUsePickax()
    {
        if (!_canUsePickax)
        {
            return;
        }
        _canUsePickax = false;
        _objPickax.CompleteUse();
        _objPickax.gameObject.SetActive(false);
    }
}
