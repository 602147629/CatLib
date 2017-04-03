﻿/*
 * This file is part of the CatLib package.
 *
 * (c) Yu Bin <support@catlib.io>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * Document: http://catlib.io/
 */

using UnityEngine;
using CatLib.API;

/// <summary>
/// 程序入口
/// Program Entry
/// </summary>
public class Program : MonoBehaviour {

    /// <summary>
    /// 初始化程序
    /// </summary>
    public void Awake()
    {
        IApplication application = gameObject.AddComponent<CatLib.Application>();
        application.Bootstrap(CatLib.Bootstrap.BootStrap).Init();
        GameObject.DontDestroyOnLoad(gameObject);
    }

}
