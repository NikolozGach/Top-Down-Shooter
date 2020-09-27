
using UnityEngine;

public class MainMenu : SimpleMenu<MainMenu>
{ 
    public void OnPlayPressed() {
        Hide();
        Time.timeScale = 1;
    }
}
