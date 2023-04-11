using UnityEngine;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class Triplaser : ClickSpawner
{
    [SerializeField] NumberField scoreField;
     
    protected override GameObject spawnObject()
    {
        /*
                GameObject newObject = base.spawnObject();  // base = super

                // Modify the text field of the new object.
                ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
                if (newObjectScoreAdder)
                    newObjectScoreAdder.SetScoreField(scoreField);

                return newObject;
        */

        // Create a container object to hold the new lasers
        GameObject containerObject = new GameObject("Laser Container");

        GameObject spawnPrefab = base.spawnObject();

        // Create two instances of the laser-prefab as children of the container object
        GameObject newObject1 = Instantiate(spawnPrefab, containerObject.transform);
        GameObject newObject2 = Instantiate(spawnPrefab, containerObject.transform);
        GameObject newObject3 = Instantiate(spawnPrefab, containerObject.transform);
        // Modify the text field of the new objects.
        ScoreAdder newObject1ScoreAdder = newObject1.GetComponent<ScoreAdder>();
        ScoreAdder newObject2ScoreAdder = newObject2.GetComponent<ScoreAdder>();
        ScoreAdder newObject3ScoreAdder = newObject3.GetComponent<ScoreAdder>();
        if (newObject1ScoreAdder)
            newObject1ScoreAdder.SetScoreField(scoreField);
        if (newObject2ScoreAdder)
            newObject2ScoreAdder.SetScoreField(scoreField);
        if (newObject3ScoreAdder)
            newObject3ScoreAdder.SetScoreField(scoreField);

        // Offset the position of the new objects so they appear side by side
        float xPositionOffset = 0.5f;
        newObject1.transform.position += new Vector3(-xPositionOffset, 0, 0);
        newObject2.transform.position += new Vector3(xPositionOffset, 0, 0);
        newObject3.transform.position += new Vector3(xPositionOffset*2, 0, 0);

        return containerObject;
    }
}
