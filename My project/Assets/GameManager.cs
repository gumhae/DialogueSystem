using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextAsset txt; // ��ȭ ���� ������ �ؽ�Ʈ ����
    string[,] Sentence; // ��ȭ ������ ������ �迭
    int lineSize, rowSize; // �迭�� ũ�� ������ ������ ����

    public Text dialogueText; // ��ȭ ������ ǥ���� �ؽ�Ʈ
    public Text nameText; // ��ȭ ������ �̸��� ǥ���� �ؽ�Ʈ
    private int currentLine = 0; // ���� ��ȭ �������� ����

    public GameObject Dialogue; // ��ȭ UI�� ��Ÿ���� ���� ������Ʈ

    void Start()
    {
        // �ؽ�Ʈ ���Ͽ��� ��ȭ ������ �޾ƿ� �� ���Ϳ� ������ ������.
        string currentText = txt.text.Substring(0, txt.text.Length - 1);

        string[] line = currentText.Split('\n'); // ���͸� �������� ��ȭ �����͸� �� ������ �и�
        lineSize = line.Length; // ��ȭ �������� �� ��
        rowSize = line[0].Split('\t').Length; // ��ȭ �������� �� �� (������ ����)
        Sentence = new string[lineSize, rowSize]; // ��ȭ �����͸� ������ 2���� �迭 ����

        // ��ȭ ������ �迭�� ����
        for (int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split('\t'); // �� ���ڸ� �������� �� ���� �� ������ �и�
            for (int j = 0; j < rowSize; j++)
            {
                Sentence[i, j] = row[j]; // ��ȭ �����͸� �迭�� ����
            }
        }

        // ��ȭ ����
        StartDialogue();
    }

    void Update()
    {
        // ��ȭ ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++; // ���� ��ȭ�� �̵�
            if (currentLine < lineSize) // ��ȭ ������ ���� �� ������ ���
            {
                StartDialogue();
            }
            else
            {
                // ��ȭ�� �����
                EndDialogue(); // ��ȭ UI�� ��Ȱ��ȭ
            }
        }
    }

    void StartDialogue()
    {
        // ���� ������ ��ȭ ����� �̸��� �ؽ�Ʈ UI�� ǥ��
        nameText.text = Sentence[currentLine, 0]; // ��ȭ ������ �̸�
        dialogueText.text = Sentence[currentLine, 1]; // ��ȭ ����
    }

    void EndDialogue()
    {
        // ��ȭ ���� �� ��ȭ UI�� ��Ȱ��ȭ
        Dialogue.SetActive(false);
    }
}
