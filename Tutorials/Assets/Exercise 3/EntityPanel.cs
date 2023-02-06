using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EntityPanel : MonoBehaviour
{
    public TextMeshProUGUI entityText;
    public Image healthBarInner;
    public Entity curr;
    // Start is called before the first frame update
    void Start()
    {
        entityText = GameObject.Find("CurrentEntity").GetComponent<TextMeshProUGUI>();
        healthBarInner = GameObject.Find("HealthBarInner").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100)) {
                curr = hit.transform.gameObject.GetComponent<Entity>();
            }
        }
        if (curr != null) {
            healthBarInner.fillAmount = (float) curr.Health / curr.MaxHealth;
            entityText.SetText(curr.name);
        }
        else {
            entityText.SetText("No target");
            healthBarInner.fillAmount = 0;
        }
    }
}
