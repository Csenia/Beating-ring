using System.Collections;using System.Collections.Generic;using TMPro;using UnityEngine;using UnityEngine.UI;public class DialogBoss : MonoBehaviour{    [SerializeField]private GameObject _dialogPanel;    [SerializeField] private TextMeshProUGUI _nameText;    [SerializeField] private TextMeshProUGUI _dialogText;    [SerializeField] private string _npcName;    [SerializeField] private string _playerName;    [SerializeField] private string[] _dialogSequence;    private int _index;    [SerializeField] private float _wordSpeed;    [SerializeField] private bool _playerIsClose;

    private bool _isTyping;    void Update()    {        if (_playerIsClose && Input.GetMouseButtonDown(0))        {            if (_dialogPanel != null && _dialogPanel.activeInHierarchy)
            {
                if (_isTyping)
                {
                    StopAllCoroutines();
                    if (_dialogText != null)
                    {
                        _dialogText.text = _dialogSequence[_index].Split(':')[1];
                    }
                    _isTyping = false;
                }
                else
                {
                    NextLine();
                }
            }
            else
            {
                if (_dialogPanel != null)
                {
                    _dialogPanel.SetActive(true);
                    StartCoroutine(Typing());
                }
            }
        }    }    public void ZeroText()    {        if (_dialogText != null)        {            _dialogText.text = "";        }        if (_nameText != null)        {            _nameText.text = "";        }        _index = 0;        if (_dialogPanel != null)        {            _dialogPanel.SetActive(false);        }    }    IEnumerator Typing()    {        _isTyping = true;        if (_dialogSequence != null && _dialogSequence.Length > _index)        {            string[] parts = _dialogSequence[_index].Split(':');            if (parts[0] == "P")            {                if (_nameText != null)                {                    _nameText.text = _playerName;                }            }            else if (parts[0] == "N")            {                if (_nameText != null)                {                    _nameText.text = _npcName;                }            }            if (_dialogText != null)            {                foreach (char letter in parts[1].ToCharArray())                {                    _dialogText.text += letter;                    yield return new WaitForSeconds(_wordSpeed);                }            }        }        _isTyping = false;    }
    public void NextLine()    {        if (_dialogSequence != null && _index < _dialogSequence.Length - 1)        {            _index++;            if (_dialogText != null)            {                _dialogText.text = "";            }            StartCoroutine(Typing());        }        else        {            ZeroText();        }    }    private void OnTriggerEnter2D(Collider2D other)    {        if (other.CompareTag("Player"))        {            _playerIsClose = true;            Debug.Log("Player entered trigger zone");        }    }    private void OnTriggerExit2D(Collider2D other)    {        if (other.CompareTag("Player"))        {            _playerIsClose = false;            Debug.Log("Player exited trigger zone");            ZeroText();        }    }}