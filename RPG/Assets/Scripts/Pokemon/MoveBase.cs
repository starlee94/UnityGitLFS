using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Move",menuName ="Pokemon/Create new Move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string _name;
    [SerializeField] string description;

    [SerializeField] PokemonType type;

    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;
    [SerializeField] MoveCategory category;
    [SerializeField] MoveEffects effects;
    [SerializeField] MoveTarget target;

    public MoveEffects Effects { get { return effects; } }
    public MoveCategory Category { get { return category; } }
    public MoveTarget Target { get { return target; }}
    public string Name { get { return _name; } }
    public PokemonType Type { get { return type; } }
    public string Description { get { return description; } }
    public int Power { get { return power; } }
    public int Accuracy { get { return accuracy; } }
    public int PP { get { return pp; } }
    


   
}
[System.Serializable]
public class MoveEffects
{
    [SerializeField] List<StatBoost> boosts;


    public List<StatBoost> Boosts { get { return boosts; } }
}

[System.Serializable]
public class StatBoost
{
    public Stat stat;
    public int boost;
}
public enum MoveCategory
{
    Physical, Special, Status
}

public enum MoveTarget
{
    Foe, Self
}