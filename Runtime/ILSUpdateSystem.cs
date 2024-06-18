using System;

namespace ET
{
    public interface ILSUpdate
    {
    }
    
    public interface ILSUpdateSystem: ISystemType, IClassEventSystem
    {
        void Run(LSEntity o);
    }

    [LSEntitySystem]
    public abstract class LSUpdateSystem<T>: SystemObject, ILSUpdateSystem where T: LSEntity, ILSUpdate
    {
        void ILSUpdateSystem.Run(LSEntity o)
        {
            this.LSUpdate((T)o);
        }

        Type ISystemType.Type()
        {
            return typeof(T);
        }

        Type ISystemType.SystemType()
        {
            return typeof(ILSUpdateSystem);
        }

        protected abstract void LSUpdate(T self);
    }
}