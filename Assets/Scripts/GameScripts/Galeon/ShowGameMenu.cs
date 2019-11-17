using UnityEngine;
using System.Collections;

public class ShowGameMenu : MonoBehaviour
{
	
	public string m_menuSceneName;
	public enum TPushSceneType { PUSH_SCENE, POP_SCENE};
	public TPushSceneType m_type = TPushSceneType.PUSH_SCENE;
	public bool m_clearReturnScene = false;
	
	protected void Awake()
	{
        //TODO 1: nos registras en el input al boton return con OnReturnPressed.
        InputMgr inputMgr = GameMgr.GetInstance().GetServer<InputMgr>();
        inputMgr.RegisterReturn(OnReturnPressed);
    }
	
	protected void OnReturnPressed()
	{
        SceneMgr sceneMgr = GameMgr.GetInstance().GetServer<SceneMgr>();
        //muestro el menu..
        //TODO 2 if type == TPushSceneType.PUSH_SCENE => PushScene else ReturnScene
        if (m_type == TPushSceneType.PUSH_SCENE)
        {
            Debug.Log("apilamos la escena de menu ");
            sceneMgr.PushScene(m_menuSceneName);
        }
           
        
        else
        {
            Debug.Log("Desapilamos la escena en la cima de la pila");
            sceneMgr.PopScene(m_clearReturnScene);
        }
            

    }

    protected void OnDestroy() 
	{
        //TODO 3 desregistrar el return.
        InputMgr input = GameMgr.GetInstance().GetServer<InputMgr>();
        if (input != null)
        {
            Debug.Log("desregistramos escena");
            input.UnRegisterReturn(OnReturnPressed);
        }

    }

    /*protected virtual void Tick(float deltaTime){}
	protected virtual void Init(){}
	
	protected virtual void End() {}*/
}
