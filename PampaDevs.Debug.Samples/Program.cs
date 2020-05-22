using System;
using PampaDevs.Debug;

namespace PampaDevs.Debug.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Log("HelloWorld");
            Debug.LogWarning("HelloWorld");
            Debug.LogError("HelloWorld");

            FirstMethod();
        }

        static void FirstMethod()
        {
            Debug.Log("Log with stacktrace from FirstMethod()", true);

            SecondMethod("text", 10);
        }

        static void SecondMethod(string text, int number)
        {
            Debug.Log("Log with stacktrace and parameters from SecondMethod()", true);
        }
    }
}
