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
    public GameObject obj;
    public Material store;
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
                if (obj != null) {
                    obj.GetComponent<MeshRenderer>().material = store;
                }
                curr = hit.transform.gameObject.GetComponent<Entity>();
                if (curr != null) {
                    obj = hit.transform.gameObject;
                    store = obj.GetComponent<MeshRenderer>().material; 
                }
            }
        }
        if (curr != null) {
            healthBarInner.fillAmount = (float) curr.Health / curr.MaxHealth;
            entityText.SetText(curr.name);


            Material m = Resources.Load<Material>("Selected");
            obj.GetComponent<MeshRenderer>().material = m;
        }
        else {
            entityText.SetText("No target");
            healthBarInner.fillAmount = 0;
        }
    }
}
