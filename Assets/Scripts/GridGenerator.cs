using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject plane;
    GameObject prevObj;
    [SerializeField] private GameObject cubePref;
    void Start()
    {
        for(int x = 0; x < 10; x++){
            for(int z = 0; z < 10; z++){
                Instantiate(plane, new Vector3(x, 0, z), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)){
            GameObject obj = hit.collider.gameObject;
            if(obj.CompareTag("floor")){
                if(prevObj == null){
                    obj.GetComponent<MeshRenderer>().material.color = Color.green;
                    prevObj = obj;
                }else if(!prevObj.Equals(obj)){
                    prevObj.GetComponent<MeshRenderer>().material.color = Color.white;
                    prevObj = null;
                }
                if(Input.GetMouseButtonDown(0)){
                    Vector3 pos = obj.transform.position + new Vector3(0, 0.5f, 0);
                    Instantiate(cubePref, pos, Quaternion.identity);
                }
            }
        }
    }
}
