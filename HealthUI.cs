using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Stats))]
public class HealthUI : MonoBehaviour
{
    // Ui prefab and target to follow
    public GameObject uiPrefab;
    public Transform target;

    Transform ui;
    Transform cam;
    Image healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;

        foreach (Canvas c in FindObjectsOfType<Canvas>()) // Search for needed canvas
        {
            if (c.renderMode == RenderMode.WorldSpace)
            {
                ui = Instantiate(uiPrefab, c.transform).transform;
                healthSlider = ui.GetChild(0).GetComponent<Image>();
                ui.gameObject.SetActive(false);
                break; // Break out of the loop if canvas found
            }
        }

        GetComponent<Stats>().HealthChange += HealthChange; // Subscribing method
    }

    void HealthChange(int maxHealth, int currenHealth)
    {
        if (ui != null)
        {
            ui.gameObject.SetActive(true);

            float healthPercent = currenHealth / (float)maxHealth;
            healthSlider.fillAmount = healthPercent;
            if (currenHealth <= 0)
            {
                Destroy(ui.gameObject);
            }
        }
    }

    void LateUpdate()
    {
        if (ui != null)
        {
            ui.position = target.position;
            ui.forward = -cam.forward;
        }
    }
}
