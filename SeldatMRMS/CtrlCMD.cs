using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeldatMRMS
{
    class CtrlCMD
    {
		public const byte CMD_ADDRESS_ASSIGNMENT = 0x08;
		public const byte CMD_TIMESYNS = 0x81;
		public const byte CMD_RESET_STATUS = 0x08;
		public const byte CMD_RESET_SETTING = 0x08;
		public const byte CMD_ADDRESS_ASSIGMENT_UNIT_WIDE = 0x90;
		public const byte CMD_RESET_SPEC_UNIT =0x91;
		public const byte CMD_REFRESH_SPEC_UNIT_DATA = 0x92;
		public const byte CMD_ADDRESS_ASSIGMENT_STRING_WIDE = 0x90;
		public const byte CMD_RESET_SPEC_STRING=0x90;
		public const byte CMD_REFRESH_SPEC_STRING_DATA = 0x90;
		public const byte CMD_ADDRESS_ASSIGMENT_BLOCK_WIDE = 0x90;
		public const byte CMD_RESET_SPEC_BLOCK = 0x90;
		public const byte CMD_REFRESH_SPEC_BLOCK_DATA = 0x90;

		public const byte STATUS_ACK  = 0xAA;
		public const byte STATUS_NACK = 0x55;


		public byte addressofBlock=0x80;
		public int  amountofCell = 600;
		public byte ctrlcmd=0x00;

		public void setaddress(byte addr)
		{
			addressofBlock = addr;
		}
		public void setctrlcmd(byte cmd)
		{
			ctrlcmd = cmd;
		}



	}
}
