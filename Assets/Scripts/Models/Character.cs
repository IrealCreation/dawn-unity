
public class Character 
{
    private int health;
    private int maxHealth;

    /// <summary>
    /// Change the health of the character (healing / damages)
    /// </summary>
    /// <param name="health">The value added to the health (positive for healing, negative for damages)</param>
    /// <returns>true if the character is still alive, false otherwise</returns>
    public bool changeHealth(int health) {
        this.health += health;
        if(health > maxHealth)
            health = maxHealth;

        if(health < 0)
            return false;
        return true;
    }
}