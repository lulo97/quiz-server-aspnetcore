using DotNetEnv;

namespace Backend
{
    public static class Const
    {
        public static int getPort()
        {
            string PORT = Environment.GetEnvironmentVariable("BACKEND_PORT") ?? throw new Exception("PORT is null!");
            return Int32.Parse(PORT);
        }
    }
}
