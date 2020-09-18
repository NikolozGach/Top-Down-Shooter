using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{





   
    public MainMenu m_mainmenuPrefab;

    private Stack<Menu> m_menuStack = new Stack<Menu>();

    private static MenuManager Instance { get; set;}

    private void Awake()
    {
        Instance = this;
    }
    public void CreateInstance<T>() where T : Menu
    {
        var prefab = GetPrefab<T>();

   
    }
    public void OpenMenu(Menu a_instance)
    {
        if (m_menuStack.Count > 0)
        {
            if (m_instance.DisableMenuUnderneath)
            {
                foreach (var menu in m_menuStack)
                {
                    menu.gameObject.SetActive(false);

                    if (menu.DisableMenuUnderneath)
                        break;
                }
            }
            var topCanvas = a_instance.GetComponent<Canvas>();
            var previousCanvas = m_menuStack.Peek().GetComponent<Canvas>();
            topCanvas.sortingOrder = previousCanvas.sortingOrder + 1;
        }
        
        m_menuStack.Push(a_instance);
    }
    






    // Update is called once per frame
    void Update()
    {
        
    }
}
