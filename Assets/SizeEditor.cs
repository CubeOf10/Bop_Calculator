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
        columnsText.text = gridManager.col.ToString();
        rowsText.text = gridManager.row.ToString();
    }

    public void UpCol()
    {
        if(gridManager.col < 5)
        {
            gridManager.col++;
            columnsText.text = gridManager.col.ToString();
        }
    }
    public void UpRow(){
        if(gridManager.row < 5)
        {
            gridManager.row++;
            rowsText.text = gridManager.row.ToString();
        }
    }

    public void DownCol(){
        if(gridManager.col > 2)
        {
            gridManager.col--;
            columnsText.text = gridManager.col.ToString();
        }
    }
    public void DownRow(){
        if(gridManager.row > 2)
        {
            gridManager.row--;
            rowsText.text = gridManager.row.ToString();
        }
    }

}
