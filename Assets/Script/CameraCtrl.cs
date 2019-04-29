using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float boundY = 3.6f;
    float offsetY;
    void Start()
    {
        offsetY = transform.position.y - player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        SetPos();
    }
    void SetPos()
    {

        if (player.position.y - transform.position.y > boundY)
        {
             
            transform.position = new Vector3(transform.position.x, player.position.y - boundY, -10);

        }
        else if (player.position.y - transform.position.y < -boundY)
        {
       //if (transform.position.y <= 0)
       //     return;
       //     transform.position = new Vector3(transform.position.x, player.position.y + boundY, -10);

        }
    }
}
