﻿using CatLib.Contracts.Base;
using CatLib.Container;
using System.Collections;

namespace CatLib.Base
{
    /// <summary>
    /// 服务提供者
    /// </summary>
    public abstract class CServiceProvider : CComponent
    {

        public virtual void Init() { }

        public virtual EProviderProcess ProviderProcess { get { return EProviderProcess.NORMAL; } }

        public virtual IEnumerator OnProviderProcess() { yield break; }

        abstract public void Register();

    }

}