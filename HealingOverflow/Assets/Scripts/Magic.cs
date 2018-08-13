using UnityEngine;
using UnityEngine.UI;
public abstract class Magic : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private KeyCode activateKey;
    [SerializeField] private Image cooldownImage;
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
    protected virtual void OnUpdate() {}
    protected abstract void OnCast();
    protected void StartCooldown()
    {
        UnlockPlayerMovement();
        isOnCooldown = true;
        cooldownActivateTime = Time.realtimeSinceStartup;
        Invoke("ResetCooldown", cooldown);
    }
    protected void ToggleLock()
    {
        isOnCooldown = !isOnCooldown;
    }
    protected void UnlockPlayerMovement()
    {
        if (playerController)
            playerController.MovementLock = false;
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