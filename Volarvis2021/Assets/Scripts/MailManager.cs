using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailManager : MonoBehaviour
{

    public Button M1;
    public Button L1;
    public Button M2;
    public Button L2;
    public Button M3;
    public Button L3;
    public Button L4;
    public Button M4;

    public Button M1_lock;
    public Button L1_lock;
    public Button M2_lock;
    public Button L2_lock;
    public Button M3_lock;
    public Button L3_lock;
    public Button L4_lock;
    public Button M4_lock;

    public static int M1_THRESHOLD = 1;
    public static int L1_THRESHOLD = 7;
    public static int M2_THRESHOLD = 14;
    public static int L2_THRESHOLD = 26;
    public static int M3_THRESHOLD = 33;
    public static int L3_THRESHOLD = 40;
    public static int L4_THRESHOLD = 47;
    public static int M4_THRESHOLD = 52;

    public void ToggleVisibility()
    {
        if (Player.instance.discovery.getDiscoveredVolastros().Count >= M1_THRESHOLD)
        {
            M1_lock.gameObject.SetActive(false);
            M1.gameObject.SetActive(true);
        }

        if (Player.instance.discovery.getDiscoveredVolastros().Count >= L1_THRESHOLD)
        {
            L1_lock.gameObject.SetActive(false);
            L1.gameObject.SetActive(true);
        }

        if (Player.instance.discovery.getDiscoveredVolastros().Count >= M2_THRESHOLD)
        {
            M2_lock.gameObject.SetActive(false);
            M2.gameObject.SetActive(true);
        }

        if (Player.instance.discovery.getDiscoveredVolastros().Count >= L2_THRESHOLD)
        {
            L2_lock.gameObject.SetActive(false);
            L2.gameObject.SetActive(true);
        }

        if (Player.instance.discovery.getDiscoveredVolastros().Count >= M3_THRESHOLD)
        {
            M3_lock.gameObject.SetActive(false);
            M3.gameObject.SetActive(true);
        }

        if (Player.instance.discovery.getDiscoveredVolastros().Count >= L3_THRESHOLD)
        {
            L3_lock.gameObject.SetActive(false);
            L3.gameObject.SetActive(true);
        }

        if (Player.instance.discovery.getDiscoveredVolastros().Count >= L4_THRESHOLD)
        {
            L4_lock.gameObject.SetActive(false);
            L4.gameObject.SetActive(true);
        }

        if (Player.instance.discovery.getDiscoveredVolastros().Count >= M4_THRESHOLD)
        {
            M4_lock.gameObject.SetActive(false);
            M4.gameObject.SetActive(true);
        }
    }
}
