using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupReward : PopupBase
{
    public override void Show(object data = null)
    {
        base.Show(data);
        List<Reward> rewards = (List<Reward>)data;
        foreach (Reward reward in rewards)
        {

        }
    }
    public void GetReward(Reward reward)
    {
        switch (reward.typeReward)
        {
            case TypeReward.gold:
                UserData.GoldGame += reward.valuesRw;
                break;
            case TypeReward.gem:
                UserData.GemGame += reward.valuesRw;
                break;

        }
    }
}
