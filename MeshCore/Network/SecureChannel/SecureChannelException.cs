﻿/*
Technitium Mesh
Copyright (C) 2018  Shreyas Zare (shreyas@technitium.com)

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/

using System;
using System.IO;
using System.Net;
using TechnitiumLibrary.IO;

namespace MeshCore.Network.SecureChannel
{
    public enum SecureChannelCode : byte
    {
        None = 0,
        RemoteError = 1,
        ProtocolVersionNotSupported = 2,
        NoMatchingCipherAvailable = 3,
        NoMatchingOptionsAvailable = 4,
        PskAuthenticationFailed = 5,
        PeerAuthenticationFailed = 6,
        UntrustedRemotePeerUserId = 7,
        MessageAuthenticationFailed = 8,
        RenegotiationFailed = 9,
        UnknownException = 254,
    }

    [Serializable()]
    public class SecureChannelException : IOException
    {
        #region variable

        SecureChannelCode _code;
        IPEndPoint _peerEP;
        BinaryNumber _peerUserId;

        #endregion

        #region constructor

        public SecureChannelException(SecureChannelCode code, IPEndPoint peerEP, BinaryNumber peerUserId)
        {
            _code = code;
            _peerEP = peerEP;
            _peerUserId = peerUserId;
        }

        public SecureChannelException(SecureChannelCode code, IPEndPoint peerEP, BinaryNumber peerUserId, string message)
            : base(message)
        {
            _code = code;
            _peerEP = peerEP;
            _peerUserId = peerUserId;
        }

        public SecureChannelException(SecureChannelCode code, IPEndPoint peerEP, BinaryNumber peerUserId, string message, Exception innerException)
            : base(message, innerException)
        {
            _code = code;
            _peerEP = peerEP;
            _peerUserId = peerUserId;
        }

        public SecureChannelException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }

        #endregion

        #region property

        public SecureChannelCode Code
        { get { return _code; } }

        public IPEndPoint PeerEP
        { get { return _peerEP; } }

        public BinaryNumber PeerUserId
        { get { return _peerUserId; } }

        #endregion
    }
}