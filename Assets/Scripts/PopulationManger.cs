using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PopulationManger : MonoBehaviour
{

    public static float elapsed = 0.0f;
    public GameObject player;
    List<GameObject> PlayerList = new List<GameObject>();
    int popNum = 10;
    float timer = 10.0f;
    int generationNum = 1;
    void Start()
    {
        for(int i = 0; i < popNum; i++)
        {
            Vector3 SpownPos = new Vector3(Random.Range(-9.0f, 9.9f), Random.Range(-3.5f, 5.5f), 0.0f);
            GameObject spawnchild = Instantiate(player, SpownPos, Quaternion.identity);
            spawnchild.GetComponent<DNA>().r = Random.Range(0.0f, 1.0f);
            spawnchild.GetComponent<DNA>().g = Random.Range(0.0f, 1.0f);
            spawnchild.GetComponent<DNA>().b = Random.Range(0.0f, 1.0f);
            PlayerList.Add(spawnchild);
        }
    }
    GUIStyle style = new GUIStyle();

    private void OnGUI()
    {
        style.fontSize = 50;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 0, 200), "Generation : " + generationNum,style);
        GUI.Label(new Rect(10, 65, 0, 200), "Time : " + (int)elapsed,style);
    }
    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > timer)
        {
            CreatNewGeneration();
            elapsed = 0.0f;
        }
    }
    private void CreatNewGeneration()
    {
       
            List<GameObject> sortedList = PlayerList.OrderBy(o => o.GetComponent<DNA>().timeToDie).ToList();
            Debug.Log("new gen");
            PlayerList.Clear();
            for (int i = (int)(sortedList.Count / 2.0f) - 1; i < sortedList.Count - 1; i++)
            {
                PlayerList.Add(Breed(sortedList[i], sortedList[i + 1]));
                PlayerList.Add(Breed(sortedList[i + 1], sortedList[i]));
            }
            for (int i = 0; i < sortedList.Count; i++)
            {
                Destroy(sortedList[i]);
            }
            generationNum++;
        
    }
    GameObject Breed(GameObject parent1, GameObject parent2)
    {
        Vector3 SpownPos = new Vector3(Random.Range(-9.0f, 9.9f), Random.Range(-3.5f, 5.5f), 0.0f);
        GameObject offspring = Instantiate(player, SpownPos, Quaternion.identity);
        DNA dna1 = parent1.GetComponent<DNA>();
        DNA dna2 = parent2.GetComponent<DNA>();        
        offspring.GetComponent<DNA>().r = Random.Range(0, 10) < 5 ? dna1.r : dna2.r;
        offspring.GetComponent<DNA>().g = Random.Range(0, 10) < 5 ? dna1.g : dna2.g;
        offspring.GetComponent<DNA>().b = Random.Range(0, 10) < 5 ? dna1.b : dna2.b;
        return offspring;
    }

}
