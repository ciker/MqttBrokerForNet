namespace MqttBrokerForNet.Business.Utility
{
    using System.Net;
    using System.Net.Sockets;

    /// <summary>
    /// IPAddress Utility class
    /// </summary>
    public static class IPAddressUtility
    {
        #region Public Methods and Operators

        /// <summary>
        /// Return AddressFamily for the IP address
        /// </summary>
        /// <param name="ipAddress">IP address to check</param>
        /// <returns>Address family</returns>
        public static AddressFamily GetAddressFamily(this IPAddress ipAddress)
        {
            return ipAddress.AddressFamily;
        }

        #endregion
    }
}