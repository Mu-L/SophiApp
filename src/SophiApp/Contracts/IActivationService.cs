namespace SophiApp.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
