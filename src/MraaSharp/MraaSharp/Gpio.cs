using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MraaSharp
{
    internal class MraaGpioContext : SafeHandle
    {
        public MraaGpioContext()
            : base(IntPtr.Zero, true)
        {

        }
        public override bool IsInvalid
        {
            get
            {
                return this.handle == IntPtr.Zero;
            }
        }

        protected override bool ReleaseHandle()
        {
            return MraaNative.mraa_gpio_close(this.handle) == MraaResult.Success;
        }
    }

    /// <summary>
    /// Gpio is the General Purpose IO interface to libmraa.
    /// Its features depend on the board type used, it can use gpiolibs (exported via a kernel module through sysfs),
    /// or memory mapped IO via a /dev/uio device or /dev/mem depending again on the board configuration.
    /// </summary>
    public class Gpio : IDisposable
    {
        private MraaGpioContext _gpioContext;

        /// <summary>
        /// the edge mode on the gpio
        /// </summary>
        public MraaGpioEdge EdgeMode
        {
            set
            {
                if (this._gpioContext == null) throw new ObjectDisposedException("Gpio");
                MraaNative.ThrowIfError(MraaNative.mraa_gpio_edge_mode(this._gpioContext, value));
            }
        }

        /// <summary>
        /// Gpio Output Mode
        /// </summary>
        public MraaGpioMode Mode
        {
            set
            {
                if (this._gpioContext == null) throw new ObjectDisposedException("Gpio");
                MraaNative.ThrowIfError(MraaNative.mraa_gpio_mode(this._gpioContext, value));
            }
        }

        /// <summary>
        /// Gpio direction
        /// </summary>
        public MraaGpioDir Direction
        {
            set
            {
                if (this._gpioContext == null) throw new ObjectDisposedException("Gpio");
                MraaNative.ThrowIfError(MraaNative.mraa_gpio_dir(this._gpioContext, value));
            }
            get
            {
                MraaGpioDir dir;
                if (this._gpioContext == null) throw new ObjectDisposedException("Gpio");
                MraaNative.ThrowIfError(MraaNative.mraa_gpio_read_dir(this._gpioContext, out dir));
                return dir;
            }
        }

        /// <summary>
        /// Change ownership of the context.
        /// </summary>
        public bool Owner
        {
            set
            {
                if (this._gpioContext == null) throw new ObjectDisposedException("Gpio");
                MraaNative.ThrowIfError(MraaNative.mraa_gpio_owner(this._gpioContext, value ? 1 : 0));
            }
        }

        /// <summary>
        /// Enable using memory mapped io instead of sysfs
        /// </summary>
        public bool UseMmaped
        {
            set
            {
                if (this._gpioContext == null) throw new ObjectDisposedException("Gpio");
                MraaNative.ThrowIfError(MraaNative.mraa_gpio_use_mmaped(this._gpioContext, value ? 1 : 0));
            }
        }

        /// <summary>
        /// Get a pin number of the gpio, invalid will return -1
        /// </summary>
        public int Pin
        {
            get { return MraaNative.mraa_gpio_get_pin(this._gpioContext); }
        }

        /// <summary>
        /// Get a gpio number as used within sysfs, invalid will return -1
        /// </summary>
        public int PinRaw
        {
            get { return MraaNative.mraa_gpio_get_pin_raw(this._gpioContext); }
        }

        /// <summary>
        /// Initialise gpio context.
        /// </summary>
        /// <param name="pin">Pin number read from the board, i.e IO3 is 3. if raw parameter is true, gpio pin as listed in SYSFS.</param>
        /// <param name="raw">without any mapping to a pin if true.</param>
        public Gpio(int pin, bool raw = false)
        {
            this._gpioContext = raw ? MraaNative.mraa_gpio_init_raw(pin) : MraaNative.mraa_gpio_init(pin);
        }

        public Gpio(int pin, MraaGpioDir dir, bool raw = false)
            : this(pin, raw)
        {
            this.Direction = dir;
        }

        public Gpio(int pin, MraaGpioDir dir, MraaGpioMode mode, bool raw = false)
            : this(pin, raw)
        {
            this.Mode = mode;
            this.Direction = dir;
        }

        /// <summary>
        /// Write to the Gpio Value.
        /// </summary>
        /// <param name="value">value to write </param>
        public void Write(MraaGpioValue value)
        {
            if (this._gpioContext == null) throw new ObjectDisposedException("Gpio");
            MraaNative.ThrowIfError(MraaNative.mraa_gpio_write(this._gpioContext, value));
        }

        /// <summary>
        /// Read the Gpio value. This can be 0 or 1. A resonse of -1 means that there was a fatal error.
        /// </summary>
        /// <returns>Result of operation </returns>
        public MraaGpioValue Read()
        {
            if (this._gpioContext == null) throw new ObjectDisposedException("Gpio");
            return MraaNative.mraa_gpio_read(this._gpioContext);
        }

        public void Dispose()
        {
            if (this._gpioContext != null)
            {
                this._gpioContext.Dispose();
                this._gpioContext = null;
            }
        }
    }
}
