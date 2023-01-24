namespace SophiApp.Contracts.Services
{
    using System.Threading.Tasks;

    /// <summary>
    /// Initializes the app services.
    /// </summary>
    internal interface IActivationService
    {
        /// <summary>
        /// Performs activation of the app services.
        /// </summary>
        /// <param name="activationArgs">Activation service arguments.</param>
        Task ActivateAsync(object activationArgs);
    }
}