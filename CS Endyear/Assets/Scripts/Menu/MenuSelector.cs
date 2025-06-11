using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuSelector : MonoBehaviour
{
    public Button firstButton;
    private bool hasDetectedInput = false;

    void Start()
    {
        // Don't select anything on startup
        EventSystem.current.SetSelectedGameObject(null);
    }

    void Update()
    {
        // Check for keyboard input
        if (!hasDetectedInput && CheckForKeyboardInput())
        {
            hasDetectedInput = true;
            EventSystem.current.SetSelectedGameObject(firstButton.gameObject);
        }

        // If mouse is used, clear selection
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0 || Input.GetMouseButtonDown(0))
        {
            if (hasDetectedInput)
            {
                EventSystem.current.SetSelectedGameObject(null);
                hasDetectedInput = false;
            }
        }
    }

    private bool CheckForKeyboardInput()
    {
        // Check for common navigation keys
        return Input.GetKeyDown(KeyCode.Tab) ||
               Input.GetKeyDown(KeyCode.Return) ||
               Input.GetKeyDown(KeyCode.Space) ||
               Input.GetKeyDown(KeyCode.UpArrow) ||
               Input.GetKeyDown(KeyCode.DownArrow) ||
               Input.GetKeyDown(KeyCode.LeftArrow) ||
               Input.GetKeyDown(KeyCode.RightArrow) ||
               Input.GetKeyDown(KeyCode.W) ||
               Input.GetKeyDown(KeyCode.A) ||
               Input.GetKeyDown(KeyCode.S) ||
               Input.GetKeyDown(KeyCode.D) ||
               (Input.GetAxis("Vertical") != 0) ||
               // Check for any key press (more comprehensive)
               Input.inputString.Length > 0;
    }
}