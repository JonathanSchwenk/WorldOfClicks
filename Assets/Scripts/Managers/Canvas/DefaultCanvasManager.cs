using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dorkbots.ServiceLocatorTools;

public class DefaultCanvasManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clickValueText;

    private IClickManager clickManager;

    // Start is called before the first frame update
    void Start()
    {
        clickManager = ServiceLocator.Resolve<IClickManager>();
    }

    // Update is called once per frame
    void Update()
    {
        clickValueText.text = clickManager.totClicks.ToString();
    }
}
