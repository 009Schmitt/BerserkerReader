using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtons : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void IlluminationButton()
    {
        FindObjectOfType<_GameManager>().UpgradeIllumination();
    }
    public void InteligenceButton()
    {
        FindObjectOfType<_GameManager>().UpgradeInteligence();
    }
    public void ReadQualityButton()
    {
        FindObjectOfType<_GameManager>().UpgradeReadQuality();
    }
    public void AutoReadButton()
    {
        FindObjectOfType<_GameManager>().UpgradeAutoRead();
    }
}
