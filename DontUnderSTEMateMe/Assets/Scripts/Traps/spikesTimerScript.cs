using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikesTimerScript : MonoBehaviour
{
    [SerializeField] private List<TrapTemplate> spikesList;
    [SerializeField] protected float time;

    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i< spikesList.Count; i+=2)
        {
            spikesList[i].SpikesMovement();
        }

        StartCoroutine(spikesRutine());
    }

    private IEnumerator spikesRutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(time);
            NotifySpikes();
        }
    }

    private void NotifySpikes()
    {
        foreach (TrapTemplate spike in spikesList)
        {
            spike.SpikesMovement();
        }
    }
}
