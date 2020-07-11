using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModManager : MonoBehaviour {
    private List<Mod> modIndex = new List<Mod>();
    private List<Mod> appliedMods = new List<Mod>();
    public List<string> appliedModNames = new List<string>();

    void Start() {
        // add newly created mods to index
        modIndex.Add(new ModIncreaseFireRate());
        modIndex.Add(new ModSlowMove());
        modIndex.Add(new ModBigBullets());
        modIndex.Add(new ModSpeedBoost());
        modIndex.Add(new ModEnemySpeedBoost());
        modIndex.Add(new ModEnemySlowMove());
        modIndex.Add(new ModMoreDamage());
        modIndex.Add(new ModMoreAccuracy());
        modIndex.Add(new ModBigEnemies());
    }

    public void ActivateRandom() {
        int i = Random.Range(0, modIndex.Count);
        Mod chosen = modIndex[i];
        appliedMods.Add(chosen);
        chosen.Activate();

        appliedModNames.Add(chosen.GetName());
    }
}
