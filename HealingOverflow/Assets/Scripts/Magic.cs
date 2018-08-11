using UnityEngine;
public abstract class Magic : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private KeyCode activateKey;
    [SerializeField] private PercentBar cooldownBar;
    private float cooldownActivateTime;
    private bool isOnCooldown;
    protected bool IsLocked { get; set; }
    private void Update()
    {
        if (Input.GetKeyDown(activateKey))
            TryCasting();

        if (!IsLocked && isOnCooldown && cooldownBar)
            cooldownBar.Value = (Time.realtimeSinceStartup - cooldownActivateTime)/cooldown;
        else
            cooldownBar.Value = 1.0f;

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
            OnCast();
        }
    }
}