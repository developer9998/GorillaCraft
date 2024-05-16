using UnityEngine;

namespace GorillaCraft.Models
{
    public class MenuObject
    {
        public string Alias, MenuName, PageName;

        public (GameObject, GameObject) GetMenuObject(GameObject menu) => (menu.transform.Find(string.Concat("Menu Parent/", MenuName)).gameObject, menu.transform.Find(string.Concat("UI Parent/Pages/", PageName)).gameObject);
        public (int, int) GetMenuHashCodes(GameObject menu)
        {
            (GameObject menuObject, GameObject uiObject) = GetMenuObject(menu);
            return (menuObject.GetHashCode(), uiObject.GetHashCode());
        }
    }
}
