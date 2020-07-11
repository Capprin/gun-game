using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModManager : MonoBehaviour {

    // Array of mods
    List<mod> mods = new List<mod>();
    int modMaxIndex;
    // String to index mod map
    Dictionary<string, int> nameToIndex;

    public int tmp_delay = 180; // TODO remove

    // Start is called before the first frame update
    void Start() {

        // Create array of all mods
        mods.Add(new mod_increaseFireRate());

        // Generate name to index map in case we wish to call specific mods
        nameToIndex = new Dictionary<string, int>();
        nameToIndex.Add("increaseFireRate", 0);

        modMaxIndex = mods.Count-1;
    }

    // Update is called once per frame
    void Update() {

        // TODO remove
        tmp_delay--;
        if (tmp_delay < 0) {
            tmp_delay = 180;
            mods[0].Activate();
        }

    }
}
