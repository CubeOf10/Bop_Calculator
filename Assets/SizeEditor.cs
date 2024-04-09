using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SizeEditor : MonoBehaviour
{
    public GridManager gridManager;
    public TextMeshProUGUI rowsText;
    public TextMeshProUGUI columnsText;
    void Start()
    {
    }

    public void UpCol()
    {
        gridManager.col++;
        columnsText.text = gridManager.col.ToString();
    }
    public void UpRow(){
        gridManager.row++;
        rowsText.text = gridManager.row.ToString();
    }

    public void DownCol(){
        gridManager.col--;
        columnsText.text = gridManager.col.ToString();
    }
    public void DownRow(){
        gridManager.row--;
        rowsText.text = gridManager.row.ToString();
    }

}
