using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public int addHealt = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.name == "Player")
        {
            GameManager.Instance.AddHealth(addHealt);
            GameObject.Destroy(gameObject);
        }
    }
}
