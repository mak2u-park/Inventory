using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 플레이어 오브젝트를 클릭하면 해당 플레이어 정보를 UIManager에 전달하도록 하려고 했으나
// 캔버스가 덮고 있어 정상적으로 클릭이 입력되지 않아 폐기
public class PlayerOnClick : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }
    
    //UI가 아닌 2D 오브젝트이기 때문에 OnMouseDown를 사용
    public void OnMouseDown()
    {
        Debug.Log(_player.playerName);
        UIManager.instance._player = _player;
    }
}
