using Hangfire;

namespace videostore_be.service
{

    public interface IHangfireService
    {
        void EnqueueSampleJob();
    }

    public class HangfireService : IHangfireService
    {
        private readonly IBackgroundJobClient _backgroundJobClient;

        public HangfireService(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }

        public void EnqueueSampleJob()
        {
            _backgroundJobClient.Enqueue(() => Console.WriteLine("Sample job executed at:2 " + DateTime.Now));
        }
    }

}
