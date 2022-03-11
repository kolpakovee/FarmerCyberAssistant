using System.Threading.Tasks;

namespace App.Models
{
    public interface IAsyncAccount
    {
        string Username { get; }
        CustomerInfo CustomerInfo { get; }
        // Возвращает массив рекомендаций (2)
        Recommendation[] GetRecommendations(Field field);
        // Передаю ему поле - он для него скачивает рекомендации (1)
        Task<string[]> LoadRecommendationsAsync(Field field);
        // Обращается к базе данных, перед вызовом надо вроверить UserName is correct.
        Task<string[]> SignInAsync(string username, string password);
        // Бывает ошибка, что уже зарегистрирован.
        Task<string[]> SignUpAsync(string username, string password);
        // После изменений с полем
        Task<string[]> UpdateCustomerInfoAsync();

        /* Also:

        public static bool UsernameIsCorrect(string username);
        public static bool PasswordIsCorrect(string password);

        */
    }
}

