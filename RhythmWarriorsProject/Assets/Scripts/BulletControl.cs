using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField]
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == Tags.PLAYER1_TAG || target.tag == Tags.PLAYER2_TAG ||
            target.tag == Tags.WALL_TAG)
        {
            //gameObject.SetActive(false);
            GameObject.Destroy(gameObject);
        }

        WarriorController wc = target.GetComponent<WarriorController>();
        if(wc != null)
        {
            wc.TakeDamage(damage);
        }
    }
}
