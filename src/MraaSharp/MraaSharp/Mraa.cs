using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MraaSharp
{
    /// <summary>
    /// API to common functions of MRAA.
    /// </summary>
    public static class Mraa
    {
        /// <summary>
        /// Initialise MRAA
        /// Detects running platform and attempts to use included pinmap, this is run on module/library init/load but is handy to rerun to check board initialised correctly.MRAA_SUCCESS inidicates correct (first time) initialisation whilst MRAA_ERROR_PLATFORM_ALREADY_INITIALISED indicates the board is already initialised correctly
        /// </summary>
        public static void Initialize()
        {
            var result = MraaNative.mraa_init();
            if (result != MraaResult.Success && result != MraaResult.ErrorPlatformAlreadyInitialised)
            {
                throw new MraaException(result);
            }
        }

        /// <summary>
        /// De-Initilise MRAA
        /// This is not a strict requirement but useful to test memory leaks and for people who like super clean code.If dynamically loading & unloading libmraa you need to call this before unloading the library. 
        /// </summary>
        public static void Deinitialize()
        {
            MraaNative.mraa_deinit();
        }

        /// <summary>
        /// Checks if a pin is able to use the passed in mode.
        /// </summary>
        /// <param name="pin">Physical Pin to be checked. </param>
        /// <param name="mode">the mode to be tested. </param>
        /// <returns>boolean if the mode is supported, 0=false.</returns>
        public static bool PinModeTest(int pin, MraaPinModes mode)
        {
            return MraaNative.mraa_pin_mode_test(pin, mode) == 1;
        }

        /// <summary>
        /// Check the board's bit size when reading the value.
        /// raw bits being read from kernel module. zero if no ADC
        /// </summary>
        public static uint AdcRawBits
        {
            get { return MraaNative.mraa_adc_raw_bits(); }
        }

        /// <summary>
        /// Check the specified board's bit size when reading the value
        /// </summary>
        /// <param name="platformOffset">specified platform offset; 0 for main platform, 1 foor sub platform  </param>
        /// <returns>raw bits being read from kernel module. zero if no ADC </returns>
        public static uint GetPlatformAdcRawBits(MraaPlatformOffset platformOffset)
        {
            return MraaNative.mraa_get_platform_adc_raw_bits((MraaPlatformOffsetU8)platformOffset);
        }

        /// <summary>
        /// Return value that the raw value should be shifted to. Zero if no ADC.
        /// return actual bit size the adc value should be understood as.
        /// </summary>
        public static uint AdcSupportedBits
        {
            get { return MraaNative.mraa_adc_supported_bits(); }
        }

        /// <summary>
        /// Return value that the raw value should be shifted to. Zero if no ADC
        /// </summary>
        /// <param name="platformOffset">specified platform offset; 0 for main platform, 1 foor sub platform  </param>
        /// <returns>return actual bit size the adc value should be understood as.</returns>
        public static uint GetPlatformAdcSupportedBits(MraaPlatformOffset platformOffset)
        {
            return MraaNative.mraa_get_platform_adc_supported_bits(platformOffset);
        }

        /// <summary>
        /// Sets the log level to use from 0-7 where 7 is very verbose. These are the syslog log levels, see syslog(3) for more information on the levels.
        /// </summary>
        public static int LogLevel
        {
            set
            {
                MraaNative.ThrowIfError(MraaNative.mraa_set_log_level(value));
            }
        }

        /// <summary>
        /// Return the Platform's Name, If no platform detected return NULL
        /// </summary>
        public static string PlatformName
        {
            get { return Marshal.PtrToStringAnsi(MraaNative.mraa_get_platform_name()); }
        }

        /// <summary>
        /// Return the platform's versioning info, the information given depends per platform and can be NULL. platform_offset has to be given. Do not modify this pointer
        /// </summary>
        /// <param name="platformOffset">specified platform offset; 0 for main platform, 1 for sub platform</param>
        /// <returns>platform's versioning string</returns>
        public static string GetPlatformVersion(MraaPlatformOffset platformOffset)
        {
            return Marshal.PtrToStringAnsi(MraaNative.mraa_get_platform_version(platformOffset));
        }

        /// <summary>
        /// This function attempts to set the mraa process to a given priority and the scheduler to SCHED_RR.
        /// Highest * priority is typically 99 and minimum is 0. This function * will set to MAX if * priority is > MAX. Function will return -1 on failure.
        /// </summary>
        public static int Priority
        {
            set
            {
                MraaNative.mraa_set_priority(value);
            }
        }

        /// <summary>
        /// Get the version string of mraa autogenerated from git tag
        /// The version returned may not be what is expected however it is a reliable number associated with the git tag closest to that version at build time
        /// </summary>
        public static string Version
        {
            get { return Marshal.PtrToStringAnsi(MraaNative.mraa_get_version()); }
        }

        /// <summary>
        /// Print a textual representation of the mraa_result_t
        /// </summary>
        /// <param name="result">the result to print</param>
        public static void ResultPrint(MraaResult result)
        {
            MraaNative.mraa_result_print(result);
        }

        /// <summary>
        /// Get platform type, board must be initialised.
        /// </summary>
        public static MraaPlatform PlatformType
        {
            get { return MraaNative.mraa_get_platform_type(); }
        }

        /// <summary>
        /// Get combined platform type, board must be initialised. The combined type is represented as (sub_platform_type &lt;&lt; 8) | main_platform_type
        /// </summary>
        public static int PlatformCombinedType
        {
            get { return MraaNative.mraa_get_platform_combined_type(); }
        }

        /// <summary>
        /// Get platform pincount, board must be initialised.
        /// uint of physical pin count on the in-use platform.
        /// </summary>
        public static uint PinCount
        {
            get { return MraaNative.mraa_get_pin_count(); }
        }

        /// <summary>
        /// Get platform usable I2C bus count, board must be initialised.
        /// number if usable I2C bus count on the current platform. Function will return -1 on failure.
        /// </summary>
        public static int I2cBusCount
        {
            get { return MraaNative.mraa_get_i2c_bus_count(); }
        }

        /// <summary>
        /// Get I2C adapter number in sysfs.
        /// </summary>
        /// <param name="i2cBus">the logical I2C bus number </param>
        /// <returns>I2C adapter number in sysfs. Function will return -1 on failure.</returns>
        public static int GetI2cBusId(uint i2cBus)
        {
            return MraaNative.mraa_get_i2c_bus_id(i2cBus);
        }

        /// <summary>
        /// Get specified platform pincount, board must be initialised.
        /// </summary>
        /// <param name="platformOffset">platform offset; 0 for main platform, 1 foor sub platform</param>
        /// <returns>uint of physical pin count on the in-use platform </returns>
        public static uint GetPlatformPinCount(MraaPlatformOffset platformOffset)
        {
            return MraaNative.mraa_get_platform_pin_count((MraaPlatformOffsetU8)platformOffset);
        }

        /// <summary>
        /// Get name of pin, board must be initialised.
        /// </summary>
        /// <param name="pin">number</param>
        /// <returns>char* of pin name</returns>
        public static string GetPinName(int pin)
        {
            return Marshal.PtrToStringAnsi(MraaNative.mraa_get_pin_name(pin));
        }

        /// <summary>
        /// Get default i2c bus, board must be initialised.
        /// </summary>
        /// <param name="platformOffset">platform offset; 0 for main platform, 1 foor sub platform</param>
        /// <returns>default i2c bus index</returns>
        public static int GetDefaultI2cBus(MraaPlatformOffset platformOffset)
        {
            return MraaNative.mraa_get_default_i2c_bus((MraaPlatformOffsetU8)platformOffset);
        }

        /// <summary>
        /// Detect presence of sub platform.
        /// </summary>
        public static bool HasSubPlatform
        {
            get { return MraaNative.mraa_has_sub_platform() == 1; }
        }

        /// <summary>
        /// Check if pin or bus id includes sub platform mask.
        /// </summary>
        /// <param name="pinOrBusId">pin or bus number</param>
        /// <returns>mraa_boolean_t 1 if pin or bus is for sub platform, 0 otherwise </returns>
        public static bool IsSubPlatformId(int pinOrBusId)
        {
            return MraaNative.mraa_is_sub_platform_id(pinOrBusId) == 1;
        }

        /// <summary>
        /// Convert pin or bus index to corresponding sub platform id.
        /// </summary>
        /// <param name="pinOrBusIndex">pin or bus index</param>
        /// <returns>sub platform pin or bus number</returns>
        public static int GetSubPlatformId(int pinOrBusIndex)
        {
            return MraaNative.mraa_get_sub_platform_id(pinOrBusIndex);
        }

        /// <summary>
        /// Convert pin or bus sub platform id to index.
        /// </summary>
        /// <param name="pinOrBusIndex">sub platform pin or bus id</param>
        /// <returns>pin or bus index</returns>
        public static int GetSubPlatformIndex(int pinOrBusId)
        {
            return MraaNative.mraa_get_sub_platform_index(pinOrBusId);
        }
    }
}
