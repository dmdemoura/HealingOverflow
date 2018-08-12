using UnityEngine;

public abstract class SingleTargetMagic : Magic
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Color selectionColor;
    private bool isSelecting = false;
    private Health lastSelectedHealth;
    private SpriteRenderer lastSelectedRenderer;
    private Color lastDefaultColor;
    protected abstract void OnTargetFound(GameObject target);
    protected override void OnCast()
    {
		Vector3 screenPos = Input.mousePosition;
		Vector2 worldpos  = mainCamera.ScreenToWorldPoint(screenPos);

        isSelecting = true;
        IsLocked = true;
    }
    protected override void OnUpdate()
    {
        if (isSelecting)
        {
            Vector3 screenPos = Input.mousePosition;
            Vector2 worldpos  = mainCamera.ScreenToWorldPoint(screenPos);

            Collider2D collider = Physics2D.OverlapPoint(worldpos);

            if (collider && (!lastSelectedHealth || collider.gameObject != lastSelectedHealth.gameObject))
            {
                Health health = collider.gameObject.GetComponent<Health>();
                if (health)
                {
                    SpriteRenderer spriteRenderer = collider.gameObject.GetComponent<SpriteRenderer>();
                    if (spriteRenderer)
                    {
                        if (lastSelectedRenderer)
                            lastSelectedRenderer.color = lastDefaultColor;

                        lastSelectedRenderer = spriteRenderer;
                        lastSelectedHealth = health;
                        lastDefaultColor = spriteRenderer.color;
                        spriteRenderer.color = selectionColor;
                    }
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (lastSelectedRenderer)
                {
                    lastSelectedRenderer.color = lastDefaultColor;
                    OnTargetFound(lastSelectedHealth.gameObject);
                }
                isSelecting = false;
                IsLocked = false;
                StartCooldown();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                if (lastSelectedRenderer)
                    lastSelectedRenderer.color = lastDefaultColor;
                isSelecting = false;
                IsLocked = false;
            }
        }
    }
}