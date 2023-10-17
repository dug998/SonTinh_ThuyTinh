using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThuyTinh : MonoBehaviour
{
    [SerializeField] GameObject _parrent;
    public List<GameObject> _listArmy;
    List<Vector2> _location;
    public IEnumerator CreateArmyList()
    {
        _location = Grounds._rowLocation;
        while (true)
        {
            levelEasy(_listArmy[0]);
            yield return new WaitForSeconds(5);
        }


    }
    public void levelEasy(GameObject mob1)
    {
        int check = Random.Range(0, 5);
        GameObject obj = Instantiate(mob1, new Vector2(_location[check].x, _location[check].y + .5f), Quaternion.identity, _parrent.transform);
        obj.GetComponent<ObjectAttackTT>().Born();
    }
}
