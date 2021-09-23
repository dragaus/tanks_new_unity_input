using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankColour : MonoBehaviour
{
    public Transform meshRendererManager;
    //public Material tankColour;
    public Material[] tankCoulours;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < meshRendererManager.childCount; i++)
        {
            var child = meshRendererManager.GetChild(i);
            MeshRenderer mesh = child.GetComponent<MeshRenderer>();
            if (mesh == null) continue;
            Material[] mats = mesh.materials;
            mats[0] = tankCoulours[i];
            mesh.materials = mats;
        }

        //foreach (Transform child in meshRendererManager)
        //{
        //    MeshRenderer mesh = child.GetComponent<MeshRenderer>();

        //    //Esto no funciona hasta esta version
        //    //mesh.materials[0] = tankColour;
        //    Material[] mats = mesh.materials;
        //    mats[0] = tankColour;
        //    mesh.materials = mats;
        //}
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
