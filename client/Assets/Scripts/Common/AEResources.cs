using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;

public class AEResources
{

	private static Dictionary<string, UnityEngine.Object> allDic = new Dictionary<string, UnityEngine.Object>();
	public static void Load(string resourcePath, Type systemTypeInstance, Action<UnityEngine.Object> action)
	{
		UnityEngine.Object obj = null;
		if (allDic.ContainsKey(resourcePath))
		{
			obj = allDic[resourcePath];
			action(obj);
			return;
		}
			
		obj = Resources.Load(resourcePath, systemTypeInstance);
		if (obj == null)
		{              
			UnityEngine.Debug.LogError("读取路径错误：");
			UnityEngine.Debug.LogError(resourcePath);
			return;
		}
		allDic.Add(resourcePath , obj);
		action(obj);
	}

	public static void LoadSingle(string resourcePath, Action<UnityEngine.Object> action)
	{
		UnityEngine.Object obj = null;
		if (allDic.ContainsKey(resourcePath))
		{
			obj = allDic[resourcePath];
			action(obj);
			return;
		}
			
		obj = Resources.Load(resourcePath);
		if (obj == null)
		{
			UnityEngine.Debug.LogError("读取路径错误：");
			UnityEngine.Debug.LogError(resourcePath);
			return;
		}
		if (!allDic.ContainsKey(resourcePath))
			allDic.Add(resourcePath , obj);
		action(obj);

	}
}
