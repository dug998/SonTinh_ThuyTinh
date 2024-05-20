using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_BulletWizard : ST_BulletRegular
{
    public float _timeDisable = 1;
    private void OnEnable()
    {
        Invoke(nameof(Died), _timeDisable);
    }
    public override void CollideWithMonsters(GameObject obj)
    {
        ObjectBase monsterHealth = obj.GetComponent<ObjectBase>();
        monsterHealth.ReceiveDame(-monsterHealth.GetHealthBase().GetMaxHealth());
        //Instantiate(_effect, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        //_effect.transform.localScale = Vector2.one * 0.5f;
    }
    public override void Move()
    {
    }

}
