# MraaSharp
.NET(C#) binding/wrapper for Intel MRAA library.

The wrapper library written in 100% pure C#. So you don't need to build or write SWIG wrapper.

## Testing Environment
- Intel Edison + Breakout Board Kit
  - Intel Edison® Board Firmware Software Release 2.1
- Mono 4.0.3

## Status
|API|Status|
|---|------|
|aio||
|common|:heavy_check_mark:|
|gpio|InProgress|
|i2c||
|iio||
|pwm|:heavy_check_mark:|
|spi||
|uart|:heavy_check_mark:|



## Sample Code
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MraaSharp;

namespace ConsoleApplication21
{
    class Program
    {
        static void Main(string[] args)
        {
            Mraa.Initialize();
            Console.WriteLine("Version: {0}", Mraa.Version);
            Console.WriteLine("PlatformName: {0}", Mraa.PlatformName);

            var gpio = new Gpio(MraaIntelEdisonMiniboard.J17_8, MraaGpioDir.Out);
            Console.WriteLine("Gpio Pin: {0}", gpio.Pin);
            Console.WriteLine("Gpio PinRaw: {0}", gpio.PinRaw);

            while (true)
            {
                gpio.Write(MraaGpioValue.High);
                Thread.Sleep(1000);
                gpio.Write(MraaGpioValue.Low);
                Thread.Sleep(1000);
            }
        }
    }

}
```

... and you can manipulate MRAA interactively with C# Shell (Mono's csharp command).

```
root@harusame:~/tmp# mono /usr/lib/mono/4.5/csharp.exe
Mono C# Shell, type "help;" for help

Enter statements below.
csharp> LoadAssembly("MraaSharp");
csharp> using MraaSharp;
csharp> Mraa.Initialize();
csharp> Mraa.Version;
"v0.8.0"
csharp> Mraa.PlatformName;
"Intel Edison"
csharp> var gpio = new Gpio(MraaIntelEdisonMiniboard.J17_8, MraaGpioDir.Out);
csharp> gpio.Pin
7
csharp> gpio.Write(MraaGpioValue.High);
csharp> gpio.Write(MraaGpioValue.Low);
csharp>
```
