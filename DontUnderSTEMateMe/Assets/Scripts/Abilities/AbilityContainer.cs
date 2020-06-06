using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityContainer : MonoBehaviour
{
    public Dictionary<AbilityTypes, bool> ActiveAbility;

    // Start is called before the first frame update
    void Start()
    {
        initDictionary();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void initDictionary()
    {
        ActiveAbility = new Dictionary<AbilityTypes, bool>();

        var values = AbilityTypes.GetValues(typeof(AbilityTypes));
        foreach (AbilityTypes value in values)
        {
            ActiveAbility[value] = false;
        }
    }
}
