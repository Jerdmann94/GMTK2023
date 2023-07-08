using System.Linq;
using System.Reflection;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int strength;
    [SerializeField] private int intelligence;
    [SerializeField] private int dexterity;
    [SerializeField] private int life;

    public int Intelligence
    {
        get => intelligence;
        set => intelligence = value;
    }

    public int Dexterity
    {
        get => dexterity;
        set => dexterity = value;
    }

    public int Life
    {
        get => life;
        set => life = value;
    }

    public int Strength
    {
        get => strength;
        set => strength = value;
    }

    public PropertyInfo getKeyPropertyInfo(string key)
    {
        var t = this.GetType();
        var props = t.GetProperties().ToList();
        var k = props.Find(p => p.Name == key);

        Debug.Log("key " + key + " property " + k.Name);
        return k;
    }
}