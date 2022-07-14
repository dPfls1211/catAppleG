using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCreate : MonoBehaviour {
    public Apple[] appleObject;
    public Transform applePosition;

    private Transform[] applePositionArr;
    private Vector2[] positionArray;
    int applePositionSize;
    // Use this for initialization
    void Start () {
        applePositionSize = applePosition.childCount; //applePosition 이라는 객체에 하위객체가 몇개 있는지 세줌(3개 있음)
        positionArray = new Vector2[applePositionSize]; 
        applePositionArr = new Transform[applePositionSize]; 

        for(int i = 0; i < applePositionSize; i++) {
            positionArray[i] = applePosition.GetChild(i).transform.position; //각 하위객체에 포지션을 배열에 넣어주는? 지정해줌
            applePositionArr[i] = applePosition.GetChild(i); //그 하위객체를 배열에 넣어줌?
        }
        InitCreateApple(); //함수 호출
    }
    public void InitCreateApple()
    {
        if (appleObject.Length > 0)
        {
            for (int i = 0; i < applePositionSize; i++) //시작할때 사과 랜덤으로 생성
            {
                Apple createdApple = Instantiate(randomApple());
                createdApple.transform.SetParent(applePositionArr[i]); //applePosition에 있는 하위 객체에 각각 사과를 넣어 하위객체를 부모객체로 지정. 하고 
                createdApple.transform.localPosition = new Vector2(0, 0); //그 부모객체를 (0,0)으로 포지션 지정
            }
        }
    }
    private Apple randomApple()
    {
        return appleObject[Random.Range(0, appleObject.Length)];
    }

    public void CreatApple()
    {
        
        // 맨 뒤에 포지션엔 사과가 없으니까 거기다가 생성
        
        Apple createdApple = Instantiate(appleObject[Random.Range(0, appleObject.Length)]);
        createdApple.transform.SetParent(applePositionArr[applePositionSize - 1]);
        createdApple.transform.localPosition = new Vector2(0, 0);
    }

    public void SortApple()
    {
        // 뒤에 있는걸 다 앞으로 끌어오고
        for (int i = 1; i < applePositionSize; i++)
        {
            Apple apple = applePositionArr[i].GetChild(0).GetComponent<Apple>();
            apple.transform.SetParent(applePositionArr[i - 1]);
            apple.transform.localPosition = new Vector2(0, 0);


        }
        //for (int i = 0; i < applePositionSize; i++)
        //{

        //        for (int j = i+1; j < applePositionSize; j++)
        //        {
        //        //Prefabs.GetChild(i).gameObject;

        //            applePositionArr[j-1] = applePositionArr[j];
        //             applePositionArr[j-1] = applePosition.GetChild(i);
        //            applePosition.transform.SetParent(applePositionArr[j-1]);
        //            applePosition.transform.localPosition = new Vector2(0, 0);
        //        }

        //}
    }
}
