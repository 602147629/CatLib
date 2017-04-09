/*
 * This file is part of the CatLib package.
 *
 * (c) Yu Bin <support@catlib.io>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * Document: http://catlib.io/
 */

using System;
using CatLib.API.Container;

namespace CatLib.Container{

    class BoundProxy : IBoundProxy{

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="target"></param>
        /// <param name="bindData"></param>
        /// <returns></returns>
        public object Bound(object target , BindData bindData){

            if (target == null) { return null; }

            IInterception[] interceptors = bindData.GetInterceptors();
            if (interceptors == null) { return target; }

            IInterceptingProxy proxy = null;
            if (target is MarshalByRefObject) {

                if(target.GetType().IsDefined(typeof(AOPAttribute) , false))
                {
                    proxy = CreateRealProxy(interceptors, target);
                }

            }

            if (proxy != null)
            {
                AddInterceptions(proxy, interceptors);
                return proxy.GetTransparentProxy();
            }

            return target;

        }

        /// <summary>
        /// ������̬����
        /// </summary>
        /// <param name="t"></param>
        /// <param name="target"></param>
        /// <param name="additionalInterfaces"></param>
        /// <returns></returns>
        public IInterceptingProxy CreateRealProxy(IInterception[] interceotors, object target)
        {
            return new InterceptingRealProxy(target);
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="proxy">����</param>
        /// <param name="interceotors">Ҫ���ӵ�������</param>
        /// <returns></returns>
        private IInterceptingProxy AddInterceptions(IInterceptingProxy proxy , IInterception[] interceotors)
        {
            for (int i = 0; i < interceotors.Length; i++)
            {
                proxy.AddInterception(interceotors[i]);
            }
            return proxy;
        }

    }

}