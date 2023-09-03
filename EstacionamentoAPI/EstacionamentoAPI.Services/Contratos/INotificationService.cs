using EstacionamentoAPI.Domain.DTO;

namespace EstacionamentoAPI.Services.Contratos
{
    public interface INotificationService
    {
        Notification Notification { get; }
        public bool HasErrors { get { return Notification.Errors.Any(); } }
    }
}
