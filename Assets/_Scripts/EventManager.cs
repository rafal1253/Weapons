using System;
public static class EventManager
{
    public static event Action<Weapon> OnUpdateWeapon;
    public static void InvokeOnUpdateWeapon(Weapon weapon) => OnUpdateWeapon?.Invoke(weapon);

}
