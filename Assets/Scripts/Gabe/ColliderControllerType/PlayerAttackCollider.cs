using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    public float damage;

    public virtual void OnTriggerStay2D(Collider2D other)
    {
        print(other);
        if (gameObject.activeSelf == true && other.tag == "Enemy")
        {
            print("hit");
            other.gameObject.GetComponent<Enemy>().Attacked(damage);
        }
    }
}
