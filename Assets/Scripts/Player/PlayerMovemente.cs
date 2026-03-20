using UnityEngine;

public class PlayerMovemente : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GetComponent<Player>();
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
        player.Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    void OnMove()
    {
        if (player.CanMove)
        {
            player.Rig.MovePosition(player.Rig.position + player.Direction * player.Speed * Time.fixedDeltaTime);
        }
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.Speed = player.RunSpeed;
            player.IsRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            player.Speed = player.InitialSpeed;
            player.IsRunning = false;
        }

    }

    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            player.Speed = player.RunSpeed;
            player.IsRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            player.Speed = player.InitialSpeed;
            player.IsRolling = false;
        }
    }

    #endregion
}
