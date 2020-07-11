using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModManager : MonoBehaviour {
    private List<Mod> modIndex = new List<Mod>();
    private List<Mod> appliedMods = new List<Mod>();
    public List<string> appliedModNames = new List<string>();

    public float fadeTime = 1.0f;

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
        // add to applied mods
        int i = Random.Range(0, modIndex.Count);
        Mod chosen = modIndex[i];
        appliedMods.Add(chosen);
        chosen.Activate();
        appliedModNames.Add(chosen.GetName());

        // do splash
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //GameObject canvas = player.GetComponentInChildren<Canvas>();
        Text textComponent = player.GetComponentInChildren<Text>();
        textComponent.text = chosen.GetName();
        showText(textComponent);
        StartCoroutine(fadeText(textComponent));
    }

    private void showText(Text text) {
        Color color = text.color;
        color.a = 1;
        text.color = color;
    }

    private IEnumerator fadeText(Text text) {
        Color startColor = text.color;
        Color toColor = text.color;
        toColor.a = 0;
        for (float t = 0.01f; t < fadeTime; t += Time.deltaTime) {
            text.color = Color.Lerp(startColor,
                                    toColor,
                                    Mathf.Min(1, t/fadeTime));
            yield return null;
        }
    }
}
