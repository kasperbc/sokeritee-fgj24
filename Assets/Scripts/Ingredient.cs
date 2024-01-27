using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public GameObject self;
    public Transform player;
    //public LayerMask playerLayer;
    //public int plLayer;

    public float destroyTime;
    public string newTag;

    private float score = 0f;

    void Start()
    {
        Invoke("DestoryIngredient", destroyTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            self.transform.SetParent(player);
            self.tag = newTag;
            Debug.Log(self.name + "tag is changed to " + newTag);
            //self.gameObject.layer = playerLayer;

            //RaycastHit hit;
            //if (Physics.Raycast(self.transform.position, (transform.position - self.transform.position).normalized, out hit, Mathf.Infinity, playerLayer))
            //{
            //    self.transform.forward = hit.normal;
            //    self.transform.position = hit.point;
            //    self.transform.position = self.transform.position + (self.transform.forward * self.transform.localScale.z) * 0.5f;
            //}
        }
    }
    private void DestoryIngredient()
    {
        if (self.tag == "Item")
        {
            Destroy(self);
        }
    }

    //private void ScoreCalculation()
    //{
    //    score = 
    //}
}
