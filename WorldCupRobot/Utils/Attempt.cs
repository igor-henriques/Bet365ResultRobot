namespace MainRobotOrchester.Utils
{
    public class Attempt
    {
        /// <summary>
        /// Assincronamente realiza X tentativas de executar o delegate passado em parâmetro
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logger">ILogger responsável por informar das tentativas</param>
        /// <param name="function">Método que será executado</param>
        /// <param name="attempts">Quantas vezes o método será tentado. Valor default = 3</param>
        /// <returns></returns>
        public static async Task<T> RunAsync<T>(ILogger<T> logger, Func<Task<T>> function, int attempts = 3) where T : class
        {
            T response = default(T);

            while (attempts > 0)
            {
                try
                {
                    response = await function();

                    if (!response.Equals(default(T)))
                        break;
                }
                catch (Exception e)
                {
                    logger?.LogError($"Tentativa falhou. Tentativas restantes: {--attempts}\n{e.Message}");

                    if (attempts <= 0) throw;
                }
            }

            return response;
        }

        /// <summary>
        /// Sincronamente realiza X tentativas de executar o delegate passado em parâmetro
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logger">ILogger responsável por informar das tentativas</param>
        /// <param name="function">Método que será executado</param>
        /// <param name="attempts">Quantas vezes o método será tentado. Valor default = 3</param>
        /// <returns></returns>
        public static T Run<T>(ILogger<Attempt> logger, Func<T> function, int attempts = 3)
        {
            T response = default(T);

            while (attempts > 0)
            {
                try
                {
                    response = function();

                    if (!response.Equals(default(T)))
                        break;
                }
                catch (Exception e)
                {
                    logger?.LogError($"Tentativa falhou. Tentativas restantes: {--attempts}\n{e.Message}");

                    if (attempts <= 0) throw;

                    Task.Delay(TimeSpan.FromSeconds(20)).GetAwaiter().GetResult();
                }
            }

            return response;
        }
    }
}
