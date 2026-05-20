namespace ConferenceMVC.Web.Services
{
    public interface IActiveEventService
    {
        Task<int?> GetActiveConferenceIdAsync();
    }
}
