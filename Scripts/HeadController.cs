using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeadController : MonoBehaviour
{
    public Transform HeadObject, targetObject; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        HeadObject.LookAt(targetObject);
    }
}
