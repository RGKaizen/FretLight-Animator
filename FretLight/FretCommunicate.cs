using System;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using System.Windows.Forms;

namespace FretLight
{
    /// <summary>
    ///  This class is responsible for all the USB communcation between the software and the Guitar
    ///  It relies heavily on the LibUsbDotNet project found here
    ///  http://sourceforge.net/projects/libusbdotnet/
    ///  In fact, you need that project to compile this class.
    ///  Author: Rodrigo Groppa
    ///  Date Formalized: 07/14/2012
    /// </summary>
    public static class FretCommunicate
    {
        public static UsbDevice MyUsbDevice;
        public static UsbEndpointWriter Writer;
        public static Boolean _Ready = false;

        // The VID and PID for the FretLight Guitar are found here
        #region SET YOUR USB Vendor and Product ID!
        public static UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(2341, 8192);
        #endregion

        /// <summary>
        ///  Start method tries to claim the proper endpoint so we can send data to the FretLight Guitar
        ///  This code is largely duplicated from LibUsbDotNet's example
        /// </summary>
        public static void Start()
        {
            ErrorCode ec = ErrorCode.None;
            try
            {
                // Find and open the usb device.
                MyUsbDevice = UsbDevice.OpenUsbDevice(MyUsbFinder);

                // If the device is open and ready
                if (MyUsbDevice == null) throw new Exception("Device Not Found.");

                // If this is a "whole" usb device (libusb-win32, linux libusb-1.0)
                // it exposes an IUsbDevice interface. If not (WinUSB) the 
                // 'wholeUsbDevice' variable will be null indicating this is 
                // an interface of a device; it does not require or support 
                // configuration and interface selection.
                IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                if (!ReferenceEquals(wholeUsbDevice, null))
                {
                    // This is a "whole" USB device. Before it can be used, 
                    // the desired configuration and interface must be selected.

                    // Select config #1
                    wholeUsbDevice.SetConfiguration(1);

                    // Claim interface #0.
                    wholeUsbDevice.ClaimInterface(0);

                    //Open a writer to endpoint #2.
                    Writer = MyUsbDevice.OpenEndpointWriter(WriteEndpointID.Ep02);
                    _Ready = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show((ec != ErrorCode.None ? ec + ":" : String.Empty) + ex.Message);
            }
        }

        /// <summary>
        /// Sends data to the Guitar
        /// 100 milliseconds are used to complete the transfer, lower values can crash the code
        /// 7 Bytes is exactly what the guitar expects
        /// </summary>
        public static void SendData(Byte[] data)
        {
            // Device is not ready, return
            if (!_Ready) return;

            ErrorCode ec = ErrorCode.None;
            if (MyUsbDevice == null) throw new Exception("Device Not Found.");

            // open write endpoint 2.

            int transferLength = 7;
            ec = Writer.Write(data, 100, out transferLength);

            if (ec != ErrorCode.None) throw new Exception(UsbDevice.LastErrorString);
        }

        /// <summary>
        /// In order to access all 22*6 LEDs on the guitar, 3 7-Byte packets are used
        /// This method handles the production of all 3 packets, it relies on the LED class for
        /// part of the construction, and is thus heavily dependent on it.
        /// </summary>
        public static void SendPacket()
        {
            Byte[,] packetBox = LED.producePacket();
            Byte[] packet = new Byte[7];

            System.Buffer.BlockCopy(packetBox, 0, packet, 0, 7);
            FretCommunicate.SendData(packet);

            System.Buffer.BlockCopy(packetBox, 7, packet, 0, 7);
            FretCommunicate.SendData(packet);

            System.Buffer.BlockCopy(packetBox, 14, packet, 0, 7);
            FretCommunicate.SendData(packet);
        }

        /// <summary>
        /// Closes the connection and tidies up everything we started in the Start method
        /// </summary>
        public static void CloseConnection()
        {
            if (MyUsbDevice != null)
            {
                if (MyUsbDevice.IsOpen)
                {
                    // If this is a "whole" usb device (libusb-win32, linux libusb-1.0)
                    // it exposes an IUsbDevice interface. If not (WinUSB) the 
                    // 'wholeUsbDevice' variable will be null indicating this is 
                    // an interface of a device; it does not require or support 
                    // configuration and interface selection.
                    IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                    if (!ReferenceEquals(wholeUsbDevice, null))
                    {
                        // Release interface #0.
                        wholeUsbDevice.ReleaseInterface(0);
                    }
                    MyUsbDevice.Close();
                }
            }
            MyUsbDevice = null;

            // Free usb resources
            UsbDevice.Exit();
        }
    }
}
