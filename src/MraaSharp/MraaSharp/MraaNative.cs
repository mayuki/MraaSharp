using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MraaSharp
{
    internal static class MraaNative
    {
        #region common.h
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_init();
        [DllImport("libmraa.so")]
        public extern static void mraa_deinit();

        [DllImport("libmraa.so")]
        public extern static int mraa_pin_mode_test(int pin, MraaPinModes mode);
        [DllImport("libmraa.so")]
        public extern static uint mraa_adc_raw_bits();
        [DllImport("libmraa.so")]
        public extern static uint mraa_get_platform_adc_raw_bits(MraaPlatformOffsetU8 platformOffset);
        [DllImport("libmraa.so")]
        public extern static uint mraa_adc_supported_bits();
        [DllImport("libmraa.so")]
        public extern static uint mraa_get_platform_adc_supported_bits(MraaPlatformOffset platformOffset);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_set_log_level(int level);
        [DllImport("libmraa.so")]
        public extern static IntPtr mraa_get_platform_name();
        [DllImport("libmraa.so")]
        public extern static IntPtr mraa_get_platform_version(MraaPlatformOffset platformOffset);
        [DllImport("libmraa.so")]
        public extern static int mraa_set_priority(int priority);
        [DllImport("libmraa.so")]
        public extern static IntPtr mraa_get_version();
        [DllImport("libmraa.so")]
        public extern static void mraa_result_print(MraaResult result);
        [DllImport("libmraa.so")]
        public extern static MraaPlatform mraa_get_platform_type();
        [DllImport("libmraa.so")]
        public extern static int mraa_get_platform_combined_type();
        [DllImport("libmraa.so")]
        public extern static uint mraa_get_pin_count();
        [DllImport("libmraa.so")]
        public extern static int mraa_get_i2c_bus_count();
        [DllImport("libmraa.so")]
        public extern static int mraa_get_i2c_bus_id(uint i2cBus);
        [DllImport("libmraa.so")]
        public extern static uint mraa_get_platform_pin_count(MraaPlatformOffsetU8 platformOffset);
        [DllImport("libmraa.so")]
        public extern static IntPtr mraa_get_pin_name(int pin);
        [DllImport("libmraa.so")]
        public extern static int mraa_get_default_i2c_bus(MraaPlatformOffsetU8 platformOffset);
        [DllImport("libmraa.so")]
        public extern static int mraa_has_sub_platform();
        [DllImport("libmraa.so")]
        public extern static int mraa_is_sub_platform_id(int pinOrBusId);
        [DllImport("libmraa.so")]
        public extern static int mraa_get_sub_platform_id(int pinOrBusIndex);
        [DllImport("libmraa.so")]
        public extern static int mraa_get_sub_platform_index(int pinOrBusId);
        #endregion

        #region gpio.h
        [DllImport("libmraa.so")]
        public extern static MraaGpioContext mraa_gpio_init(int pin);
        [DllImport("libmraa.so")]
        public extern static MraaGpioContext mraa_gpio_init_raw(int gpiopin);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_gpio_edge_mode(MraaGpioContext dev, MraaGpioEdge mode);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_gpio_isr(MraaGpioContext dev, MraaGpioEdge mode, IntPtr fptr, IntPtr args);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_gpio_isr_exit(MraaGpioContext dev);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_gpio_mode(MraaGpioContext dev, MraaGpioMode mode);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_gpio_dir(MraaGpioContext dev, MraaGpioDir dir);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_gpio_read_dir(MraaGpioContext dev, out MraaGpioDir dir);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_gpio_close(IntPtr dev);
        [DllImport("libmraa.so")]
        public extern static MraaGpioValue mraa_gpio_read(MraaGpioContext dev);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_gpio_write(MraaGpioContext dev, MraaGpioValue value);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_gpio_owner(MraaGpioContext dev, int owner);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_gpio_use_mmaped(MraaGpioContext dev, int mmap);
        [DllImport("libmraa.so")]
        public extern static int mraa_gpio_get_pin(MraaGpioContext dev);
        [DllImport("libmraa.so")]
        public extern static int mraa_gpio_get_pin_raw(MraaGpioContext dev);
        #endregion

        #region pwm.h
        [DllImport("libmraa.so")]
        public extern static MraaPwmContext mraa_pwm_init(int pin);
        [DllImport("libmraa.so")]
        public extern static MraaPwmContext mraa_pwm_init_raw(int chipid, int pin);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_pwm_write(MraaPwmContext dev, float percentage);
        [DllImport("libmraa.so")]
        public extern static float mraa_pwm_read(MraaPwmContext dev);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_pwm_period(MraaPwmContext dev, float seconds);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_pwm_period_ms(MraaPwmContext dev, int ms);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_pwm_period_us(MraaPwmContext dev, int us);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_pwm_pulsewidth(MraaPwmContext dev, float seconds);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_pwm_pulsewidth_ms(MraaPwmContext dev, int ms);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_pwm_pulsewidth_us(MraaPwmContext dev, int us);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_pwm_enable(MraaPwmContext dev, int enable);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_pwm_owner(MraaPwmContext dev, int owner);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_pwm_close(IntPtr dev);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_pwm_config_ms(MraaPwmContext dev, int period, float duty);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_pwm_config_percent(MraaPwmContext dev, int period, float duty);
        [DllImport("libmraa.so")]
        public extern static int mraa_pwm_get_max_period();
        [DllImport("libmraa.so")]
        public extern static int mraa_pwm_get_min_period();
        #endregion

        #region uart.h
        [DllImport("libmraa.so")]
        public extern static MraaUartContext mraa_uart_init(int uart);
        [DllImport("libmraa.so")]
        public extern static MraaUartContext mraa_uart_init_raw(string path);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_uart_flush(MraaUartContext dev);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_uart_set_baudrate(MraaUartContext dev, uint baud);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_uart_set_mode(MraaUartContext dev, int bytesize, MraaUartParity parity, int stopbits);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_uart_set_flowcontrol(MraaUartContext dev, int xonxoff, int rtscts);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_uart_set_timeout(MraaUartContext dev, int read, int write, int interchar);
        [DllImport("libmraa.so")]
        public extern static IntPtr mraa_uart_get_dev_path(MraaUartContext dev);
        [DllImport("libmraa.so")]
        public extern static MraaResult mraa_uart_stop(IntPtr dev);
        [DllImport("libmraa.so")]
        public extern static int mraa_uart_read(MraaUartContext dev, byte[] buf, int length);
        [DllImport("libmraa.so")]
        public extern static int mraa_uart_write(MraaUartContext dev, byte[] buf, int length);
        [DllImport("libmraa.so")]
        public extern static int mraa_uart_data_available(MraaUartContext dev, uint millis);

        #endregion

        public static void ThrowIfError(MraaResult result)
        {
            if (result != MraaResult.Success)
            {
                throw new MraaException(result);
            }
        }
    }
}
