using System.Threading;
using System.Threading.Tasks;
using EventHorizon.Blazor.Interop.Sample.Pages.DITesting.Model;
using MediatR;

namespace EventHorizon.Blazor.Interop.Sample.Pages.MediatrTesting.Model
{
    public class RunMediatrEventHandler : INotificationHandler<RunMediatrEvent>
    {
        private readonly IDIRunHandler _handler;

        public RunMediatrEventHandler(IDIRunHandler handler, IDIRunHandler handler2)
        {
            _handler = handler;
            _handler = handler2;
        }

        public async Task Handle(RunMediatrEvent notification, CancellationToken cancellationToken)
        {
            await _handler.Handle(new DIRunEvent());
        }
    }
}
