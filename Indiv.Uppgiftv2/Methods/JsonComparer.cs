using Newtonsoft.Json.Linq;
using System;

namespace Indiv.Uppgiftv2.Methods
{
    public static class JsonComparer
    {
        private static string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "changes.log");

        public static void LogJsonDifferences(string originalJson, string modifiedJson)
        {
            // Parse JSON strings to JObject
            JObject originalObject = JObject.Parse(originalJson);
            JObject modifiedObject = JObject.Parse(modifiedJson);

            // Log changes
            LogChanges(originalObject, modifiedObject);
        }

        private static void LogChanges(JToken original, JToken modified, string path = "$")
        {
            if (JToken.DeepEquals(original, modified))
            {
                return; // No differences found
            }

            if (original.Type != modified.Type)
            {
                // Handle type mismatch if necessary
                LogToFile($"Type mismatch at {path}: Original: {original.Type}, Modified: {modified.Type}");
                return;
            }

            if (original is JObject originalObj && modified is JObject modifiedObj)
            {
                // Compare properties
                foreach (var prop in originalObj.Properties())
                {
                    string propName = prop.Name;
                    JToken originalValue = prop.Value;
                    JToken modifiedValue = modifiedObj[propName];

                    if (modifiedValue == null)
                    {
                        LogToFile($"Property {path}.{propName} is missing in modified JSON.");
                    }
                    else
                    {
                        LogChanges(originalValue, modifiedValue, $"{path}.{propName}");
                    }
                }

                // Check for additional properties in modified JSON
                foreach (var prop in modifiedObj.Properties())
                {
                    string propName = prop.Name;
                    if (originalObj[propName] == null)
                    {
                        LogToFile($"Additional property {path}.{propName} found in modified JSON.");
                    }
                }
            }
            else if (original is JArray originalArr && modified is JArray modifiedArr)
            {
                // Compare arrays (not fully implemented, modify as per your needs)
                for (int i = 0; i < originalArr.Count || i < modifiedArr.Count; i++)
                {
                    JToken originalItem = i < originalArr.Count ? originalArr[i] : null;
                    JToken modifiedItem = i < modifiedArr.Count ? modifiedArr[i] : null;

                    LogChanges(originalItem, modifiedItem, $"{path}[{i}]");
                }
            }
            else
            {
                // Compare primitive values
                if (!JToken.DeepEquals(original, modified))
                {
                    string changeDetails = $"Value mismatch at {path}: Original: {original}, Modified: {modified}";
                    LogToFile(changeDetails);
                }
            }
        }

        private static void LogToFile(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
    }
}
