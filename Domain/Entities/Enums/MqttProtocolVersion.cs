namespace MqttBrokerForNet.Domain.Entities.Enums
{
    using MqttBrokerForNet.Domain.Messages;

    /// <summary>
    /// MQTT protocol version
    /// </summary>
    public enum MqttProtocolVersion
    {
        Version_3_1 = MqttMsgConnect.PROTOCOL_VERSION_V3_1,
        Version_3_1_1 = MqttMsgConnect.PROTOCOL_VERSION_V3_1_1
    }
}