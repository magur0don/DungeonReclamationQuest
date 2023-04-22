using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dungeons : MonoBehaviour
{
    private List<Polyomino> polyominos = new List<Polyomino>();

    public bool IsBulied = false;

    private void Start()
    {
        foreach (var polyomino in this.transform.GetComponentsInChildren<Polyomino>())
        {
            polyominos.Add(polyomino);
        }
    }
    private void Update()
    {
        if (!IsBulied)
        {
            // polyominosëSïîÇ™trueÇæÇ¡ÇΩÇÁ
            IsBulied = polyominos.All(polyomino => polyomino.IsBuried);
        }
        else
        {
            Debug.Log("ÉNÉäÉA");
        }
    }

}
