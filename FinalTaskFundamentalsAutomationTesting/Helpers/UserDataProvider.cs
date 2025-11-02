using FinalTaskFundamentalsAutomationTesting.Models;
using Newtonsoft.Json;

namespace FinalTaskFundamentalsAutomationTesting.Helpers;

public static class UserDataProvider
{
    /// <summary>
    /// All user data loaded from the JSON file.
    /// </summary>
    private static Dictionary<string, UserData>? _allUsers;

    /// <summary>
    /// Loads user data from the loginData.json file into memory.
    /// </summary>
    /// <exception cref="InvalidOperationException">If deserialization fails.</exception>
    public static void LoadUserData()
    {
        string json = File.ReadAllText(PathHelper.GetTestDataPath("loginData.json"));
        Dictionary<string, UserData>? allUsers = JsonConvert.DeserializeObject<Dictionary<string, UserData>>(json)
            ?? throw new InvalidOperationException("Failed to deserialize user data from JSON.");

        _allUsers = allUsers;
    }

    /// <summary>
    /// Gets user data for the specified user key.
    /// </summary>
    /// <param name="userKey">The key identifying the user.</param>
    /// <returns>The UserData object for the specified user key.</returns>
    /// <exception cref="InvalidOperationException">If user data has not been loaded.</exception>
    /// <exception cref="KeyNotFoundException">If the specified user key does not exist.</exception>
    public static UserData GetUserData(string userKey)
    {
        if (_allUsers == null)
        {
            throw new InvalidOperationException("User data not loaded. Call LoadUserData() first.");
        }

        if (!_allUsers.TryGetValue(userKey, out UserData? userData))
        {
            throw new KeyNotFoundException($"User data for key '{userKey}' not found.");
        }

        return userData;
    }
}
