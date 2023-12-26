using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WheaterController : MonoBehaviour
{

    private List<EventGame> phaseList;
    public string barTag = "ValidZone";
    public GameObject bar;
    private BarsController barsController;
    private int actualPhase = 0;

    public WheaterPhase actualWheaterPhase;

    // Start is called before the first frame update
    void Start()
    {
        barsController = bar.GetComponent<BarsController>();
        GeneratePhases();
        LaunchPhases();

    }

    private void Update()
    {
        if(actualPhase == phaseList.Count - 1)
        {
            actualPhase = 0;

            //Se vuelven a repetir
            LaunchPhases();
        }
    }

    private void GeneratePhases()
    {
        EventGame eventGame = null;
        phaseList = new();

        WheaterPhase noMove = new WheaterPhase();
        noMove.upOrDown = 1;
        noMove.speed = 0;
        noMove.obstacleLevel = 3;
        noMove.coldBarIncrement = 0.1f;

        WheaterPhase downPhase1 = new WheaterPhase();
        downPhase1.upOrDown = -1;
        downPhase1.speed = 1.5f;
        downPhase1.obstacleLevel = 1;
        downPhase1.coldBarIncrement = 0.1f;

        WheaterPhase upPhase1 = new WheaterPhase();
        upPhase1.upOrDown = 1;
        upPhase1.speed = 0.5f;
        upPhase1.obstacleLevel = 3;
        upPhase1.coldBarIncrement = 0.1f;

        //Event 1
        eventGame = new EventGame();
        eventGame.time = 0;
        eventGame.phase = noMove;
        phaseList.Add(eventGame);

        //Event 2
        eventGame = new EventGame();
        eventGame.time = 5;
        eventGame.phase = downPhase1;
        phaseList.Add(eventGame);

        //Event 3
        eventGame = new EventGame();
        eventGame.time = 10;
        eventGame.phase = upPhase1;
        phaseList.Add(eventGame);

        //Event 4
        eventGame = new EventGame();
        eventGame.time = 15;
        eventGame.phase = noMove;
        phaseList.Add(eventGame);

    }

    private void LaunchPhases()
    {
        for(int i = 0; i < phaseList.Count; i++)
        {
            StartCoroutine(LaunchPhase(phaseList[i].time, phaseList[i].phase, i));
        }
    }


    public IEnumerator LaunchPhase(float time, WheaterPhase phase, int phaseNumber)
    {
        yield return new WaitForSeconds(time);
        actualWheaterPhase = phase;
        barsController.actualWheaterPhase = phase;
        actualPhase = phaseNumber;
    }

}
