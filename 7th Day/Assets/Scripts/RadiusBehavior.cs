using UnityEngine;

public class RadiusBehavior : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Human")
        {
            print("touching" + other);
        /*
        mass++;
        massText.setMass(mass);
        other.gameObject.GetComponent<Pellet>().slurp(this.gameObject.transform);

        StartCoroutine(grow(0.08f));
        */
        }
    }
}
