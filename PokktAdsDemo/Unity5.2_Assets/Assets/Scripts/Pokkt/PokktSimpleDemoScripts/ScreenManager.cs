using UnityEngine;
using System.Collections;

public class ScreenManager : MonoBehaviour
{
	// constants
	private const string ScreenOpenParam = "Open";
	private const string IdleScreenStateName = "Idle";
	private const string OpenScreenStateName = "Open";
	private const string CloseSreenStateName = "Close";

	// exposed properties
	public GameObject UICanvas = null;

	// internal states
	private Animator _currentScreen;
	private int _openScreenAnimationId;
		
	void Awake()
	{
	}

	void Start()
	{
		_openScreenAnimationId = Animator.StringToHash(ScreenOpenParam);
		
		// default screen
		OpenDemoSelectorScreen();
	}
	
	void Update()
	{
	}

	public void OpenScreen(string screenName)
	{
		Transform screenToOpenTransform = UICanvas.transform.FindChild(screenName);
		if (screenToOpenTransform != null)
		{
			Animator screenToOpen = screenToOpenTransform.GetComponent<Animator>();
			OpenScreen(screenToOpen);
		}
	}

	public void OpenScreen(Animator screenToOpen)
	{
		if (screenToOpen == null || screenToOpen == _currentScreen)
			return;

		CloseScreen (_currentScreen);

		// open requested screen
		screenToOpen.gameObject.SetActive(true);
		screenToOpen.SetBool(_openScreenAnimationId, true);

		_currentScreen = screenToOpen;
	}

	public void CloseScreen(Animator screenToClose)
	{
		if (screenToClose == null)
			return;

		screenToClose.SetBool (_openScreenAnimationId, false);

		// disable it once the animation is over
		StartCoroutine(DisableScreen(screenToClose, _openScreenAnimationId));
	}

	private IEnumerator DisableScreen(Animator screen, int screenAnimationId)
	{
		bool closedStateReached = false;
		bool shouldClose = true;
		while (!closedStateReached && shouldClose)
		{
			if (!screen.IsInTransition(0))
				closedStateReached = screen.GetCurrentAnimatorStateInfo(0).IsName(CloseSreenStateName);
			
			shouldClose = !screen.GetBool(screenAnimationId);
			
			yield return new WaitForEndOfFrame();
		}
		
		if (shouldClose)
			screen.gameObject.SetActive(false);
	}

	public void OpenDemoSelectorScreen()
	{
		OpenScreen("DemoSelectorScreen");
	}
}
