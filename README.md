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
    }
}
```

This library has three types of log: `Log`, `LogWarning`, `LogError`.

You also can pass a second parameter, a boolean, on the *log functions* to enable the stack trace loggin.

<h1 align="center">
  <img src="/assets/images/debugexample.png" alt="example" width="650px" />
</h1>

### Where can I get it?

First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [PampaDevs.Debug](https://www.nuget.org/packages/PampaDevs.Debug/) from the package manager console:
```
PM> Install-Package PampaDevs.Debug -Version 1.0.0
```

### License, etc.

PampaDevs.Debug is Copyright &copy; 2020 [felipe-allmeida](https://github.com/felipe-allmeida) under the [MIT license](licenses/LICENSE.txt).