using System;
using System.Collections.Generic;

namespace ET
{
    public interface ILSRollback
    {
    }
    
    public interface ILSRollbackSystem: ISystemType
    {
        void Run(Entity o);
    }
    
    [LSEntitySystem]
    public abstract class LSRollbackSystem<T>: SystemObject, ILSRollbackSystem where T: Entity, ILSRollback
    {
        void ILSRollbackSystem.Run(Entity o)
        {
            this.LSRollback((T)o);
        }

        Type ISystemType.Type()
        {
            return typeof(T);
        }

        Type ISystemType.SystemType()
        {
            return typeof(ILSRollbackSystem);
        }

        protected abstract void LSRollback(T self);
    }
}