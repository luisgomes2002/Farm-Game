using UnityEngine;

public class characterMovemente : MonoBehaviour
{
    private Character character;

    void Start()
    {
        character = GetComponent<Character>();
    }

    void Update()
    {
        OnInput();
        OnRun();
        OnRolling();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement
    void OnInput()
    {
        character.Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    void OnMove()
    {
        if (character.CanMove)
        {
            character.Rig.MovePosition(character.Rig.position + character.Direction * character.Speed * Time.fixedDeltaTime);
        }
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            character.Speed = character.RunSpeed;
            character.IsRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            character.Speed = character.InitialSpeed;
            character.IsRunning = false;
        }

    }

    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            character.Speed = character.RunSpeed;
            character.IsRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            character.Speed = character.InitialSpeed;
            character.IsRolling = false;
        }
    }

    #endregion
}
