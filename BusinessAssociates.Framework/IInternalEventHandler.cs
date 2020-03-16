namespace BusinessAssociates.Framework
{
    public interface IInternalEventHandler
    {
        void Handle(object @event);
    }
}