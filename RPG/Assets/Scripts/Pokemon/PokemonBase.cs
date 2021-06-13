using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Pokemon", menuName ="Pokemon/Create new Pokemon")]
public class PokemonBase : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;

    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;

    [SerializeField] List<LeanableMove> leanableMoves;

    public Sprite FrontSprite { get { return frontSprite; } }
    public Sprite BackSprite { get { return backSprite; } }

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public int MaxHp { get { return maxHp;  } }
    public int Attack { get { return attack; } }
    public int Defense { get { return defense; } }
    public int SpAttack { get { return spAttack; } }
    public int SpDefense { get { return spDefense; } }
    public int Speed { get { return speed; } }
    public List<LeanableMove> LearnableMoves { get { return leanableMoves; } }
}

[System.Serializable]
public class LeanableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base { get { return moveBase; } }
    public int Level { get { return level; } }
     
}
public enum PokemonType
{
    None,
    Normal, 
    Fire, 
    Water, 
    Electric, 
    Grass, 
    Ice, 
    Fighting, 
    Poison, 
    Ground, 
    Flying, 
    Psychic, 
    Bug, 
    Rock, 
    Ghost, 
    Dragon

}

