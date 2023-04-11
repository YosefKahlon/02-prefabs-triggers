using UnityEngine;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class LaserShooter : ClickSpawner
{
    [SerializeField] NumberField scoreField;
    private int laserCount = 0;
    float xPositionOffset = 0.5f;
    private float laserWidth = 1.0f; // Assuming that all lasers have the same width of 1.0 units

    protected override GameObject spawnObject()
    {

        GameObject newObject = base.spawnObject();  // base = super

        if (laserCount == 0)
        {
            // Modify the text field of the new object.
            ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
            if (newObjectScoreAdder)
                newObjectScoreAdder.SetScoreField(scoreField);

            return newObject;
        }
        else
        {
            GameObject containerObject = new GameObject("Laser Container");


            for (int i = 0; i < laserCount; i++)
            {
                GameObject newObject1 = Instantiate(newObject, containerObject.transform);
                // Modify the text field of the new object.
                ScoreAdder newObjectScoreAdder = newObject1.GetComponent<ScoreAdder>();
                if (newObjectScoreAdder)
                    newObjectScoreAdder.SetScoreField(scoreField);
                // Offset the position of the new objects so they appear side by side

                if (laserCount == 1)
                {
                    newObject1.transform.position += new Vector3(xPositionOffset, 0, 0);
                }
                else
                {
                    // Offset the position of the new objects so they appear side by side
                    // The x position of the new laser is calculated based on the current laser count and its width
                    float xPos = (i - (laserCount - 1) / 2.0f) * laserWidth;
                    newObject1.transform.position += new Vector3(xPos, 0, 0);
                }


            }
            return containerObject;
        }

    }

    public void AddLaser()
    {
        laserCount++;
        Debug.Log("Laser Count: " + laserCount);


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "+1")
        {
            Debug.Log("trigger in laser shoter" + other);
            AddLaser();
            Destroy(other.gameObject);
        }
    }


}
