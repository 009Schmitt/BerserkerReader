using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class _GameManager : MonoBehaviour
{

    public Material mat1, mat2, mat3, mat4;

    public Transform pupilPosition;
    public float readQuantity;
    public GameObject upgrade1, upgrade2, upgrade3, upgrade4;

    public SpriteRenderer bookColor;
    public float sapiens, score;
    public Text sapiensText, scoreText;

    public float contador;
    public float illumination, inteligence, readQuality, autoRead;
    public float illuminationCost, inteligenceCost, readQualityCost, autoReadCost;

    private float actualTime, autoReadCooldown;

    // Start is called before the first frame update
    void Start()
    {
        ReadFile();
        actualTime = 0;
        autoReadCooldown = 2;
        readQuantity = 0;
        contador = 0;
        illuminationCost = 14;
        inteligenceCost = 14;
        readQualityCost = 14;
        autoReadCost = 14;
    }

    // Update is called once per frame
    void Update()
    {
        pupilPosition.position = new Vector3(-(readQuantity / 100), pupilPosition.position.y, -70);
        if (pupilPosition.position.x < -1.2f)
        {
            pupilPosition.position = new Vector3(0, pupilPosition.position.y, -70);
            readQuantity = 0;
            //3 * (((Inteligence*2)/3) + (ilummination + 1))
            sapiens += (3 * ((((inteligence + 1) * 2)) + (illumination + 1)));
            //100 + (inteligence³)
            score += 100 + (Mathf.Pow(inteligence, 3));

            // Change Book Color
            contador++;
            if (contador > 3)
            {
                bookColor.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                contador = 0;
            }
        }

        //Auto Read Formula
        if (autoRead > 0 && actualTime < Time.time)
        {
            readQuantity += 5;
            if ((Time.time + (autoReadCooldown - (autoRead / 35))) < (Time.time + 0.1f))
            {
                actualTime = Time.time + 0.1f;
            }
            else
            {
                actualTime = Time.time + (autoReadCooldown - (autoRead / 35));
            }
        }

        //ExitGame
        if (Input.GetKey(KeyCode.Escape))
        {
            WriteFile();
            Application.Quit();
        }

        //Block size change

        BlockSize();
        AtualizaText(sapiens, score);
    }

    private void BlockSize()
    {
        upgrade1.transform.localScale = new Vector3(((sapiens * 100) / autoReadCost) / 100, 0.2f, 1);
        if (upgrade1.transform.localScale.x > 1)
        {
            upgrade1.transform.localScale = new Vector3(1, 0.2f, 1);
            mat1.color = Color.green;
        }
        else
        {
            mat1.color = Color.red;
        }

        upgrade2.transform.localScale = new Vector3(((sapiens * 100) / illuminationCost) / 100, 0.2f, 1);
        if (upgrade2.transform.localScale.x > 1)
        {
            upgrade2.transform.localScale = new Vector3(1, 0.2f, 1);
            mat2.color = Color.green;
        }
        else
        {
            mat2.color = Color.red;
        }

        upgrade3.transform.localScale = new Vector3(((sapiens * 100) / inteligenceCost) / 100, 0.2f, 1);
        if (upgrade3.transform.localScale.x > 1)
        {
            upgrade3.transform.localScale = new Vector3(1, 0.2f, 1);
            mat3.color = Color.green;
        }
        else
        {
            mat3.color = Color.red;
        }

        upgrade4.transform.localScale = new Vector3(((sapiens * 100) / readQualityCost) / 100, 0.2f, 1);
        if (upgrade4.transform.localScale.x > 1)
        {
            upgrade4.transform.localScale = new Vector3(1, 0.2f, 1);
            mat4.color = Color.green;
        }
        else
        {
            mat4.color = Color.red;
        }
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
        readQuantity += (8 + (readQuality));
    }

    private float CostCalculation(float lvl)
    {
        lvl++;
        return (lvl * lvl) + 10;
    }

    public void UpgradeIllumination()
    {
        // (lvl * 4) + 10
        if (sapiens > illuminationCost)
        {
            illumination++;
            sapiens -= illuminationCost;
            illuminationCost = CostCalculation(illumination);
        }
    }
    public void UpgradeInteligence()
    {
        if (sapiens > inteligenceCost)
        {
            inteligence++;
            sapiens -= inteligenceCost;
            inteligenceCost = CostCalculation(inteligence);
        }

    }
    public void UpgradeReadQuality()
    {
        if (sapiens > readQualityCost)
        {
            readQuality++;
            sapiens -= readQualityCost;
            readQualityCost = CostCalculation(readQuality);
        }
    }
    public void UpgradeAutoRead()
    {
        if (sapiens > autoReadCost)
        {
            autoRead++;
            sapiens -= autoReadCost;
            autoReadCost = CostCalculation(autoRead);
        }

    }

    private void ReadFile()
    {
        string path = Application.dataPath + "/Save/SaveFile.txt";
        string text = "";

        if (File.Exists(path))
        {
            text = File.ReadAllText(path);
        }

        string[] vetor = text.Split(':');
        score = CI(vetor[1]);
        sapiens = CI(vetor[3]);
        autoRead = CI(vetor[5]);
        illumination = CI(vetor[7]);
        inteligence = CI(vetor[9]);
        readQuality = CI(vetor[11]);
    }
    private void WriteFile()
    {
        string path = Application.dataPath + "/Save/SaveFile.txt";
        string[] vetor = new string[]
            {
                $"Scor:{score}:",
                $"Sapi:{sapiens}:",
                $"Auto:{autoRead}:",
                $"Illu:{illumination}:",
                $"Inte:{inteligence}:",
                $"Read:{readQuality}:"
            };

        if (File.Exists(path))
        {
            /*Scor:0:
            Sapi:0:
            Auto:0:
            Illu:0:
            Inte:0:
            Read:0:
            */
            File.WriteAllLines(path, vetor);
        }
        else
        {
            File.Create(path);
            File.WriteAllLines(path, vetor);
        }

    }

    private int CI(string value)
    {
        return int.Parse(value);
    }


}
