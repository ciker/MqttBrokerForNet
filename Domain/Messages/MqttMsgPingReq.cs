/*
Copyright (c) 2013, 2014 Paolo Patierno

All rights reserved. This program and the accompanying materials
are made available under the terms of the Eclipse Public License v1.0
and Eclipse Distribution License v1.0 which accompany this distribution. 

The Eclipse Public License is available at 
   http://www.eclipse.org/legal/epl-v10.html
and the Eclipse Distribution License is available at 
   http://www.eclipse.org/org/documents/edl-v10.php.

Contributors:
   Paolo Patierno - initial API and implementation and/or initial documentation
   David Kristensen - optimalization for the azure platform
*/

namespace MqttBrokerForNet.Domain.Messages
{
    using MqttBrokerForNet.Domain.Exceptions;

    /// <summary>
    /// Class for PINGREQ message from client to broker
    /// </summary>
    public class MqttMsgPingReq : MqttMsgBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MqttMsgPingReq()
        {
            this.type = MQTT_MSG_PINGREQ_TYPE;
        }

        public override byte[] GetBytes(byte protocolVersion)
        {
            byte[] buffer = new byte[2];
            int index = 0;

            // first fixed header byte
            if (protocolVersion == MqttMsgConnect.PROTOCOL_VERSION_V3_1_1)
                buffer[index++] = (MQTT_MSG_PINGREQ_TYPE << MSG_TYPE_OFFSET) | MQTT_MSG_PINGREQ_FLAG_BITS; // [v.3.1.1]
            else
                buffer[index++] = (MQTT_MSG_PINGREQ_TYPE << MSG_TYPE_OFFSET);
            buffer[index++] = 0x00;

            return buffer;
        }

        public static MqttMsgPingReq Parse(byte fixedHeaderFirstByte, byte protocolVersion)
        {
            MqttMsgPingReq msg = new MqttMsgPingReq();

            if (protocolVersion == MqttMsgConnect.PROTOCOL_VERSION_V3_1_1)
            {
                // [v3.1.1] check flag bits
                if ((fixedHeaderFirstByte & MSG_FLAG_BITS_MASK) != MQTT_MSG_PINGREQ_FLAG_BITS)
                {
                    throw new MqttClientException(MqttClientErrorCode.InvalidFlagBits);
                }
            }

            return msg;
        }
    }
}
