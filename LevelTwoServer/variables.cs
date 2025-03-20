using System;
using System.Configuration;
using System.Data;

namespace contiCasterLevelTwoServer
{
	// Token: 0x02000009 RID: 9
	public class variables
	{
		// Token: 0x04000077 RID: 119
		public static int conticasterStrands = int.Parse(ConfigurationManager.AppSettings["conticasterStrands"].ToString());

		// Token: 0x04000078 RID: 120
		public static string casterNumber = ConfigurationManager.AppSettings["casterNumber"].ToString();

		// Token: 0x04000079 RID: 121
		public static string station_code = ConfigurationManager.AppSettings["station_code"].ToString();

		// Token: 0x0400007A RID: 122
		public static string readDataFlag = ConfigurationManager.AppSettings["readDataFlag"].ToString();

		// Token: 0x0400007B RID: 123
		public static string debugYesOrNoFlag = ConfigurationManager.AppSettings["debugYesOrNoFlag"].ToString();

		// Token: 0x0400007C RID: 124
		public static string[] MASTER = new string[70];

		// Token: 0x0400007D RID: 125
		public static string[] PLC1 = new string[70];

		// Token: 0x0400007E RID: 126
		public static string[] PLC2 = new string[70];

		// Token: 0x0400007F RID: 127
		public static string[] PLC3 = new string[70];

		// Token: 0x04000080 RID: 128
		public static string[] PLC4 = new string[70];

		// Token: 0x04000081 RID: 129
		public static string[] PLC5 = new string[70];

		// Token: 0x04000082 RID: 130
		public static string[] PLC6 = new string[70];

		// Token: 0x04000083 RID: 131
		public static string[] PLC7 = new string[70];

		// Token: 0x04000084 RID: 132
		public static string[] PLC8 = new string[70];

		// Token: 0x04000085 RID: 133
		public static string[] PLC9 = new string[70];

		// Token: 0x04000086 RID: 134
		public static string[] PLC10 = new string[70];

		// Token: 0x04000087 RID: 135
		public static string[] PLC11 = new string[70];

		// Token: 0x04000088 RID: 136
		public static string[] PLC12 = new string[70];

		// Token: 0x04000089 RID: 137
		public static string[][] eachStrandPlcData = new string[][]
		{
			variables.PLC1,
			variables.PLC2,
			variables.PLC3,
			variables.PLC4,
			variables.PLC5,
			variables.PLC6,
			variables.PLC7,
			variables.PLC8,
			variables.PLC9,
			variables.PLC10,
			variables.PLC11,
			variables.PLC12
		};

		// Token: 0x0400008A RID: 138
		public static double[] CoderRealLength = new double[variables.conticasterStrands];

		// Token: 0x0400008B RID: 139
		public static string[] energy_sum = new string[60];

		// Token: 0x0400008C RID: 140
		public static int[] preTorcherCutCounts = new int[variables.conticasterStrands];

		// Token: 0x0400008D RID: 141
		public static int[] nowTorcherCutCounts = new int[variables.conticasterStrands];

		// Token: 0x0400008E RID: 142
		public static string pouringHeatNo = "888888888";

		// Token: 0x0400008F RID: 143
		public static string[] plc_data = new string[200];

		// Token: 0x04000090 RID: 144
		public static string class_shift;

		// Token: 0x04000091 RID: 145
		public static string class_group;

		// Token: 0x04000092 RID: 146
		public static string currentCutHeatNo;

		public static string nowCutHeatNo;

		// Token: 0x04000093 RID: 147
		public static string currentSteelType;

		// Token: 0x04000094 RID: 148
		public static string currentSectionId;

		// Token: 0x04000095 RID: 149
		public static string heatNoUnboundReplaceStr = "123456789";

		// Token: 0x04000096 RID: 150
		public static string startProduceInitialStr = "888888888";

		// Token: 0x04000097 RID: 151
		public static string currentHeatVisitNo;

		// Token: 0x04000098 RID: 152
		public static string currentCastNo;

		// Token: 0x04000099 RID: 153
		public static string currentCastSeq;

		// Token: 0x0400009A RID: 154
		public static string currentHeatOrder;

		// Token: 0x0400009B RID: 155
		public static string currentSpecification;

		// Token: 0x0400009C RID: 156
		public static double currentAimedLength;

		// Token: 0x0400009D RID: 157
		public static int currentAimedWT;

		// Token: 0x0400009E RID: 158
		public static int thick;

		// Token: 0x0400009F RID: 159
		public static int width;

		// Token: 0x040000A0 RID: 160
		public static DataTable dataAllTb = new DataTable();

		// Token: 0x040000A1 RID: 161
		public static bool dataServerNetFlag;

		// Token: 0x040000A2 RID: 162
		public static bool plcServerNetFlag;

		// Token: 0x040000A3 RID: 163
		public static bool levelTwoPlusNetFlag;

		// Token: 0x040000A4 RID: 164
		public static bool databaseConnectFlag;

		// Token: 0x040000A5 RID: 165
		public static string CutEndDate;

		// Token: 0x040000A6 RID: 166
		public static string CutEndTime;

		// Token: 0x040000A7 RID: 167
		public static string CutBegDate;

		// Token: 0x040000A8 RID: 168
		public static string CutBegTime;

		// Token: 0x040000A9 RID: 169
		public static DateTime castDateTimeWL;

		// Token: 0x040000AA RID: 170
		public static double timerInterval;

		// Token: 0x040000AB RID: 171
		public static DateTime[] tundishTempTime = new DateTime[6];

		// Token: 0x040000AC RID: 172
		public static double[] tundishTempAuto = new double[6];

		// Token: 0x040000AD RID: 173
		public static double[] tundishTempManual = new double[6];

		// Token: 0x040000AE RID: 174
		public static double[] TundishTemp = new double[12];

		// Token: 0x040000AF RID: 175
		public static double[,] eachStrandCastSpeed = new double[6, variables.conticasterStrands];

		// Token: 0x040000B0 RID: 176
		public static int[] strandCastingFlag = new int[variables.conticasterStrands];

		// Token: 0x040000B1 RID: 177
		public static string[] billetNo = new string[variables.conticasterStrands];

		// Token: 0x040000B2 RID: 178
		public static int exchangeHeatLeaveSignalCounts;

		// Token: 0x040000B3 RID: 179
		public static int ladleArriveDelayReadFlag;

		// Token: 0x040000B4 RID: 180
		public static string[] normalProduceCloseStrand = new string[variables.conticasterStrands];

		// Token: 0x040000B5 RID: 181
		public static string[] measureTempTime = new string[3];

		// Token: 0x040000B6 RID: 182
		public static double[] billetRealWgt = new double[variables.conticasterStrands];

		// Token: 0x040000B7 RID: 183
		public static string CastingArmNo;

		// Token: 0x040000B8 RID: 184
		public static string produceSigalCloseStartFlag = "False";

		// Token: 0x040000B9 RID: 185
		public static string tundishNoL;

		// Token: 0x040000BA RID: 186
		public static string tundishNoR;

		// Token: 0x040000BB RID: 187
		public static DataTable realLenCutCountsTb;

		// Token: 0x040000BC RID: 188
		public static int[] weightSignalDelayFlag = new int[variables.conticasterStrands];

		// Token: 0x040000BD RID: 189
		public static int[] hotSignalDelayFlag = new int[variables.conticasterStrands];

		// Token: 0x040000BE RID: 190
		public static int[] coolSignalDelayFlag = new int[variables.conticasterStrands];

		// Token: 0x040000BF RID: 191
		public static string[] eachStrandCastTime = new string[variables.conticasterStrands];

		// Token: 0x040000C0 RID: 192
		public static string[] eachStrandStopTime = new string[variables.conticasterStrands];
	}
}
