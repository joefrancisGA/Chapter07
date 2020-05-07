using System;

namespace EGMS.BusinessAssociates.Framework
{
    public abstract class Entity<TId> : IInternalEventHandler
    {

        protected Action<object> ParentHandler;

        protected Entity(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }

        private readonly Action<object> _applier;
        
        public TId Id { get; protected set; }


        protected Entity() { }

        protected abstract void When(object @event);

        public abstract void OnLoadInit(Action<object> parentHandler);

        protected void Apply(object @event)
        {
            When(@event);
            _applier(@event);
        }

        void IInternalEventHandler.Handle(object @event) => When(@event);
    }
}