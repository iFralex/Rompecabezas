using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class lettera : MonoBehaviour
{
    bool torna;
    public Vector2 pos;
    public GraphicRaycaster m_Raycaster;
    public PointerEventData m_PointerEventData;
    public EventSystem m_EventSystem;

    void Update()
    {
        if (torna)
        {
            transform.position = Vector2.Lerp(transform.position, pos, Time.deltaTime * 5);
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
    }

    public void Trascina()
    {
        transform.position = Input.mousePosition;
    }

    public void TornaIndietro(bool a)
    {
        torna = a;
        if (!a)
        {
            GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        }
        else
        {
            GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        }
        transform.SetAsLastSibling();
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(m_PointerEventData, results);
        if (results.Count > 2)
        {
            if (results[2].gameObject.name == name)
            {
                results[2].gameObject.transform.GetChild(0).GetComponent<Text>().text = GetComponent<Text>().text;
                results[2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                if (results[2].gameObject.name == "Cuerpo")
                {
                    Destroy(results[2].gameObject.transform.GetChild(1).gameObject);
                }
                torna = false;
                transform.parent.parent.GetComponent<AudioSource>().clip = transform.parent.parent.GetComponent<organizzaLettera>().clipSuc;
                transform.parent.parent.GetComponent<AudioSource>().Play();
                transform.parent.parent.GetComponent<organizzaLettera>().completi++;
                Destroy(gameObject);
            }
        }
    }
}
