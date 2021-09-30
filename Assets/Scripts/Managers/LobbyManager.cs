using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyManager : MonoBehaviour
{
    //Genero las acciones para unir con el teclado
    public InputAction join1;
    public InputAction join2;

    //public InputAction[] joiningActions;

    //Hago una lista donde almacenare que jugadores ya se unieron
    [SerializeField]
    List<int> joinControllers = new List<int>();

    public Transform joinPosManager;

    // Start is called before the first frame update
    void Start()
    {
        //Habilito las acciones para que puedan ser apretadas
        join1.Enable();
        join2.Enable();

        //Agrego la funcionalidad a las acciones
        join1.performed += (call) => JoinPlayer(call, 0);
        join2.performed += (call) => JoinPlayer(call, 1);
    }

    //Agrega un jugador
    void JoinPlayer(InputAction.CallbackContext callback, int index) 
    {
        //Revisa que el scheme no este utilizado
        if (joinControllers.Contains(index)) return;

        //Hace un nuevo jugador
        var input = PlayerInputManager.instance.JoinPlayer();

        //Define que esquema se debe de utilizar
        string scheme = "Keyboard&Mouse";
        if (index == 1) scheme = "Keyboard2";
        //switch (index)
        //{
        //    case 1:
        //    default:
        //        scheme = "Keyboard&Mouse";
        //        break;
        //}


        //Obliga a usar el nuevo esquema 
        PlayerInput.all[input.playerIndex].SwitchCurrentControlScheme(
            controlScheme: scheme, 
            Keyboard.current);

        //Agrega el index a la lista para evitar que se vuelva a usar
        joinControllers.Add(index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnJoinPlayer(PlayerInput input)
    {
        Debug.Log("Me he unido");
        Transform correctPos = joinPosManager.GetChild(input.playerIndex);

        input.transform.SetPositionAndRotation(correctPos.position, correctPos.rotation);
    }
}
