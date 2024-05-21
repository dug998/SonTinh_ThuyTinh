using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class PopupNotife : PopupBase
{
    public static MessageUi _currentMessage;
    public MessageUi _messageError_1, messageError_2, _messageDefault_1, _messageDefault_2;

    public Queue<object> _queueMess = new Queue<object>();
    public override void Show(object data = null)
    {
        _queueMess.Enqueue(data);
        ShowMess();
    }
    void ShowMess()
    {
        if (_currentMessage != null)
        {
            return;
        }
        if (_queueMess.Count <= 0)
        {
            return;

        }
        DataMessage _ms = (DataMessage)_queueMess.Dequeue();
        if (_ms == null)
        {
            return;
        }
        if (_ms._typeMessage == TypeMessage.Error)
        {
            _currentMessage = _messageError_1;

        }
        else if (_ms._typeMessage == TypeMessage.None)
        {
            _currentMessage = _messageDefault_1;
        }
        else
        {
            _currentMessage = _messageDefault_2;
        }
        _currentMessage.SetMessage(_ms);
        _currentMessage.Show();
        StartCoroutine(DelayCall(2, () => HideMess()));
    }
    public void HideMess()
    {
        _currentMessage.Hide();
        _currentMessage = null;
        ShowMess();

    }
    IEnumerator DelayCall(float delay, System.Action action)
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
    }
}