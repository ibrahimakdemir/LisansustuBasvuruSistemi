using System.Text.Json;

namespace GraduateAppProject.MVC.Extensions
{
    public static class SessionExtensions
    {
        public static void SaveToSession<T>(this ISession session, string sessionName, T value)
        {
            var serialized = JsonSerializer.Serialize<T>(value);
            session.SetString(sessionName,serialized);
        }
        public static T GetFromSession<T>(this ISession session, string sessionName) where T : class, new()
        {
            var serializedModel = session.GetString(sessionName);
            if (serializedModel == null)
            {
                return new T();
            }
            var deserializedModel = JsonSerializer.Deserialize<T>(serializedModel);
            return deserializedModel;
        }
    }
}
