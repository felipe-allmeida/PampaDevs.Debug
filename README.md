## PampaDevs
We are a community of developers, designers and enthusiasts that aim to share knowledge. Besides that, we like to help beginners and create useful tools for the community.

How to find us?
* On [Discord](https://discord.gg/FvkzVcr)
* On [GitHub](https://github.com/Pampa-Devs)
* On [Youtube](https://www.youtube.com/channel/UC0qwajlgqCKFnyoTbsycMOg)

### What is PampaDevs.Debug?

Debug is a simple little library built to standardize **console** logs and provide a easy way to check
the method stacktrace.

### How do I get started?

On your code, simply call `Debug.Log(string)` as in the following example:
```C#
class Program
{
    static void Main()
    {
        Debug.Log("HelloWorld"); 
        // Output: [Log]..........(0:0:0:738): HelloWorld
    }
}
```

This library has three types of log: `Log`, `LogWarning`, `LogError`.

You also can pass a second parameter, a boolean, on the **log method** to enable the stack trace log.

```C#
Debug.Log("HelloWorld", true);
```

### Example Code

```C#
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
```

### Default Log Ouput

<h1 align="center">
  <img src="/assets/images/defaultexample.png" alt="default" width="650px" />
</h1>

The default logger by default is enabled.

You can enable/disable it by setting `Debug.DefaultLoggerEnabled` value;

### Console Log Output

<h1 align="center">
  <img src="/assets/images/consoleexample.png" alt="console" width="650px" />
</h1>

The console logger by default is disabled.

You can enable/disable it by setting `Debug.ConsoleLoggerEnabled` value;

### Where can I get it?

First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [PampaDevs.Debug](https://www.nuget.org/packages/PampaDevs.Debug/) from the package manager console:
```
PM> Install-Package PampaDevs.Debug -Version 1.0.0
```

### License, etc.

PampaDevs.Debug is Copyright &copy; 2020 [felipe-allmeida](https://github.com/felipe-allmeida) under the [MIT license](PampaDevs.Debug/Licenses/LICENSE.txt).