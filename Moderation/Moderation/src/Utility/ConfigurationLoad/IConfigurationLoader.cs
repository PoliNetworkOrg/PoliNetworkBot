using Microsoft.Extensions.Configuration;

namespace Moderation.Utility.ConfigurationLoad
{
    /// <summary>
    /// Represents an interface for loading configuration data from various sources.
    /// </summary>
    public interface IConfigurationLoader
    {
        /// <summary>
        /// Loads configuration data from the specified path.
        /// </summary>
        /// <param name="path">The path to the configuration data.</param>
        /// <returns>An <see cref="IConfigurationRoot"/> containing the loaded configuration data.</returns>
        IConfigurationRoot LoadConfiguration(string path);
    }
}
