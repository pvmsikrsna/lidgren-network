﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Diagnostics;

namespace Lidgren.Network
{
	[DebuggerDisplay("{m_readPosition} of {m_bitLength} bits ({LengthBytes} bytes) read")]
	public partial class NetIncomingMessage
	{
		internal byte[] m_data;
		internal int m_bitLength;

		internal NetIncomingMessageType m_messageType;
		internal IPEndPoint m_senderEndPoint;
		internal NetConnection m_senderConnection;

		/// <summary>
		/// Gets the length of the data in bytes
		/// </summary>
		public int LengthBytes
		{
			get { return ((m_bitLength + 7) >> 3); }
		}

		/// <summary>
		/// Type of data contained in this message
		/// </summary>
		public NetIncomingMessageType MessageType { get { return m_messageType; } }

		/// <summary>
		/// IPEndPoint of sender, if any
		/// </summary>
		public IPEndPoint SenderEndPoint { get { return m_senderEndPoint; } }

		/// <summary>
		/// NetConnection of sender, if any
		/// </summary>
		public NetConnection SenderConnection { get { return m_senderConnection; } }

		internal NetIncomingMessage()
		{
		}

		internal NetIncomingMessage(byte[] data, int dataLength)
		{
			m_data = data;
			m_bitLength = dataLength * 8;
		}

		internal void Reset()
		{
			m_bitLength = 0;
			m_readPosition = 0;
		}

		public override string ToString()
		{
			return "[NetIncomingMessage " + m_messageType + ", " + m_bitLength + " bits]";
		}
	}
}