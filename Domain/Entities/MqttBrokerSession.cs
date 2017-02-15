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

namespace MqttBrokerForNet.Domain.Entities
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    using MqttBrokerForNet.Domain.Messages;

    /// <summary>
    /// MQTT Broker Session
    /// </summary>
    public class MqttBrokerSession : MqttSession
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MqttBrokerSession()
            : base()
        {
            this.Connection = null;
            this.Subscriptions = new List<MqttSubscription>();
            this.OutgoingMessages = new ConcurrentQueue<MqttMsgPublish>();
        }

        /// <summary>
        /// Client related to the subscription
        /// </summary>
        public MqttConnection Connection { get; set; }

        /// <summary>
        /// Subscriptions for the client session
        /// </summary>
        public List<MqttSubscription> Subscriptions { get; set; }

        /// <summary>
        /// Outgoing messages to publish
        /// </summary>
        public ConcurrentQueue<MqttMsgPublish> OutgoingMessages { get; set; }

        public override void Clear()
        {
            base.Clear();
            this.Connection = null;
            this.Subscriptions.Clear();
            this.OutgoingMessages = new ConcurrentQueue<MqttMsgPublish>();
        }
    }
}