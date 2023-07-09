using System.Linq;
using System.Reflection;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public GameManager gameManager;

    //for ui display
    public PlayerStatUIManager playerStatUIManager;

    //STATS
    [SerializeField] private int strength;
    [SerializeField] private int intelligence;

    [SerializeField] private int dexterity;

    //temp stats
    private int tempStrength;
    private int tempIntelligence;
    private int tempDexterity;

    //RESOURCES
    [SerializeField] private int mana;
    [SerializeField] private int life;
    [SerializeField] private int gold;
    [SerializeField] private int food;

    //ITEMS / CONSUMABLES
    [SerializeField] private bool royalSeal1;
    [SerializeField] private bool royalSeal2;
    [SerializeField] private bool royalSeal3;
    [SerializeField] private bool mindlessBody;
    [SerializeField] private bool ironKey;
    [SerializeField] private bool prometheus;
    [SerializeField] private bool goblin;


    public void clearTempStats()
    {
        tempDexterity = 0;
        tempIntelligence = 0;
        tempStrength = 0;
    }

    public int Mana
    {
        get => mana;
        set
        {
            mana = value;
            playerStatUIManager.SetStats();
        }
    }


    public int Intelligence
    {
        get => intelligence + intelligence;
        set
        {
            intelligence = value;
            Debug.Log("Intelligence " + Intelligence);
            playerStatUIManager.SetStats();
        }
    }

    public int Dexterity
    {
        get => dexterity + tempDexterity;
        set
        {
            dexterity = value;
            Debug.Log("Dexterity " + Dexterity);
            playerStatUIManager.SetStats();
        }
    }

    public int Strength
    {
        get => strength + tempStrength;
        set
        {
            strength = value;
            Debug.Log("Strength " + Strength);
            playerStatUIManager.SetStats();
        }
    }

    public int TempStrength
    {
        get => tempStrength;
        set
        {
            tempStrength = value;
            playerStatUIManager.SetStats();
        }
    }

    public int TempIntelligence
    {
        get => tempIntelligence;
        set
        {
            tempIntelligence = value;
            playerStatUIManager.SetStats();
        }
    }

    public int TempDexterity
    {
        get => tempDexterity;
        set
        {
            tempDexterity = value;
            playerStatUIManager.SetStats();
        }
    }

    public int Life
    {
        get => life;
        set
        {
            checkGameEnd(food);
            life = value;
            playerStatUIManager.SetStats();
        }
    }

    public int Food
    {
        get => food;
        set
        {
            food = value;
            checkGameEnd(food);
            playerStatUIManager.SetStats();
        }
    }

    public int Gold
    {
        get => gold;
        set
        {
            gold = value;
            playerStatUIManager.SetStats();
        }
    }

    public bool MindlessBody
    {
        get => mindlessBody;
        set => mindlessBody = value;
    }

    public bool RoyalSeal1
    {
        get => royalSeal1;
        set => royalSeal1 = value;
    }

    public bool RoyalSeal2
    {
        get => royalSeal2;
        set => royalSeal2 = value;
    }

    public bool RoyalSeal3
    {
        get => royalSeal3;
        set => royalSeal3 = value;
    }

    public bool IronKey
    {
        get => ironKey;
        set => ironKey = value;
    }

    public bool Prometheus
    {
        get => prometheus;
        set => prometheus = value;
    }

    public bool Goblin
    {
        get => goblin;
        set => goblin = value;
    }


    public PropertyInfo getKeyPropertyInfo(string key)
    {
        Debug.Log(key);
        var t = this.GetType();
        var props = t.GetProperties().ToList();
        var k = props.Find(p => p.Name == key);

//        Debug.Log("key " + key + " property " + k.Name);
        return k;
    }

    private void checkGameEnd(int i)
    {
        if (i < 1)
        {
            gameManager.gameLost();
        }
    }

    public void initStats()
    {
        doRandomStats();
        clearTempStats();
        mana = 0;
        life = 6;
        gold = 0;
        food = 4;
        royalSeal1 = false;
        royalSeal2 = false;
        royalSeal3 = false;
        mindlessBody = false;
        ironKey = false;
        prometheus = false;
        goblin = false;
        playerStatUIManager.SetStats();
    }

    private void doRandomStats()
    {
        Strength = 0;
        Intelligence = 0;
        Dexterity = 0;
        Debug.Log(" dex " + Dexterity + " str " +
                  Strength + " int " + Intelligence);
        //strength int dex
        //fighter rogue wizard
        var stats = new[,]
        {
            {
                3, 2, 1
            },
            {
                2, 1, 3
            },
            {
                1, 3, 2
            }
        };
        var s = Random.Range(0, 3);

        Strength = stats[s, 0];
        Intelligence = stats[s, 1];
        Dexterity = stats[s, 2];
        Debug.Log(" s0 " + stats[s, 0] + " s1 " +
                  stats[s, 1] + " s2 " + stats[s, 2]);
        Debug.Log("s " + s + " dex " + Dexterity + " str " +
                  Strength + " int " + Intelligence);
        Debug.Log("s " + s + " tdex " + tempDexterity + " tstr " +
                  tempStrength + " tint " + tempIntelligence);
    }
}