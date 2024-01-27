using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    private Transform player;
    //public LayerMask playerLayer;
    //public int plLayer;

    public float destroyTime = 3f;

    public float score = 0f;

    private bool inAir = true;
    
    const float fallSpeed = 9.91f;
    const float terminalVelocity = 20;
    private float grav;

    private Vector3 floorHitPos;

    public AudioSource collectItem;

    void Start()
    {        
        if (GameObject.FindWithTag("Player"))
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (inAir)
        {
            Fall();
        }
        else if (CompareTag("Item"))
        {
            Rotate();
        }
    }

    private void Fall()
    {
        // increase gravity
        grav += Time.deltaTime * fallSpeed;
        grav = Mathf.Clamp(grav, 0, terminalVelocity);

        transform.Translate(Vector3.down * grav * Time.deltaTime, Space.World);

        Ray ray = new(transform.position, Vector3.down);
        bool raycastHit = Physics.Raycast(ray, 1f, LayerMask.GetMask("Ground"));

        if (raycastHit) 
        {
            OnHitFloor();
        }
    }

    // risto would be proud
    private void Rotate()
    {
        transform.position = new Vector3(floorHitPos.x, floorHitPos.y + (Mathf.Sin(Time.time * 2) / 4), floorHitPos.z);
        transform.Rotate(Vector3.up * 0.5f, Space.World);
    }

    private void OnHitFloor()
    {
        Invoke(nameof(DestoryIngredient), destroyTime);
        inAir = false;
        floorHitPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.root.gameObject.name == "Player")
        {
            transform.SetParent(other.transform);
            tag = "CollectedItem";
            Debug.Log(name + "tag is changed to CollectedItem");
            collectItem.Play();
            Destroy(GetComponent<Collider>());
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
        if (CompareTag("Item"))
        {
            Destroy(gameObject);
        }
    }
}
