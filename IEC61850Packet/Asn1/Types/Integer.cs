﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiscUtil.Conversion;
using IEC61850Packet.Utils;

namespace IEC61850Packet.Asn1.Types
{
    public class Integer:BasicType
    {
        public  int Value { get; set; }
        public Integer()
        {
            this.Identifier = BerIdentifier.Encode(BerIdentifier.Universal, BerIdentifier.Primitive, BerIdentifier.Integer);
        }

        public Integer(TLV tlv):this()
        {
            this.Bytes = tlv.Bytes;
            int len = tlv.Length.Value;

			Value = BigEndianBitConverter.Big.ToInt32(tlv.Value.RawBytes, 0,true);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
       
    }
}
