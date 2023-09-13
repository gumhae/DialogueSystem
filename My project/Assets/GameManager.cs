using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextAsset txt; // 대화 내용 저장할 텍스트 파일
    string[,] Sentence; // 대화 내용을 저장할 배열
    int lineSize, rowSize; // 배열의 크기 정보를 저장할 변수

    public Text dialogueText; // 대화 내용을 표시할 텍스트
    public Text nameText; // 대화 상대방의 이름을 표시할 텍스트
    private int currentLine = 0; // 현재 대화 진행중인 라인

    public GameObject Dialogue; // 대화 UI를 나타내는 게임 오브젝트

    void Start()
    {
        // 텍스트 파일에서 대화 내용을 받아온 후 엔터와 탭으로 나눈다.
        string currentText = txt.text.Substring(0, txt.text.Length - 1);

        string[] line = currentText.Split('\n'); // 엔터를 기준으로 대화 데이터를 줄 단위로 분리
        lineSize = line.Length; // 대화 데이터의 줄 수
        rowSize = line[0].Split('\t').Length; // 대화 데이터의 열 수 (탭으로 구분)
        Sentence = new string[lineSize, rowSize]; // 대화 데이터를 저장할 2차원 배열 생성

        // 대화 내용을 배열에 저장
        for (int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split('\t'); // 탭 문자를 기준으로 한 줄을 열 단위로 분리
            for (int j = 0; j < rowSize; j++)
            {
                Sentence[i, j] = row[j]; // 대화 데이터를 배열에 저장
            }
        }

        // 대화 시작
        StartDialogue();
    }

    void Update()
    {
        // 대화 진행
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++; // 다음 대화로 이동
            if (currentLine < lineSize) // 대화 라인이 아직 덜 끝났을 경우
            {
                StartDialogue();
            }
            else
            {
                // 대화가 종료됨
                EndDialogue(); // 대화 UI를 비활성화
            }
        }
    }

    void StartDialogue()
    {
        // 현재 라인의 대화 내용과 이름을 텍스트 UI에 표시
        nameText.text = Sentence[currentLine, 0]; // 대화 상대방의 이름
        dialogueText.text = Sentence[currentLine, 1]; // 대화 내용
    }

    void EndDialogue()
    {
        // 대화 종료 시 대화 UI를 비활성화
        Dialogue.SetActive(false);
    }
}
