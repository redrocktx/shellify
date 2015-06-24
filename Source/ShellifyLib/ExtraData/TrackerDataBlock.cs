/*
    Shellify, .NET implementation of Shell Link (.LNK) Binary File Format
    Copyright (C) 2010 Sebastien LEBRETON

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Text;
using Shellify.IO;
using System.Collections;

namespace Shellify.ExtraData
{
	public class TrackerDataBlock : ExtraDataBlock
	{
		public int Version { get; set; }
		public string MachineID;
        //public string MacAddress;
		public Guid[] Droid { get; set; }
        public Uuid Uuid { get; set; }
	    public Guid[] DroidBirth { get; set; }
        public Uuid UuidBirth { get; set; }
        //public String MacAddress { get; set; }
		
		public TrackerDataBlock()
		{
			Signature = ExtraDataBlockSignature.TrackerDataBlock;
            Droid = new Guid[2];
            DroidBirth = new Guid[2];
            //MacAddress = Uuid.MacAddress;
        }

        private static string ToString(IEnumerable collection)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            foreach (object item in collection)
            {
                if (builder.Length > 1)
                {
                    builder.Append(",");
                }
                builder.Append(item);
            }
            builder.Append("}");
            return builder.ToString();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendFormat("Version: {0}", Version); builder.AppendLine();
            builder.AppendFormat("MachineID: {0}", MachineID); builder.AppendLine();
            builder.AppendFormat("Droid:\n{0}", ToString(Droid)); builder.AppendLine();
            builder.AppendFormat("DroidBirth:\n{0}", ToString(DroidBirth)); ; builder.AppendLine();
            builder.AppendFormat("Uuid MacAddress:\n{0}", Uuid.MacAddress); ; builder.AppendLine();
            builder.AppendFormat("Uuid Timestamp:\n{0}", Uuid.Timestamp.ToShortDateString() + " " + Uuid.Timestamp.ToShortTimeString()); builder.AppendLine(); 
            builder.AppendFormat("Uuid ClockId:\n{0}", Uuid.ClockId.ToString());
            return builder.ToString();
        }

		
	}
}
