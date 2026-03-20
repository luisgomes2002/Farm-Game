using UnityEngine;

public class MobMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        
    }
}
