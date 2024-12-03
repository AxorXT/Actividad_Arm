using System.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    //ruta donde se guardara el archivo JSON
    private string filePath = "data.json";

    //crear un objeto de la clase data
    public Data data = new Data();

    public TextMeshProUGUI cantidadText;

    public void SaveData()
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
        Debug.Log("Datos guardados");
    }

    public void LoadData() 
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(json);
            Debug.Log("Datos cargados: " + data.cantidad);
            UpdateCantidadText();
        }
        else
        {
            Debug.Log("No se encontro el archivo");
        }
    }

    public void UpdateCantidadText()
    {
        cantidadText.text = data.cantidad.ToString("00");
    }

    public void sumar()
    {
        data.cantidad = data.cantidad + 1;
    }

    public void resta()
    {
        data.cantidad = data.cantidad - 1;
    }

    private void Update()
    {
        UpdateCantidadText();
    }
}
