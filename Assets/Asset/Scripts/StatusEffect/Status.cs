using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    public int roundPassed;
    public int rounds;
    public bool poison;
    public int poisonCount = 0;

    public Sprite knockedOutIcon;
    public Sprite poisonIcon;
    public Sprite burnIcon;
    public Sprite strengthUpIcon;
    public Sprite strengthDownIcon;
    public Sprite slowIcon;
    public Sprite hasteIcon;
    public Sprite confuseIcon;
    public Sprite berserkIcon;
    public Sprite flinchedIcon;
    public Sprite reganIcon;
    public Sprite bleedIcon;
    public Sprite immunityIcon;
    public Sprite defenseDownIcon;
    public Sprite defenseUpIcon;
    public Sprite magicUpIcon;
    public Sprite magicDownIcon;
    public Sprite spiritUpIcon;
    public Sprite spiritDownIcon;
    public Sprite critUpIcon;
    public Sprite critDownIcon;
    public Sprite accUpIcon;
    public Sprite accDownIcon;
    public Sprite evasionUpIcon;
    public Sprite evasionDownIcon;
    public Sprite blindIcon;
    public Sprite blessedIcon;
    public Sprite cursedIcon;
    public Sprite silenceIcon;
    public Sprite lifestealIcon;


    public List<Sprite> icon;

    public void Poison() {
        InvokeRepeating("PoisonDamage", 0.0f, 2.0f);
        icon.Add(poisonIcon);
    }
    
    private void PoisonDamage()
    {
        this.GetComponent<PlayerStats>().health -= this.GetComponent<PlayerStats>().baseHealth * 0.01f;
        poisonCount++;
        if(poisonCount>= 15)
        {
            CancelInvoke("PoisonDamage");
            icon.Remove(poisonIcon);
        }
    }

    public void Slow()
    {
        this.GetComponent<PlayerStats>().speed = this.GetComponent<PlayerStats>().speed*0.3f;
    }

    public void Haste()
    {

    }

    public void StrengthUp()
    {

    }

    public void StrengthDown()
    {
        
    }

    public void Burn()
    {

    }

    public void KnockedOut()
    {

    }

    public void Confuse()
    {

    }

    // Update is called once per frame
    void Update () {
        if(roundPassed != rounds)
        {
            rounds = roundPassed;
            
        }
        for(int i = 0; i < icon.Count;i++)
        {
            Instantiate(icon[i], new Vector2(this.GetComponent<Transform>().position.x + i * 10, this.GetComponent<Transform>().position.y - 10),this.GetComponent<Transform>().rotation);
        }
        
	}
}
