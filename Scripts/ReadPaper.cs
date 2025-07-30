using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class ReadPaper : MonoBehaviour
{
    [SerializeField] Transform readTransform;
    [SerializeField] Transform tabledTransfrom;
    [SerializeField] Transform paperTransform;
    [SerializeField] Camera cam;
    [SerializeField] float speed; 
    [SerializeField] bool reading;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); 
        if (Physics.Raycast(ray,out RaycastHit hitInfo) && Input.GetMouseButtonDown(0))
        {
            if (hitInfo.transform.position == paperTransform.position)
            {
                reading = !reading;
                //reading = true; 
            }
        }

        if (reading)
        {
            MoveToRead(); 
        }
        if (!reading)
        {
            MoveToTable();
        }

    }

    private void MoveToRead()
    {
        paperTransform.position = Vector3.MoveTowards(paperTransform.position, readTransform.position, Time.deltaTime * speed);
        paperTransform.rotation = readTransform.rotation;
        transform.position = paperTransform.position;


    }
    private void MoveToTable()
    {
        paperTransform.position = Vector3.MoveTowards(paperTransform.position, tabledTransfrom.position, Time.deltaTime * speed);
        paperTransform.rotation = tabledTransfrom.rotation;
        transform.position = paperTransform.position;
    }


}
