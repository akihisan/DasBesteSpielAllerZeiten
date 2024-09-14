using UnityEngine;

public class DeactivateCartItems : MonoBehaviour
{
    public Transform shoppingCartPanel;

    public void DeactivateAllItems()
    {
        // Gehe durch alle Kinder des Einkaufswagen-Panels und deaktiviere sie
        foreach (Transform child in shoppingCartPanel)
        {
            child.gameObject.SetActive(false);
        }
    }
}
