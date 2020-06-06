using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetParameters : MonoBehaviour
{
    private LifeManager _life;
    private AbilityContainer _abilities;

    // Start is called before the first frame update
    void Start()
    {
        _life = GameObject.FindGameObjectWithTag("GameController").GetComponent<LifeManager>();
        _abilities = GameObject.FindGameObjectWithTag("GameController").GetComponent<AbilityContainer>();
    }

    public void resetLifes()
    {
        _life.setInitialLifes();
    }

    public void resetAblities()
    {
        if(LoadScene.Instance.previousScene == "Level01")
        {
            _abilities.ActiveAbility[AbilityTypes.M_RAYS] = false;
            _abilities.ActiveAbility[AbilityTypes.UNLOCKING] = false;
            _abilities.ActiveAbility[AbilityTypes.RESILIENT] = false;
        }
        else if (LoadScene.Instance.previousScene == "Level02")
        {
            _abilities.ActiveAbility[AbilityTypes.M_RAYS] = false;
            _abilities.ActiveAbility[AbilityTypes.UNLOCKING] = true;
            _abilities.ActiveAbility[AbilityTypes.RESILIENT] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
