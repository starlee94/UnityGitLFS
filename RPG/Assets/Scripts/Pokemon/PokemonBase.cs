using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Pokemon", menuName ="Pokemon/Create new Pokemon")]
public class PokemonBase : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] string _name;

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

    public PokemonType Type1 { get { return type1; } }
    public PokemonType Type2 { get { return type2; } }

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


public enum Stat
{
    Attack,
    Defense,
    SpAttack,
    SpDefense,
    Speed
}
public class TypeChart
{
    static float[][] chart =
    {
        //                NOR FIR WAT ELE GRA ICE FIG POI GRO FLY PSY BUG ROC GHO
     /*NOR*/ new float[]{ 1f,1f,1f,1f,1f,1f,1f,1f,1f,1f,1f,1f,0.5f,0f},
     /*FIR*/ new float[]{ 1f,0.5f,0.5f,1f,2f,2f,1f,1f,1f,1f,1f,2f,0.5f,1f},
     /*WAT*/ new float[]{ 1f,2f,0.5f,1f,0.5f,1f,1f,1f,2f,1f,1f,1f,2f,1f},
     /*ELE*/ new float[]{ 1f,2f,0.5f,0.5f,1f,1f,1f,0f,2f,1f,1f,1f,1f,1f},
     /*GRA*/ new float[]{ 1f,0.5f,2f,1f,0.5f,1f,1f,0.5f,2f,0.5f,1f,0.5f,2f,1f},
     /*ICE*/ new float[]{ 1f,0.5f,0.5f,1f,2f,0.5f,1f,1f,2f,2f,1f,1f,1f,1f},
     /*FIG*/ new float[]{ 2f,1f,1f,1f,1f,2f,1f,0.5f,1f,0.5f,0.5f,0.5f,2f,0f},
     /*POI*/ new float[]{ 1f,1f,1f,1f,2f,1f,1f,0.5f,0.5f,1f,1f,1f,0.5f,0.5f},
     /*GRO*/ new float[]{ 1f,2f,1f,2f,0.5f,1f,1f,2f,0f,1f,0.5f,2f,1f,1f},
     /*FLY*/ new float[]{ 1f,1f,1f,0.5f,2f,1f,2f,1f,1f,1f,1f,2f,0.5f,1f},
     /*PSY*/ new float[]{ 1f,1f,1f,1f,1f,1f,2f,2f,1f,1f,0.5f,1f,1f,1f},
     /*BUG*/ new float[]{ 1f,0.5f,1f,1f,2f,1f,0.5f,0.5f,1f,0.5f,2f,1f,1f,0.5f},
     /*ROC*/ new float[]{ 1f,2f,1f,1f,1f,2f,0.5f,1f,0.5f,2f,1f,2f,1f,1f},
     /*GHO*/ new float[]{ 0f,1f,1f,1f,1f,1f,1f,1f,1f,1f,2f,1f,1f,2f},
    };

    public static float GetEffectiveness(PokemonType attackType, PokemonType defenseType)
    {
        if (attackType == PokemonType.None || defenseType == PokemonType.None) return 1;
        int row = (int)attackType - 1;
        int col = (int)defenseType - 1;

        return chart[row][col];
    }
}

