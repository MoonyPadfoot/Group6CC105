using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.CompareTag("Player"))
       {
           
           GameObject smokeEffect = ObjectPooling.instance.GetPooledObject("SmokeEffect");
           smokeEffect.transform.position = transform.position;
           smokeEffect.SetActive(true);
           smokeEffect.GetComponent<Animator>().Play("SmokeEffect", -1, 0);
           gameObject.SetActive(false);
            Debug.Log("hadsft");
       }
       
   }
}
