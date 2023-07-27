using System.Collections;
using System.Collections.Generic;

public class DefenseSequence {

    List<DefenseProjectile> projectiles;

    public DefenseSequence(string describersSequence) {
        projectiles = new List<DefenseProjectile>();

        string[] describers = describersSequence.Split(" ");
        foreach(string describer in describers) {
            DefenseProjectile projectile = new DefenseProjectile(describer);
            projectiles.Add(projectile);
        }
    }

}