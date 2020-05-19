using System;
using System.Diagnostics;
using Softeam.CSharp;


[objingid("4320488d-3b7e-4c92-9cef-351e84898ed4")]
public class Hero
{
    #region name
    [objingid("d950746c-c9b9-464c-94b7-11c34158967c")]
    private string name;
    #endregion

    #region hp
    [objingid("ca67ab46-fd69-478f-b986-74b4f4ba1fbe")]
    private int hp;
    #endregion

    #region damage
    [objingid("72b9c276-1fb4-43dc-8967-4274c836d095")]
    private int damage;
    #endregion

    public Hero(string name, int hp, int damage) {
        this.name = name;
        this.hp = hp;
        this.damage = damage;
    }


    [objingid("4953c3f3-6dd9-4986-9b3b-4fa1128a1de7")]
    public int getHp()
    {
        return hp;
    }

    [objingid("2f65e123-d8ec-4e18-9bf0-99cc7d92cc05")]
    public int getDamage()
    {
        return damage;
    }

    public void setHp(int dam)
    {
        this.hp = dam;
    }

    public void setDam(int dam)
    {
        this.damage = dam;
    }

}

