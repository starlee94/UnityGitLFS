using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Move",menuName ="Pokemon/Create new Move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] string description;

    [SerializeField] PokemonType type;

    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

    public string Name { get { return name; } }
    public PokemonType Type { get { return type; } }
    public string Description { get { return description; } }
    public int Power { get { return power; } }
    public int Accuracy { get { return accuracy; } }
    public int PP { get { return pp; } }
    
    public bool IsSpecial
    {
        get
        {
            if (type == PokemonType.Fire || type == PokemonType.Water || type == PokemonType.Grass
                || type == PokemonType.Ice || type == PokemonType.Electric || type == PokemonType.Dragon)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
