using EstacionamentoAPI.Domain.DTO;
using EstacionamentoAPI.Services.Contratos;

namespace EstacionamentoAPI.Services
{
    public class NotificationService : INotificationService
    {
        private readonly Notification notification = new();
        public Notification Notification { get { return notification; } }
    }
}
