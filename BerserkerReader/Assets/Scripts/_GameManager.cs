using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GameManager : MonoBehaviour
{
    public float illumination, inteligence, readQuality, autoRead;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpgradeIllumination()
    {
        print("okIl");
    }
    public void UpgradeInteligence()
    {
        print("okIn");

    }
    public void UpgradeReadQuality()
    {
        print("okRQ");

    }
    public void UpgradeAutoRead()
    {
        print("okAR");

    }



}
