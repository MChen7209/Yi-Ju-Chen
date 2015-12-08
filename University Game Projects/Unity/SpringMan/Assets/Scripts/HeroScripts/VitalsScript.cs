using UnityEngine;
using System.Collections.Generic;

public class VitalsScript
{

    private List<GUITexture> Health = new List<GUITexture>();
    private List<GUITexture> Energy = new List<GUITexture>();
    public static int CurrentEnergy = 0;
    public static int MaxHealth = 3;
    public static int MaxEnergy = 3;

    public static int CurrentHealth = 3;
    private GameObject player;
    private float lastHitTime;
    // Use this for initialization

    public VitalsScript()
    {
        //SCurrentHealth = MaxHealth;
        Energy.Clear();
        Energy.Add(GameObject.Find("Energy_1").GetComponent<GUITexture>());
        Energy.Add(GameObject.Find("Energy_2").GetComponent<GUITexture>());
        Energy.Add(GameObject.Find("Energy_3").GetComponent<GUITexture>());
        Energy.Add(GameObject.Find("Energy_4").GetComponent<GUITexture>());
        Energy.Add(GameObject.Find("Energy_5").GetComponent<GUITexture>());
        Energy.Add(GameObject.Find("Energy_6").GetComponent<GUITexture>());
        Energy.Add(GameObject.Find("Energy_7").GetComponent<GUITexture>());


        Health.Clear();
        Health.Add(GameObject.Find("Health_1").GetComponent<GUITexture>());
        Health.Add(GameObject.Find("Health_2").GetComponent<GUITexture>());
        Health.Add(GameObject.Find("Health_3").GetComponent<GUITexture>());
        Health.Add(GameObject.Find("Health_4").GetComponent<GUITexture>());
        Health.Add(GameObject.Find("Health_5").GetComponent<GUITexture>());
        Health.Add(GameObject.Find("Health_6").GetComponent<GUITexture>());
        Health.Add(GameObject.Find("Health_7").GetComponent<GUITexture>());
    }

    public bool Dead
    {
        get
        {
            if (CurrentHealth <= 0)
                return true;
            else
                return false;
        }
        set
        {
            if (value == true)
                CurrentHealth = 0;
            else
                CurrentHealth = 1;
        }
    }

    public void AbsorbEnergy(int energyAbsorbed)
    {
        if (CurrentEnergy <MaxEnergy )
            CurrentEnergy += energyAbsorbed;
        else
            CurrentEnergy = MaxEnergy;
        HandleEnergy();
    }

    /* Checks if the player has enough energy for the power. If it does, it subtracts it
     * and returns true. Else it returns false and the power is not used.
     */
    public bool UseEnergy(int energyUsed)
    {
        if (CurrentEnergy >= energyUsed)
        {
            CurrentEnergy -= energyUsed;
            HandleEnergy();
            return true;
        }
        return false;
    }

    public bool TakeDamage()
    {
        if (Time.time > lastHitTime + 1.55)
        {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<HeroController>().HurtSound .Play ();
            CurrentHealth--;
            HandleHealth();
            lastHitTime = Time.time;
			return true;
        }
		return false;
    }

    public void TakeDamage(float damage) //Method obsolete.
    {
        TakeDamage();
        //CurrentHealth -= damage;
        //HandleHealth();
    }

    public void Heal()
    {
        if (CurrentHealth < MaxHealth&&!HeroController .GameOver )
        {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<HeroController>().HealSound .Play ();
            ++CurrentHealth;
            HandleHealth();
        }
    }

	public void Heal(int healBy)
	{
		if (CurrentHealth < MaxHealth&&!HeroController .GameOver )
		{
			GameObject.FindGameObjectWithTag ("Player").GetComponent<HeroController>().HealSound .Play ();
			CurrentHealth += healBy;
			HandleHealth();
		}
	}

    public void HandleEnergy()
    {
        Color full = new Color(.22f, .2f, .55f, .8f);
        Color empty = new Color(.22f, .2f, .55f, .1f);
        if (CurrentEnergy >= 1)
            Energy[0].color = full;
        else
            Energy[0].color = empty;
        if (CurrentEnergy >= 2)
            Energy[1].color = full;
        else
            Energy[1].color = empty;
        if (CurrentEnergy >= 3)
            Energy[2].color = full;
        else
            Energy[2].color = empty;
        if (CurrentEnergy >= 4)
            Energy[3].color = full;
        else
            Energy[3].color = empty;
        if (CurrentEnergy >= 5)
            Energy[4].color = full;
        else
            Energy[4].color = empty;
        if (CurrentEnergy >= 6)
            Energy[5].color = full;
        else
            Energy[5].color = empty;
        if (CurrentEnergy >= 7)
            Energy[6].color = full;
        else
            Energy[6].color = empty;
        if (MaxEnergy <= 3)
            Energy[3].enabled = false;
        else
            Energy[3].enabled = true;

        if (MaxEnergy <= 4)
            Energy[4].enabled = false;
        else
            Energy[4].enabled = true;
        if (MaxEnergy <= 5)
            Energy[5].enabled = false;
        else
            Energy[5].enabled = true;
        if (MaxEnergy <= 6)
            Energy[6].enabled = false;
        else
            Energy[6].enabled = true;

    }

    public void HandleHealth()
    {
        return;
        for (int i = 0; i < MaxHealth; i++)
        {
            if (CurrentHealth > i)
                Health[i].enabled = true;
            else
                Health[i].enabled = false;
        }

    }

}
