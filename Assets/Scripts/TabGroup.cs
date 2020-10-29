﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
	public List<GameObject> objectsToSwap;
	
	[SerializeField]
	private TabButton selectedTab;

	[Header("State Sprites")]
	public Sprite tabIdle;
	public Sprite tabHover;
	public Sprite tabActive;

    public void Subscribe(TabButton button)
	{
		if (tabButtons == null) tabButtons = new List<TabButton>();

		tabButtons.Add(button);

	}

	public void OnTabEnter(TabButton button)
	{
		ResetTabs();

		if(selectedTab == null || button != selectedTab)
			button.background.sprite = tabHover;
	}
	public void OnTabExit(TabButton button)
	{
		ResetTabs();
	}
	public void OnTabSelected(TabButton button)
	{
		if (selectedTab != null)
			selectedTab.Deselect();

		selectedTab = button;

		selectedTab.Selecte();

		ResetTabs();
		button.background.sprite = tabActive;

		int index = button.transform.GetSiblingIndex();
		for (int i = 0; i < objectsToSwap.Count; i++)
		{
			if (i == index)
				objectsToSwap[i].SetActive(true);
			else
				objectsToSwap[i].SetActive(false);
		}
	}

	public void ResetTabs()
	{
		foreach(TabButton button in tabButtons)
		{
			if (selectedTab != null && button == selectedTab) continue;

			button.background.sprite = tabIdle;
		}
	}

}
