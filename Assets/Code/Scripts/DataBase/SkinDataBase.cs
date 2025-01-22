using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDataBase", menuName = "DataBase/Skins", order = 1)]
public class SkinDataBase : ScriptableObject
{
    public List<SkinData> datas = new();



}