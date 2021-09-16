using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _GameManager : MonoBehaviour
{


    public Transform pupilPosition;
    public float readQuantity;

    public SpriteRenderer bookColor;
    public float sapiens, score;
    public Text sapiensText, scoreText;

    public float contador;
    public float illumination, inteligence, readQuality, autoRead;
    public float illuminationCost, inteligenceCost, readQualityCost, autoReadCost;


    // Start is called before the first frame update
    void Start()
    {
        readQuantity = 0;
        sapiens = 0;
        score = 0;
        contador = 0;
        illuminationCost = 14;
        inteligenceCost = 14;
        readQualityCost = 14;
        autoReadCost = 14;
    }

    // Update is called once per frame
    void Update()
    {
        pupilPosition.position = new Vector2(-(readQuantity / 100), pupilPosition.position.y);
        if (pupilPosition.position.x < -1.2f)
        {
            pupilPosition.position = new Vector2(0, pupilPosition.position.y);
            readQuantity = 0;
            //3 * (((Inteligence*2)/3) + (ilummination + 1))
            sapiens += (3 * ((((inteligence + 1) * 2)) + (illumination + 1)));
            //100 + (inteligence³)
            score += 100 + (Mathf.Pow(inteligence, 3));
            contador++;
            if (contador > 2)
            {
                bookColor.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                contador = 0;
            }
        }
        AtualizaText(sapiens, score);

    }

    //public Color ChoseColorBook()
    //{
    //    int choice = Random.Range(0, 8);
    //    if (choice == 0)
    //    {
    //        return Color.red;
    //    }
    //    else if (choice == 1)
    //    {
    //        return Color.blue;
    //    }
    //    else if (choice == 2)
    //    {
    //        return Color.gray;
    //    }
    //    else if (choice == 3)
    //    {
    //        return Color.yellow;
    //    }
    //    else if (choice == 4)
    //    {
    //        return Color.green;
    //    }
    //    else if (choice == 5)
    //    {
    //        return Color.magenta;
    //    }
    //    else
    //    {
    //        return Color.cyan;
    //    }
    //}


    public void AtualizaText(float sa, float sc)
    {
        sapiensText.text = sa.ToString();
        scoreText.text = sc.ToString();
    }

    public void PlayerClick()
    {
        readQuantity += (10 + (readQuality * 2));
    }

    public void UpgradeIllumination()
    {
        // (lvl * 4) + 10
        if (sapiens > illuminationCost)
        {
            illumination++;
            sapiens -= illuminationCost;
            illuminationCost = (illumination * 4) + 10;
        }
    }
    public void UpgradeInteligence()
    {
        if (sapiens > inteligenceCost)
        {
            inteligence++;
            sapiens -= inteligenceCost;
            inteligenceCost = (inteligence * 4) + 10;
        }

    }
    public void UpgradeReadQuality()
    {
        if (sapiens > readQualityCost)
        {
            readQuality++;
            sapiens -= readQualityCost;
            readQualityCost = (readQuality * 4) + 10;
        }
    }
    public void UpgradeAutoRead()
    {
        if (sapiens > autoReadCost)
        {
            autoRead++;
            sapiens -= autoReadCost;
            autoReadCost = (autoRead * 4) + 10;
        }

    }


}
