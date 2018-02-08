using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour
{

    public GameObject navigationPanel;
    public GameObject rightBtnObject;
    public GameObject leftBtnObject;
    public GameObject upBtnObject;
    public GameObject downBtnObject;
    public GameObject doorBtnObject;
    public GameObject doorOpenPanel;
    private float speed = 40.0f;

    bool movingLeft;
    bool movingRight;
    bool movingUp;
    bool movingDown;

    public enum MoveDirection { stop,left,right,up,down };
    MoveDirection movedirection;

    void Awake() {
        rightBtnObject.SetActive(false);
        movedirection = MoveDirection.stop;
        movingLeft = false;
        movingRight = false;
        movingUp = false;
        movingDown = false;
        doorOpenPanel.SetActive(false);
    }

    IEnumerator Left() {
        leftBtnObject.SetActive(false);
        MoveInDirection(MoveDirection.left);
        yield return new WaitForSeconds(4.0f);
        rightBtnObject.SetActive(true);
        downBtnObject.SetActive(true);
        upBtnObject.SetActive(true);
    }

    IEnumerator Right() {
        rightBtnObject.SetActive(false);
        MoveInDirection(MoveDirection.right);
        yield return new WaitForSeconds(4.0f);
        leftBtnObject.SetActive(true);
        downBtnObject.SetActive(true);
        upBtnObject.SetActive(true);
    }

    IEnumerator Up() {
        upBtnObject.SetActive(false);
        MoveInDirection(MoveDirection.up);
        yield return new WaitForSeconds(4.0f);
        downBtnObject.SetActive(true);
        leftBtnObject.SetActive(true);
        rightBtnObject.SetActive(true);
    }

    IEnumerator Down() {
        downBtnObject.SetActive(false);
        MoveInDirection(MoveDirection.down);
        yield return new WaitForSeconds(4.0f);
        upBtnObject.SetActive(true);
        leftBtnObject.SetActive(true);
        rightBtnObject.SetActive(true);
    }

    IEnumerator Exit(int scene) {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scene);
        StopAllCoroutines();
    }

    public void OnLeftBtnPress() {
        StartCoroutine(Left());
    }

    public void OnRightBtnPress() {
        StartCoroutine(Right());
    }

    public void OnUpBtnPress() {
        StartCoroutine(Up());
    }

    public void OnDownBtnPress() {
        StartCoroutine(Down());
    }

    public void OnDoorBtnClicked() {
        doorOpenPanel.SetActive(true);
        StartCoroutine(Exit(2));
    }

    public void MoveInDirection(MoveDirection direction) {

        Vector3 offset;
        offset = Vector3.zero;

        switch (direction) {
            case MoveDirection.left:
                movingLeft = true;
                break;
            case MoveDirection.right:
                movingRight = true;
                break;
            case MoveDirection.up:
                movingUp = true;
                break;
            case MoveDirection.down:
                movingDown = true;
                break;
        }
    }

    void LateUpdate() {

        if (movingLeft == true) {
            float step = speed * Time.deltaTime;
            //navigationPanel.transform.position = Vector3.MoveTowards(navigationPanel.transform.position, Vector3.left, step);
            //if (navigationPanel.transform.position == new Vector3(0, 0, 0)) {
            //    movingLeft = false;
            //}
        }

        if (movingRight == true & movingLeft != true) {
            float step = speed * Time.deltaTime;
            //navigationPanel.transform.position = Vector3.MoveTowards(navigationPanel.transform.position, Vector3.right, step);
            //if (navigationPanel.transform.position == new Vector3(128, 0, 0)) {
            //    movingRight = false;
            //}
        }

        if (movingUp == true & movingDown != true)
        {
            float step = speed * Time.deltaTime;
            //navigationPanel.transform.position = Vector3.MoveTowards(navigationPanel.transform.position, Vector3.up, step);
            //if (navigationPanel.transform.position == new Vector3(128, 0, 0))
            //{
            //    movingRight = false;
            //}
        }

        if (movingDown == true & movingUp != true)
        {
            float step = speed * Time.deltaTime;
            //navigationPanel.transform.position = Vector3.MoveTowards(navigationPanel.transform.position, Vector3.down, step);
            //if (navigationPanel.transform.position == new Vector3(128, 0, 0))
            //{
            //    movingRight = false;
            //}
        }

    }

}
