using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ObjectDefense : ObjectBase
{
    public override void UpdateHealth(int values)
    {
        base.UpdateHealth(values);
        StatusObjHealth();
    }
    public abstract void StatusObjHealth();

}
