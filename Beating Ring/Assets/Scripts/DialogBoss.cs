using System.Collections;

    private bool _isTyping;
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
        }
