using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    PiUIManager piUi;
    private bool menuOpened;
    private PiUI normalMenu;
    public string[] stringVect;
    // Use this for initialization
    void Start()
    {
        //Get menu for easy not repetitive getting of the menu when setting joystick input
        normalMenu = piUi.GetPiUIOf("Normal Menu");
    }

    // Update is called once per frame
    void Update()
    {
        //Update the menu and add the Testfunction to the button action if Fire2 axis is pressed
        if (Input.GetButtonDown("Fire2"))
        {
            //Ensure menu isnt currently open on update just for a cleaner look
            if (!piUi.PiOpened("Normal Menu"))
            {
                int i = 0;
                //Iterate through the piData on normal menu
                foreach (PiUI.PiData data in normalMenu.piData)
                {
                    //Changes slice label
                    data.sliceLabel = stringVect[i];
                    //Creates a new unity event and adds the testfunction to it
                    data.onSlicePressed = new UnityEngine.Events.UnityEvent( );
                    data.onSlicePressed.AddListener(TestFunction);
                    i++;
                }
                //Since PiUI.sliceCount or PiUI.equalSlices didnt change just calling update
                piUi.UpdatePiMenu("Normal Menu");
            }
            //Open or close the menu depending on it's current state at the center of the screne
            piUi.ChangeMenuState("Normal Menu", new Vector2(Screen.width / 2f, Screen.height / 2f));
        }
        //Set joystick input on the normal menu which the piPieces check
        normalMenu.joystickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //Set the bool to detect if the controller button has been pressed
        normalMenu.joystickButton = Input.GetButtonDown("Fire1");
        //If the button isnt pressed check if has been released
        if (!normalMenu.joystickButton)
        {
            normalMenu.joystickButton = Input.GetButtonUp("Fire1");
        }
    }
    //Test function that writes to the console and also closes the menu
    public void TestFunction()
    {
        //Closes the menu
        piUi.ChangeMenuState("Normal Menu");
        Debug.Log("You Clicked me!");
    }

    public void OnHoverEnter()
    {
        Debug.Log("Hey get off of me!");
    }
    public void OnHoverExit()
    {
        Debug.Log("That's right and dont come back!");
    }
}
