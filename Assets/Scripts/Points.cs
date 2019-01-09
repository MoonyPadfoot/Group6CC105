using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.CompareTag("Player"))
       {
           
           GameObject smokeEffect = ObjectPooling.instance.GetPooledObject("SparkleEffect");
           smokeEffect.transform.position = transform.position;
           smokeEffect.SetActive(true);
           smokeEffect.GetComponent<Animator>().Play("SparkleEffect", -1, 0);
           gameObject.SetActive(false);
            Debug.Log("adsfadsf");
       }
   }
}
