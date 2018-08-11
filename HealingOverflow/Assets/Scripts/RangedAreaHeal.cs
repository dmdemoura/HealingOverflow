using UnityEngine;
public class RangedAreaHeal : Magic
{
	[SerializeField] private Camera mainCamera;
	[SerializeField] private GameObject healingCirclePrefab;
    [SerializeField] private float healingCircleDuration;
    [SerializeField] private float healingCirclePower;
    private HealingCircle healingCircle;
    private bool isSelecting = false;
    protected override void OnUpdate()
    {
        if (isSelecting)
        {
            Vector3 screenPos = Input.mousePosition;
            Vector2 worldpos  = mainCamera.ScreenToWorldPoint(screenPos);

            healingCircle.transform.position = worldpos; 

            if (Input.GetMouseButtonDown(0))
            {
                healingCircle.Activate(healingCircleDuration, healingCirclePower);
                isSelecting = false;
                IsLocked = false;
                StartCooldown();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Destroy(healingCircle.gameObject);
                isSelecting = false;
                IsLocked = false;
            }
        }
    }
    protected override void OnCast()
    {
		Vector3 screenPos = Input.mousePosition;
		Vector2 worldpos  = mainCamera.ScreenToWorldPoint(screenPos);

        healingCircle = Instantiate(healingCirclePrefab, worldpos, transform.rotation).GetComponent<HealingCircle>();
        isSelecting = true;
        IsLocked = true;
    }
}