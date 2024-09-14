using UnityEngine;

public class ClearCartButton : MonoBehaviour
{
    public ItemController itemController; // Referenz zum ItemController Skript

    public void ClearItems()
    {
        itemController.ClearCart();
    }
}
