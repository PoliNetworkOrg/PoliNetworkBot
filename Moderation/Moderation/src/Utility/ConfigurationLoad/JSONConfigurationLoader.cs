using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Moderation.Utility.ConfigurationLoad
{
    /// <summary>
    /// Represents a configuration loader for loading JSON configuration data.
    /// </summary>
    public class JSONConfigurationLoader : IConfigurationLoader
    {
        /// <summary>
        /// Loads configuration data from the specified JSON file.
        /// </summary>
        /// <param name="path">The path to the JSON configuration file.</param>
        /// <returns>An <see cref="IConfigurationRoot"/> containing the loaded configuration data.</returns>
        /// <exception cref="FileNotFoundException">Thrown if the specified JSON file does not exist.</exception>
        /// <exception cref="ArgumentException">Thrown if the provided path is not a JSON file.</exception>
        /// <exception cref="JsonException">Thrown if the specified JSON file is not valid.</exception>
        public IConfigurationRoot LoadConfiguration(string path)
        {
            bool notFound = !File.Exists(path);
            bool notJson = !Path.HasExtension(path) || !Path.GetExtension(path).Equals(".json", StringComparison.OrdinalIgnoreCase);

            if (notFound) throw new FileNotFoundException("Unable to locate specified JSON file.", path);
            if (notJson) throw new ArgumentException("Only JSON files are supported.", nameof(path));

            try
            {
                return new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(path)
                    .Build();
            }
            catch (JsonException ex)
            {
                throw new JsonException("The specified JSON file is not valid.", ex);
            }
            catch (IOException ex)
            {
                throw new IOException("Could not open file.", ex);
            }

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JSONConfigurationLoader"/> class.
        /// </summary>
        public JSONConfigurationLoader() : base() { }
    }
}
