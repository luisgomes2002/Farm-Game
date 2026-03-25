using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Character character;
    private Animator anim;


    void Start()
    {
        character = GetComponent<Character>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement

    void OnMove()
    {
        if (character.Direction.sqrMagnitude > 0)
        {
            if (character.IsRolling)
            {
                anim.SetTrigger("isRoll");
            }
            else
            {
                anim.SetInteger("transition", 1);
            }
        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        if (character.Direction.x > 0)
            transform.eulerAngles = new Vector3(0, 0);

        if (character.Direction.x < 0)
            transform.eulerAngles = new Vector3(0, 180);
    }

    void OnRun()
    {
        if (character.IsRunning)
            anim.SetInteger("transition", 2);
    }

    #endregion
}
