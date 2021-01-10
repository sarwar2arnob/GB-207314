using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Stats For Upgrade")]
public class UpgradableStats : ScriptableObject
{
    public Sprite[] SwordSprites;
    public int[] DmgOf3Swords;
    public Sprite[] ShieldSprites;
    public int[] BlockCountOf3Shields;
    public int[] DifferentHealthAmount;
    public Sprite[] BowSprites;
    public Sprite[] ArrowSprites;
    public int[] DmgOf3Bows;
}
