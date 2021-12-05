using System.Collections;
using System.Collections.Generic;
using UnityEngine;



///<summary>
///Classe que indica os tipos diferentes de item
///</summary>
[CreateAssetMenu(menuName = "Item")] //Cria um menu item
public class Item : ScriptableObject
{
    public string NomeObjeto; //Nome do item
    public Sprite sprite; //Sprite do item
    public int quantidade; //quantidade daquele item
    public bool empilhavel; //Se esse tipo pode ser armazenado no mesmo slot

    public enum TipoItem
    {
        MOEDA,
        HEALTH,
        GEM1,
        GEM2,
        GEM3,
        GEM4,
        GEM5,
        POWERUP
    }
    public TipoItem tipoItem; //Tipo do item
}
