using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    private int index;
    private Animator anim;

    public List<Transform> paths = new List<Transform>();

    private void Start()
    {
        InitialSpeed = Speed;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (DialogueControl.instance.isShowing)
        {
            Speed = 0f;
            anim.SetBool("isWalking", false);
        }
        else
        {
            Speed = InitialSpeed;
            anim.SetBool("isWalking", true);
        }

        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, Speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, paths[index].position) < 0.1f)
        {
            if (index < paths.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }

        Vector2 direction = paths[index].position - transform.position;

        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
