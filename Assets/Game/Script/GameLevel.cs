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
    void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, _layerMask);

        if (hit.collider != null && hit.collider.CompareTag("Gold"))
        {
            hit.collider.GetComponent<Coin>()?.TakeCoin(PopupGamePlay._posCoin);
        }

    }
}
