using UnityEngine;
using UnityEngine.UI;
public abstract class Magic : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private KeyCode activateKey;
    [SerializeField] private Image cooldownImage;
    [SerializeField] private float movementCooldown;
    private PlayerController playerController;
    private float cooldownActivateTime;
    private bool isOnCooldown;
    protected bool IsLocked { get; set; }
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        if (!playerController)
            Debug.LogWarning("Warning, player controller not found on this gameobject");
    }
    private void Update()
    {
        if (Input.GetKeyDown(activateKey))
            TryCasting();

        if (cooldownImage)
            if (!IsLocked && isOnCooldown)
                cooldownImage.fillAmount = (Time.realtimeSinceStartup - cooldownActivateTime)/cooldown;
            else
                cooldownImage.fillAmount = 1f;

        OnUpdate();
    }
    private void ResetCooldown()
    {
        isOnCooldown = false;
    }
    private void ResetPlayerMovement()
    {
        if (playerController)
            playerController.MovementLock = false;
    }
    protected virtual void OnUpdate() {}
    protected abstract void OnCast();
    protected void StartCooldown()
    {
        if (playerController)
            Invoke("ResetPlayerMovement", movementCooldown);
        isOnCooldown = true;
        cooldownActivateTime = Time.realtimeSinceStartup;
        Invoke("ResetCooldown", cooldown);
    }
    protected void ToggleLock()
    {
        isOnCooldown = !isOnCooldown;
    }
    public void TryCasting()
    {
        if (!IsLocked && !isOnCooldown)
        {
            if (playerController)
                playerController.MovementLock = true;
            OnCast();
        }
    }
}