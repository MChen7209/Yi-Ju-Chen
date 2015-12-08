using UnityEngine;
using System.Collections;

public class GUIBase : MonoBehaviour 
{
	private string _guiTag;
	private Texture2D _skillImage;
	private float _cooldown;
	private string _cooldownDisplay;
	private bool _isCooldown;
	private int _skillSlot;

//	//Skill details
//	protected bool isSkillCooldown;
//	protected float skillCooldown;
//	protected float skillWait;
//	protected string skillGUIName;

	public GUIBase(string GUITag, string skillImage, int skillSlot)
	{
		_guiTag = GUITag;
		_skillImage = Resources.Load ("skillGUI/" + skillImage) as Texture2D;
		_skillSlot = skillSlot;
	}

	// Use this for initialization
	void Start () 
	{
		_isCooldown = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log(_skillImage);
	}

	public void startCooldown(float theCooldown)
	{
		_cooldown = theCooldown;
		_isCooldown = true;
	}
	
	public void endCooldown()
	{
		_isCooldown = false;
	}

	void OnGUI()
	{
		int xPos = 20;
		int distance = 40;
		int distance2 = 60;

		if (_isCooldown == false)
		{
			GUILayout.BeginArea (new Rect (xPos+(distance * _skillSlot), 7 * Screen.height / 8, 100, 100));
			GUILayout.Label (_skillImage);
			GUILayout.EndArea ();
		}//end if
		else
		{
			_cooldownDisplay = _cooldown.ToString();
			
			GUILayout.BeginArea (new Rect (xPos+(distance * _skillSlot), 7 * Screen.height / 8, 100, 100));
			GUI.color = Color.gray; GUILayout.Label (_skillImage);
			GUILayout.EndArea ();
			GUI.color = Color.white;
			GUIStyle myStyle = new GUIStyle();
			myStyle.fontSize = 30;
			myStyle.fontStyle = FontStyle.Bold;
			myStyle.normal.textColor = Color.white;
			GUI.Label(new Rect(37 + (_skillSlot * 60) , 7 * Screen.height / 8+10, 100, 100), _cooldownDisplay, myStyle);
		}
		
	}

	public void initialize(string GUITag, string skillImage, int skillSlot)
	{
		_guiTag = GUITag;
		_skillImage = Resources.Load ("skillGUI/" + skillImage) as Texture2D;
		_skillSlot = skillSlot;
	}
	
	public string GUITag
	{
		get	{	return _guiTag;		}
		set	{	_guiTag = value;	}
	}
}