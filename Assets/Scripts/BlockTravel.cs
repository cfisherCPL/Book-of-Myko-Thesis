using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTravel : MonoBehaviour
{
    [SerializeField]
    private GameObject blocker;

    private DayTimeManager _time;

    private void Awake()
    {
        _time = FindObjectOfType<DayTimeManager>();
    }

    private void Start()
    {
        blocker.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_time.currentTime.currentTimeOfDay == 4)
        {
            blocker.gameObject.SetActive(true);
        }
    }


}
