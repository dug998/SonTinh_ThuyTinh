using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPickax : MonoBehaviour
{
    public static BlockLand currBlockLand;
    public void SetPos(Vector2 pos)
    {
        transform.position = pos;
    }
    public void StartUse()
    {
        currBlockLand = null;
    }
    public void CompleteUse()
    {
        if (currBlockLand == null)
        {

            Debug.Log("null");
            return;
        }

        Debug.Log("remove");
        currBlockLand.RemoveChildren();
        currBlockLand = null;   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            Debug.Log(collision.name);
            BlockLand block = collision.gameObject.GetComponent<BlockLand>();
            if (block != null)
            {
                currBlockLand = block;
            }
        }
    }
}
