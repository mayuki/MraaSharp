using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MraaSharp
{
    internal class MraaUartContext : SafeHandle
    {
        public MraaUartContext()
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
            return MraaNative.mraa_uart_stop(this.handle) == MraaResult.Success;
        }
    }

    public class Uart : IDisposable
    {
        private MraaUartContext _uartContext;

        public Uart(int uart)
        {
            this._uartContext = MraaNative.mraa_uart_init(uart);
        }

        public Uart(string path)
        {
            this._uartContext = MraaNative.mraa_uart_init_raw(path);
        }

        public void Flush()
        {
            if (this._uartContext == null) throw new ObjectDisposedException("Uart");
            MraaNative.ThrowIfError(MraaNative.mraa_uart_flush(this._uartContext));
        }

        public void SetBaudrate(uint baud)
        {
            if (this._uartContext == null) throw new ObjectDisposedException("Uart");
            MraaNative.ThrowIfError(MraaNative.mraa_uart_set_baudrate(this._uartContext, baud));
        }

        public void SetMode(int bytesize, MraaUartParity parity, int stopbits)
        {
            if (this._uartContext == null) throw new ObjectDisposedException("Uart");
            MraaNative.ThrowIfError(MraaNative.mraa_uart_set_mode(this._uartContext, bytesize, parity, stopbits));
        }

        public void SetFlowControl(bool xonxoff, bool rtscts)
        {
            if (this._uartContext == null) throw new ObjectDisposedException("Uart");
            MraaNative.ThrowIfError(MraaNative.mraa_uart_set_flowcontrol(this._uartContext, xonxoff ? 1 : 0, rtscts ? 1 : 0));
        }

        public string DevPath
        {
            get
            {
                if (this._uartContext == null) throw new ObjectDisposedException("Uart");
                return Marshal.PtrToStringAnsi(MraaNative.mraa_uart_get_dev_path(this._uartContext));
            }
        }

        public void Stop()
        {
            if (this._uartContext == null) throw new ObjectDisposedException("Uart");
            this.Dispose();
        }

        public int Read(byte[] buffer)
        {
            if (this._uartContext == null) throw new ObjectDisposedException("Uart");
            return MraaNative.mraa_uart_read(this._uartContext, buffer, buffer.Length);
        }

        public int Write(byte[] buffer)
        {
            if (this._uartContext == null) throw new ObjectDisposedException("Uart");
            return MraaNative.mraa_uart_write(this._uartContext, buffer, buffer.Length);
        }

        public bool IsDataAvailable(uint millis)
        {
            if (this._uartContext == null) throw new ObjectDisposedException("Uart");
            return MraaNative.mraa_uart_data_available(this._uartContext, millis) == 1;
        }

        public void Dispose()
        {
            if (this._uartContext != null)
            {
                this._uartContext.Dispose();
                this._uartContext = null;
            }
        }
    }
}
