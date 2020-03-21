namespace EGMS.BusinessAssociates.Framework
{
    public interface IInternalEventHandler
    {
        void Handle(object @event);
    }
}