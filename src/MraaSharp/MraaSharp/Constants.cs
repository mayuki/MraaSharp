using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MraaSharp
{
    public enum MraaPlatformOffset : int
    {
        MainPlatform = 0,
        SubPlatform = 1,
    }

    public enum MraaPlatformOffsetU8 : byte
    {
        MainPlatform = 0,
        SubPlatform = 1,
    }

    public enum MraaGpioValue
    {
        Fatal = -1,
        High = 1,
        Low = 0,
    }

    /// <summary>
    /// Gpio Edge types for interupts
    /// </summary>
    public enum MraaGpioEdge
    {
        /// <summary>No interrupt on Gpio</summary>
        None = 0,
        /// <summary>Interupt on rising & falling</summary>
        Both = 1,
        /// <summary>Interupt on rising only</summary>
        Rising = 2,
        /// <summary>Interupt on falling only</summary>
        Falling = 3,
    }

    /// <summary>
    /// Gpio Direction options
    /// </summary>
    public enum MraaGpioDir
    {
        /// <summary>Output. A Mode can also be set</summary>
        Out = 0,
        /// <summary>Input</summary>
        In = 1,
        /// <summary>Output. Init High</summary>
        OutHigh = 2,
        /// <summary>Output. Init Low</summary>
        OutLow = 3,
    }

    /// <summary>
    /// Gpio Output modes
    /// </summary>
    public enum MraaGpioMode
    {
        /// <summary>Default. Strong High and Low</summary>
        Strong = 0,
        /// <summary>Interupt on rising & falling</summary>
        PullUp = 1,
        /// <summary>Interupt on rising only</summary>
        PullDown = 2,
        /// <summary>Interupt on falling only</summary>
        HiZ = 3,
    }

    /// <summary>
    /// MRAA supported platform types
    /// </summary>
    public enum MraaPlatform
    {
        /// <summary>The Generation 1 Galileo platform (RevD)</summary>
        IntelGalileoGen1 = 0,
        /// <summary>The Generation 2 Galileo platform (RevG/H)</summary>
        IntelGalileoGen2 = 1,
        /// <summary>The Intel Edison (FAB C)</summary>
        IntelEdisonFabC = 2,
        /// <summary>The Intel DE3815 Baytrail NUC</summary>
        IntelDe3815 = 3,
        /// <summary>The Intel Minnow Board Max</summary>
        IntelMinnowboardMax = 4,
        /// <summary>The different Raspberry PI Models -like  A,B,A+,B+</summary>
        RaspberryPi = 5,
        /// <summary>The different BeagleBone Black Modes B/C</summary>
        Beaglebone = 6,
        /// <summary>Allwinner A20 based Banana Pi and Banana Pro</summary>
        Banana = 7,
        /// <summary>The Intel 5th generations Broadwell NUCs</summary>
        IntelNuc5 = 8,
        /// <summary>Linaro 96boards</summary>
        Linaro96boards = 9,
        /// <summary>The Intel SoFIA 3GR</summary>
        IntelSofia3gr = 10,
        /// <summary>The Intel Braswell Cherryhills</summary>
        IntelCherryhills = 11,
        /// <summary>The UP Board</summary>
        Up = 12,

        // USB platform extenders start at 256

        /// <summary>FTDI FT4222 USB to i2c bridge</summary>
        FtdiFt4222 = 256,

        /// <summary>Platform with no capabilities that hosts a sub platform </summary>
        NullPlatform = 98,
        /// <summary>An unknown platform type, typically will load INTEL_GALILEO_GEN1</summary>
        UnknownPlatform = 99,
    }

    /// <summary>
    /// Intel edison miniboard numbering enum
    /// </summary>
    public static class MraaIntelEdisonMiniboard
    {
        public const int J17_1 = 0;
        public const int J17_5 = 4;
        public const int J17_7 = 6;
        public const int J17_8 = 7;
        public const int J17_9 = 8;
        public const int J17_10 = 9;
        public const int J17_11 = 10;
        public const int J17_12 = 11;
        public const int J17_14 = 13;
        public const int J18_1 = 14;
        public const int J18_2 = 15;
        public const int J18_6 = 19;
        public const int J18_7 = 20;
        public const int J18_8 = 21;
        public const int J18_10 = 23;
        public const int J18_11 = 24;
        public const int J18_12 = 25;
        public const int J18_13 = 26;
        public const int J19_4 = 31;
        public const int J19_5 = 32;
        public const int J19_6 = 33;
        public const int J19_8 = 35;
        public const int J19_9 = 36;
        public const int J19_10 = 37;
        public const int J19_11 = 38;
        public const int J19_12 = 39;
        public const int J19_13 = 40;
        public const int J19_14 = 41;
        public const int J20_3 = 44;
        public const int J20_4 = 45;
        public const int J20_5 = 46;
        public const int J20_6 = 47;
        public const int J20_7 = 48;
        public const int J20_8 = 49;
        public const int J20_9 = 50;
        public const int J20_10 = 51;
        public const int J20_11 = 52;
        public const int J20_12 = 53;
        public const int J20_13 = 54;
        public const int J20_14 = 55;
    }

    public static class MraaIntelEdison
    {
        public const int Gp182 = 0;
        public const int Gp135 = 4;
        public const int Gp27 = 6;
        public const int Gp20 = 7;
        public const int Gp28 = 8;
        public const int Gp111 = 0;
        public const int Gp109 = 10;
        public const int Gp115 = 11;
        public const int Gp128 = 13;
        public const int Gp13 = 14;
        public const int Gp165 = 15;
        public const int Gp19 = 19;
        public const int Gp12 = 20;
        public const int Gp183 = 21;
        public const int Gp110 = 23;
        public const int Gp114 = 24;
        public const int Gp129 = 25;
        public const int Gp130 = 26;
        public const int Gp44 = 31;
        public const int Gp46 = 32;
        public const int Gp48 = 33;
        public const int Gp131 = 35;
        public const int Gp14 = 36;
        public const int Gp40 = 37;
        public const int Gp43 = 38;
        public const int Gp77 = 39;
        public const int Gp82 = 40;
        public const int Gp83 = 41;
        public const int Gp134 = 44;
        public const int Gp45 = 45;
        public const int Gp47 = 46;
        public const int Gp49 = 47;
        public const int Gp15 = 48;
        public const int Gp84 = 49;
        public const int Gp42 = 50;
        public const int Gp41 = 51;
        public const int Gp78 = 52;
        public const int Gp79 = 53;
        public const int Gp80 = 54;
        public const int Gp81 = 55;
    }

    /// <summary>
    /// Raspberry PI Wiring compatible numbering enum
    /// </summary>
    public static class MraaRaspberryWiring
    {
        public const int Pin8 = 3;
        public const int Pin9 = 5;
        public const int Pin7 = 7;
        public const int Pin15 = 8;
        public const int Pin16 = 10;
        public const int Pin0 = 11;
        public const int Pin1 = 12;
        public const int Pin2 = 13;
        public const int Pin3 = 15;
        public const int Pin4 = 16;
        public const int Pin5 = 18;
        public const int Pin12 = 19;
        public const int Pin13 = 21;
        public const int Pin6 = 22;
        public const int Pin14 = 23;
        public const int Pin10 = 24;
        public const int Pin11 = 26;
        public const int Pin17 = 29; // RPi B V2
        public const int Pin21 = 29;
        public const int Pin18 = 30; // RPi B V2
        public const int Pin19 = 31; // RPI B V2
        public const int Pin22 = 31;
        public const int Pin20 = 32; // RPi B V2
        public const int Pin26 = 32;
        public const int Pin23 = 33;
        public const int Pin24 = 35;
        public const int Pin27 = 36;
        public const int Pin25 = 37;
        public const int Pin28 = 38;
        public const int Pin29 = 40;
    }

    /// <summary>
    /// MRAA return codes
    /// </summary>
    public enum MraaResult
    {
        /// <summary>Expected response</summary>
        Success = 0,
        /// <summary>Feature TODO</summary>
        ErrorFeatureNotImplemented = 1,
        /// <summary>Feature not supported by HW</summary>
        ErrorFeatureNotSupported = 2,
        /// <summary>Verbosity level wrong</summary>
        ErrorInvalidVerbosityLevel = 3,
        /// <summary>Parameter invalid</summary>
        ErrorInvalidParameter = 4,
        /// <summary>Handle invalid</summary>
        ErrorInvalidHandle = 5,
        /// <summary>No resource of that type avail</summary>
        ErrorNoResources = 6,
        /// <summary>Resource invalid</summary>
        ErrorInvalidResource = 7,
        /// <summary>Queue type incorrect</summary>
        ErrorInvalidQueueType = 8,
        /// <summary>No data available</summary>
        ErrorNoDataAvailable = 9,
        /// <summary>Platform not recognised</summary>
        ErrorInvalidPlatform = 10,
        /// <summary>Board information not initialised</summary>
        ErrorPlatformNotInitialised = 11,
        /// <summary>Board is already initialised</summary>
        ErrorPlatformAlreadyInitialised = 12,

        /// <summary>Unknown Error</summary>
        ErrorUnspecified = 99,
    }

    /// <summary>
    /// Enum representing different possible modes for a pin.
    /// </summary>
    public enum MraaPinModes
    {
        /// <summary>Pin Valid</summary>
        PinValid = 0,
        /// <summary>General Purpose IO</summary>
        PinGpio = 1,
        /// <summary>Pulse Width Modulation</summary>
        PinPwm = 2,
        /// <summary>Faster GPIO</summary>
        PinFastGpio = 3,
        /// <summary>SPI</summary>
        PinSpi = 4,
        /// <summary>I2C</summary>
        PinI2c = 5,
        /// <summary>Analog in</summary>
        PinAio = 6,
        /// <summary>UART</summary>
        PinUart = 7,
    }

    /// <summary>
    /// Enum reprensenting different i2c speeds/modes
    /// </summary>
    public enum MraaI2cMode
    {
        /// <summary>up to 100Khz</summary>
        I2cStd = 0,
        /// <summary>up to 400Khz</summary>
        I2cFast = 1,
        /// <summary>up to 3.4Mhz</summary>
        I2cHigh = 2,
    }

    public enum MraaUartParity
    {
        UartParityNone = 0,
        UartParityEven = 1,
        UartParityOdd = 2,
        UartParityMark = 3,
        UartParitySpace = 4
    }
}
