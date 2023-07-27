public class DefenseProjectile 
{
    float delay; // Delay between the previous attack and this one, in seconds
    float damageModifier; 
    float speedModifier; 
    string trajectory; // String describing the trajectory of the projectile (for now, only "|" supported)

    public DefenseProjectile(string describer) {
        string[] describers = describer.Split("-");
        delay = float.Parse(describers[0]);
        damageModifier = float.Parse(describers[1]);
        speedModifier = float.Parse(describers[2]);
        trajectory = describers[3];
    }
}