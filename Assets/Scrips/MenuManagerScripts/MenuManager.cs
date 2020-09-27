using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class MenuManager : MonoBehaviour
{





   
    //public MainMenu m_mainmenuPrefab;

    private Stack<Menu> m_menuStack = new Stack<Menu>();

    public static MenuManager Instance { get; set;}

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
            if (a_instance.DisableMenusUnderneath)
            {
                foreach (var menu in m_menuStack)
                {
                    menu.gameObject.SetActive(false);

                    if (menu.DisableMenusUnderneath)
                        break;
                }
            }
            var topCanvas = a_instance.GetComponent<Canvas>();
            var previousCanvas = m_menuStack.Peek().GetComponent<Canvas>();
            topCanvas.sortingOrder = previousCanvas.sortingOrder + 1;
        }


        
        m_menuStack.Push(a_instance);
    }

    private T GetPrefab<T>() where T : Menu
    {
        // Get prefab dynamically, based on public fields set from Unity
        // You can use private fields with SerializeField attribute too
        var fields = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        foreach (var field in fields)
        {
            var prefab = field.GetValue(this) as T;
            if (prefab != null)
            {
                return prefab;
            }
        }

        throw new MissingReferenceException("Prefab not found for type " + typeof(T));
    }

    public void CloseMenu(Menu menu)
    {
        if (m_menuStack.Count == 0)
        {
            Debug.LogErrorFormat(menu, "{0} cannot be closed because menu stack is empty", menu.GetType());
            return;
        }

        if (m_menuStack.Peek() != menu)
        {
            Debug.LogErrorFormat(menu, "{0} cannot be closed because it is not on top of stack", menu.GetType());
            return;
        }

        //CloseTopMenu();
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
