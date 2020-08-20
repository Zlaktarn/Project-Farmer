using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootObject : MonoBehaviour
{
    public int lootId;

    [SerializeField]
    float yRotation = 3;

    Vector3 rotationVector;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rotationVector = transform.eulerAngles;
        rb = gameObject.GetComponent<Rigidbody>();

        Physics.IgnoreLayerCollision(7,9);
    }

    // Update is called once per frame
    void Update()
    {
        rotationVector.y += yRotation * Time.deltaTime;

        transform.eulerAngles = rotationVector;


    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        transform.up = Vector3.zero;
    }


    public void PickUp()
    {
        print("We found an Item!");

        Looted();
    }

    void Looted()
    {
        Destroy(gameObject);

    }
}
