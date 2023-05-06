using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public float interactionDistance = 2f;
    public LayerMask npcLayer;
    private Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithNPC();
        }
    }

    void InteractWithNPC()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, interactionDistance, npcLayer);

        if (hit.collider != null)
        {
            NPC npc = hit.collider.GetComponent<NPC>();

            if (npc != null)
            {
                npc.TrainAbility(player);
            }
        }
    }
}
