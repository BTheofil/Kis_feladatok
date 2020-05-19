using System;
using System.Diagnostics;
using Softeam.CSharp;


[objingid("c67d95ec-3c95-4a2c-b6a8-deae9fceb1b1")]
public class Monster
{
    #region hp
    [objingid("26d12379-c860-4087-aa98-58ca1457617a")]
    private int hp;
    #endregion

    #region damage
    [objingid("dc3eb3bd-2e91-4436-868f-1c4ec22a7306")]
    private int damage;
    #endregion


    public Monster(int hp, int damage) {
        this.hp = hp;
        this.damage = damage;
    }


    [objingid("5a539499-3894-4833-bce9-7c767f0ab574")]
    public int getHp()
    {
        return hp;
    }

    [objingid("ba2de4e4-437a-41d3-9f13-847b5c14fb3c")]
    public int getDamage()
    {
        return damage;
    }

    public void setHp(int dam) {
        this.hp = dam;
    }
    public void setDamage(int dam)
    {
        this.damage = dam;
    }

}

