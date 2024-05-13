using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  Tiêu diệt 1 hàng địch
/// </summary>
public class ST_BulletFlame : ST_BulletRegular
{
    public override void Born(Object data = null)
    {
        base.Born(data);
        Invoke(nameof(DestroyImmediate), 3);
    }
    public override void CollideWithMonsters(GameObject obj)
    {
        ObjectBase monsterHealth = obj.GetComponent<ObjectBase>();
        monsterHealth.UpdateHealth(-monsterHealth.GetHealthBase().GetMaxHealth());
        Instantiate(_effect, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        _effect.transform.localScale = Vector2.one * 0.5f;
    }
}
