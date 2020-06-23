using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public string PlantId = "";

    private bool activate = false;
    public bool ReadyForHarvest = false;
    public bool Withered = false;

    [Header("Growth Timers")]
    [SerializeField]
    float TimeToGrowFullSize = 10;
    [SerializeField]
    float FinishedSize = 1.0f;
    [SerializeField]
    float TimeToWither = 10;

    Transform plantSize;
    Vector3 growthVector = new Vector3(1, 0.1f, 1);

    float increaseSize = 0;
    float wither = 0;


    void Start()
    {
        plantSize = gameObject.GetComponent<Transform>();
        plantSize.transform.localScale = growthVector;
    }

    void Update()
    {
        Grow();

        if (ReadyForHarvest)
            Wither();

        PositionOffset();
    }

    //Keeps the object on ground level
    private void PositionOffset()
    {
        Vector3 offset = Vector3.zero;
        offset.y = plantSize.transform.localScale.y / 2;
        plantSize.position = offset;
    }

    private void Grow()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            activate = true;

        if (activate)
            increaseSize += FinishedSize / TimeToGrowFullSize  * Time.deltaTime;

        if (increaseSize >= FinishedSize)
        {
            increaseSize = FinishedSize;
            activate = false;
            ReadyForHarvest = true;
        }

        growthVector.y = increaseSize;
        plantSize.transform.localScale = growthVector;
    }

    private void Wither()
    {
        wither += 1 / TimeToWither * Time.deltaTime;

        if(wither >= 1)
        {
            Withered = true;
        }

    }
}
