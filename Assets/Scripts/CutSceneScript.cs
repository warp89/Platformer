using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneScript : MonoBehaviour
{
    [SerializeField]
    private Cinemachine.CinemachineVirtualCameraBase camera;
    [SerializeField]
    private Transform slideRail;
    private Transform player;
    [SerializeField]
    private GameObject cutSceneCanvas;
    [SerializeField]
    private Transform endPoint;
    private bool startCutScene = false;
    [SerializeField]
    private float cameraSpeed = 3;

    private void Start()
    {
        player = camera.Follow;
    }

    public void StartCutScene(GameObject trigger, GameObject playerCollider)
    {
        playerCollider.GetComponent<PlayerInput>().TakingControl(false);
        cutSceneCanvas.SetActive(true);
        camera.Follow = slideRail;
        slideRail.position = endPoint.position;
        startCutScene = true;
        Destroy(trigger);
    }

    private void EndCutScene()
    {
        player.GetComponent<PlayerInput>().TakingControl(true);
        Destroy(cutSceneCanvas);
        camera.Follow = player;
        startCutScene = false;
        Destroy(slideRail.gameObject);
        Destroy(gameObject);
    }
    private void Update()
    {
        if (startCutScene)
        {
            slideRail.position = Vector2.MoveTowards(slideRail.position, player.position, Time.deltaTime * cameraSpeed);
        }
        if (slideRail.position == player.position)
        {
            EndCutScene();
        }

    }


}
