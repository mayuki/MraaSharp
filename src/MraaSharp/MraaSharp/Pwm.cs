using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MraaSharp
{
    internal class MraaPwmContext : SafeHandle
    {
        public MraaPwmContext()
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
            return MraaNative.mraa_pwm_close(this.handle) == MraaResult.Success;
        }
    }

    /// <summary>
    /// PWM is the Pulse Width Modulation interface to libmraa.
    /// It allows the generation of a signal on a pin.
    /// Some boards may have higher or lower levels of resolution so make sure you check the board &amp; pin you are using before hand.
    /// </summary>
    public class Pwm : IDisposable
    {
        private MraaPwmContext _pwmContext;

        /// <summary>
        /// Initialise pwm_context, uses board mapping
        /// </summary>
        /// <param name="pin">The PWM PIN</param>
        public Pwm(int pin)
        {
            this._pwmContext = MraaNative.mraa_pwm_init(pin);
        }

        /// <summary>
        /// Initialise pwm_context, raw mode
        /// </summary>
        /// <param name="chipid">The chip inwhich the PWM is under in SYSFS </param>
        /// <param name="pin">The PWM PIN</param>
        public Pwm(int chipid, int pin)
        {
            this._pwmContext = MraaNative.mraa_pwm_init_raw(chipid, pin);
        }

        /// <summary>
        /// Set the ouput duty-cycle percentage, as a float
        /// </summary>
        /// <param name="percentage">A floating-point value representing percentage of output. The value should lie between 0.0f (representing on 0%) and 1.0f Values above or below this range will be set at either 0.0f or 1.0f</param>
        public void Write(float percentage)
        {
            if (this._pwmContext == null) throw new ObjectDisposedException("Pwm");
            MraaNative.ThrowIfError(MraaNative.mraa_pwm_write(this._pwmContext, percentage));
        }

        /// <summary>
        /// Set the PWM period as seconds represented in a float
        /// </summary>
        /// <param name="seconds">Period represented as a float in seconds </param>
        public void SetPeriod(float seconds)
        {
            if (this._pwmContext == null) throw new ObjectDisposedException("Pwm");
            MraaNative.ThrowIfError(MraaNative.mraa_pwm_period(this._pwmContext, seconds));
        }

        /// <summary>
        /// Set period, milliseconds.
        /// </summary>
        /// <param name="ms">Milliseconds for period</param>
        public void SetPeriodMilliseconds(int ms)
        {
            if (this._pwmContext == null) throw new ObjectDisposedException("Pwm");
            MraaNative.ThrowIfError(MraaNative.mraa_pwm_period_ms(this._pwmContext, ms));
        }

        /// <summary>
        /// Set period, microseconds.
        /// </summary>
        /// <param name="us">Microseconds as period </param>
        public void SetPeriodMicroseconds(int us)
        {
            if (this._pwmContext == null) throw new ObjectDisposedException("Pwm");
            MraaNative.ThrowIfError(MraaNative.mraa_pwm_period_us(this._pwmContext, us));
        }

        /// <summary>
        /// Set pulsewidth, As represnted by seconds in a (float)
        /// </summary>
        /// <param name="seconds">The duration of a pulse </param>
        public void SetPulseWidthMicroseconds(float seconds)
        {
            if (this._pwmContext == null) throw new ObjectDisposedException("Pwm");
            MraaNative.ThrowIfError(MraaNative.mraa_pwm_pulsewidth(this._pwmContext, seconds));
        }

        /// <summary>
        /// Set pulsewidth, milliseconds
        /// </summary>
        /// <param name="ms">Milliseconds for pulsewidth</param>
        public void SetPulseWidthMilliseconds(int ms)
        {
            if (this._pwmContext == null) throw new ObjectDisposedException("Pwm");
            MraaNative.ThrowIfError(MraaNative.mraa_pwm_pulsewidth_ms(this._pwmContext, ms));
        }

        /// <summary>
        /// Set pulsewidth, microseconds
        /// </summary>
        /// <param name="us">Microseconds for pulsewidth</param>
        public void SetPulseWidthMicroseconds(int us)
        {
            if (this._pwmContext == null) throw new ObjectDisposedException("Pwm");
            MraaNative.ThrowIfError(MraaNative.mraa_pwm_pulsewidth_us(this._pwmContext, us));
        }

        /// <summary>
        /// Set the enable status of the PWM pin. None zero will assume on with output being driven. and 0 will disable the output
        /// </summary>
        public bool Enable
        {
            set
            {
                if (this._pwmContext == null) throw new ObjectDisposedException("Pwm");
                MraaNative.ThrowIfError(MraaNative.mraa_pwm_enable(this._pwmContext, value ? 1 : 0));
            }
        }

        /// <summary>
        /// Change ownership of context
        /// </summary>
        public bool Owner
        {
            set
            {
                if (this._pwmContext == null) throw new ObjectDisposedException("Pwm");
                MraaNative.ThrowIfError(MraaNative.mraa_pwm_owner(this._pwmContext, value ? 1 : 0));
            }
        }

        /// <summary>
        /// Set Both Period and DutyCycle on a PWM context
        /// </summary>
        /// <param name="period">represented in ms. </param>
        /// <param name="duty">dutycycle of the pwm signal. </param>
        public void ConfigMilliseconds(int period, float duty)
        {
            if (this._pwmContext == null) throw new ObjectDisposedException("Pwm");
            MraaNative.ThrowIfError(MraaNative.mraa_pwm_config_ms(this._pwmContext, period, duty));
        }

        /// <summary>
        /// Set Both Period and DutyCycle on a PWM context. Duty represented as percentage.
        /// </summary>
        /// <param name="period">represented in ms.</param>
        /// <param name="duty">duty percantage. i.e. 50% = 0.5f </param>
        public void ConfigPercent(int period, float duty)
        {
            if (this._pwmContext == null) throw new ObjectDisposedException("Pwm");
            MraaNative.ThrowIfError(MraaNative.mraa_pwm_config_percent(this._pwmContext, period, duty));
        }

        /// <summary>
        /// Get the maximum pwm period in us
        /// </summary>
        public int MaxPeriod
        {
            get
            {
                if (this._pwmContext == null) throw new ObjectDisposedException("Pwm");
                return MraaNative.mraa_pwm_get_max_period();
            }
        }

        /// <summary>
        /// Get the minimum pwm period in us
        /// </summary>
        public int MinPeriod
        {
            get
            {
                if (this._pwmContext == null) throw new ObjectDisposedException("Pwm");
                return MraaNative.mraa_pwm_get_min_period();
            }
        }

        public void Dispose()
        {
            if (this._pwmContext != null)
            {
                this._pwmContext.Dispose();
                this._pwmContext = null;
            }
        }
    }
}
