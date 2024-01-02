using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButton : MonoBehaviour
{
    public Button alat, ikon;
    public GameObject m_alat, m_ikon;
    public List<GameObject> toDelete = new List<GameObject>();
    public GameObject[] toActive;
    public void Alat()
    {
        m_alat.SetActive(true);
        m_ikon.SetActive(false);
        if (toDelete.Count != 0)
        {
            foreach (var item in toDelete)
            {
                DestroyImmediate(item);
            }

        }
        toActive[0].SetActive(true);
        toDelete = new List<GameObject>();
    }

    public void Ikon()
    {
        m_ikon.SetActive(true);
        m_alat.SetActive(false);
        if (toDelete.Count != 0)
        {
            foreach (var item in toDelete)
            {
                DestroyImmediate(item);
            }

        }
        toActive[1].SetActive(true);

    }
}
